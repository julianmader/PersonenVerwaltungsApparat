namespace Gamadu.PVA.Views.Rooms.ViewModels
{
  using FluentValidation;
  using Gamadu.PVA.Core.DataAccess;
  using Gamadu.PVA.Core.Models;
  using Prism.Commands;
  using Prism.Ioc;
  using Prism.Mvvm;
  using Prism.Services.Dialogs;
  using System;
  using System.Collections.Generic;
  using System.Collections.ObjectModel;
  using System.Linq;
  using System.Threading.Tasks;

  public class RoomsViewModel : BindableBase
  {
    #region Properties

    protected IContainerProvider ContainerProvider { get; set; }

    protected IBusinessObjectDataAccess DataAccess { get; set; }

    protected IDialogService DialogService { get; set; }

    private bool isRefreshing;

    public bool IsRefreshing
    {
      get => this.isRefreshing;
      set => this.SetProperty(ref this.isRefreshing, value);
    }

    private ObservableCollection<IEmployee> availableEmployees;

    public ObservableCollection<IEmployee> AvailableEmployees
    {
      get => this.availableEmployees;
      set => this.SetProperty(ref this.availableEmployees, value);
    }

    private ObservableCollection<IRoom> availableRooms;

    public ObservableCollection<IRoom> AvailableRooms
    {
      get => this.availableRooms;
      set => this.SetProperty(ref this.availableRooms, value);
    }

    private ObservableCollection<IEmployee> selectedRoomEmployees;

    public ObservableCollection<IEmployee> SelectedRoomEmployees
    {
      get => this.selectedRoomEmployees;
      set => this.SetProperty(ref this.selectedRoomEmployees, value);
    }

    private IRoom selectedRoom;

    public IRoom SelectedRoom
    {
      get => this.selectedRoom;
      set => this.SetProperty(ref this.selectedRoom, value);
    }

    #endregion Properties

    /// <summary>
    /// Constructor for the Rooms View Model
    /// </summary>
    /// <param name="container"></param>
    public RoomsViewModel(IContainerProvider container)
    {
      this.ContainerProvider = container;
      this.PropertyChanged += this.RoomsViewModel_PropertyChanged;

      this.SetDataAccess("MySQL");
      this.DialogService = this.ContainerProvider.Resolve<IDialogService>();

      this.InitializeCommands();
      this.RefreshCommand.Execute();
    }

    #region Methods

    /// <summary>
    /// Sets the data access.
    /// </summary>
    /// <param name="identification">The identification string of the instance.</param>
    protected void SetDataAccess(string identification = "") => this.DataAccess = this.ContainerProvider.Resolve<IBusinessObjectDataAccess>(identification);

    /// <summary>
    /// Initializes the commands.
    /// </summary>
    private void InitializeCommands()
    {
      this.RefreshCommand = new DelegateCommand(this.OnRefreshCommand);

      this.SaveCommand = new DelegateCommand(this.OnSaveCommand, this.CanSaveCommand);

      this.DeleteCommand = new DelegateCommand(this.OnDeleteCommand, this.CanDeleteCommand);

      this.NewCommand = new DelegateCommand(this.OnNewCommand);

      this.EditSelectedEmployeesCommand = new DelegateCommand(this.OnEditSelectedEmployeesCommand, this.CanEditSelectedEmployeesCommand);
    }

    #region Refresh Data Methods

    /// <summary>
    /// Refreshes all data from the database.
    /// </summary>
    protected void RefreshAllData()
    {
      this.RefreshAvailableEmployees();
      this.RefreshAvailableRooms();
    }

    /// <summary>
    /// Gets all available rooms from the database.
    /// </summary>
    protected void RefreshAvailableRooms()
    {
      string currentlySelected = this.SelectedRoom?.Matchcode;
      this.SelectedRoom = null;

      this.AvailableRooms = new ObservableCollection<IRoom>(this.DataAccess.GetRooms());

      this.SelectedRoom = this.AvailableRooms.FirstOrDefault(r => r.Matchcode.Equals(currentlySelected, System.StringComparison.OrdinalIgnoreCase));
    }

    /// <summary>
    /// Gets all available employees from the database.
    /// </summary>
    protected void RefreshAvailableEmployees() => this.AvailableEmployees = new ObservableCollection<IEmployee>(this.DataAccess.GetEmployees());

    /// <summary>
    /// Refreshes the selected rooms collection for the selected employee.
    /// </summary>
    protected void RefreshSelectedRoomEmployees()
    {
      if (this.SelectedRoom?.Employees?.Any() != true)
      {
        this.SelectedRoomEmployees = null;
        return;
      }

      this.SelectedRoomEmployees = new ObservableCollection<IEmployee>(this.AvailableEmployees.Where(e => this.SelectedRoom.Employees.Contains((int)e.ID)));
    }

    /// <summary>
    /// Contains the routine when the selected room changed.
    /// </summary>
    private void SelectedRoomChanged()
    {
      if (this.SelectedRoom != null)
      {
        this.SelectedRoom.Validator = this.ContainerProvider.Resolve<IValidator<IRoom>>();
        this.SelectedRoom.PropertyChanged += this.SelectedRoom_PropertyChanged;
      }

      this.RefreshCommands();

      this.RefreshSelectedRoomEmployees();
    }

    #endregion Refresh Data Methods

    #region Refresh Commands Methods

    /// <summary>
    /// Updates the commands can execute status.
    /// </summary>
    private void RefreshCommands()
    {
      this.SaveCommand.RaiseCanExecuteChanged();
      this.DeleteCommand.RaiseCanExecuteChanged();
      this.EditSelectedEmployeesCommand.RaiseCanExecuteChanged();
    }

    #endregion Refresh Commands Methods

    #region Internal Event Handler

    private async void RoomsViewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
    {
      if (e.PropertyName.Equals(nameof(this.SelectedRoom), StringComparison.OrdinalIgnoreCase))
      {
        await Task.Run(this.SelectedRoomChanged).ConfigureAwait(false);
        return;
      }
    }

    private async void SelectedRoom_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
    {
      await Task.Run(() => this.SelectedRoom.Validate()).ConfigureAwait(false);

      this.RefreshCommands();
    }

    #endregion Internal Event Handler

    /// <summary>
    /// Shows the select employees dialog.
    /// </summary>
    private void ShowSelectEmployeesDialog()
    {
      IDialogParameters dialogParameters = new DialogParameters
      {
        { "selectedIDs", this.SelectedRoom.Employees }
      };

      this.DialogService.ShowDialog("SelectEmployeesDialog", dialogParameters, cb =>
      {
        if (cb.Result == ButtonResult.OK)
        {
          this.SelectedRoom.Employees = cb.Parameters.GetValue<IEnumerable<int>>("selectedIDs");

          this.RefreshSelectedRoomEmployees();
        }
      });
    }

    #endregion Methods

    #region Commands

    #region RefreshCommand

    public DelegateCommand RefreshCommand { get; private set; }

    private async void OnRefreshCommand()
    {
      this.IsRefreshing = true;

      await Task.Run(this.RefreshAllData).ConfigureAwait(false);

      this.IsRefreshing = false;
    }

    #endregion RefreshCommand

    #region SaveCommand

    public DelegateCommand SaveCommand { get; private set; }

    private async void OnSaveCommand()
    {
      await Task.Run(() => this.DataAccess.SaveOrUpdateRoom(this.SelectedRoom)).ConfigureAwait(false);
      this.RefreshCommand.Execute();
    }

    private bool CanSaveCommand() => this.SelectedRoom?.HasErrors == false;

    #endregion SaveCommand

    #region DeleteCommand

    public DelegateCommand DeleteCommand { get; private set; }

    private async void OnDeleteCommand() => await Task.Run(() => this.DataAccess.DeleteDepartment(this.SelectedRoom)).ConfigureAwait(false);

    private bool CanDeleteCommand() => this.SelectedRoom?.ID != null;

    #endregion DeleteCommand

    #region NewCommand

    public DelegateCommand NewCommand { get; private set; }

    private async void OnNewCommand()
    {
      await Task.Run(() => this.SelectedRoom = this.ContainerProvider.Resolve<IRoom>()).ConfigureAwait(false);

      this.SelectedRoom.Employees = new List<int>();
    }

    #endregion NewCommand

    #region EditSelectedEmployeesCommand

    public DelegateCommand EditSelectedEmployeesCommand { get; private set; }

    private void OnEditSelectedEmployeesCommand() => this.ShowSelectEmployeesDialog();

    private bool CanEditSelectedEmployeesCommand() => this.SelectedRoom != null;

    #endregion EditSelectedEmployeesCommand

    #endregion Commands
  }
}