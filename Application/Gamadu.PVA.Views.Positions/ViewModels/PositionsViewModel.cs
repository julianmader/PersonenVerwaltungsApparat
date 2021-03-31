using FluentValidation;
using Gamadu.PVA.Business.DataAccess;
using Gamadu.PVA.Business.Models;
using Prism.Commands;
using Prism.Ioc;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace Gamadu.PVA.Views.Positions.ViewModels
{
  public class PositionsViewModel : BindableBase
  {
    #region Properties

    protected IContainerProvider ContainerProvider { get; set; }

    protected IAllDataAccess DataAccess { get; set; }

    protected IDialogService DialogService { get; set; }

    private bool isRefreshing;

    public bool IsRefreshing
    {
      get { return this.isRefreshing; }
      set { this.SetProperty(ref this.isRefreshing, value); }
    }

    private ObservableCollection<IEmployee> availableEmployees;

    public ObservableCollection<IEmployee> AvailableEmployees
    {
      get { return this.availableEmployees; }
      set { this.SetProperty(ref this.availableEmployees, value); }
    }

    private ObservableCollection<IPosition> availablePositions;

    public ObservableCollection<IPosition> AvailablePositions
    {
      get { return this.availablePositions; }
      set { this.SetProperty(ref this.availablePositions, value); }
    }

    private ObservableCollection<IEmployee> selectedPositionEmployees;

    public ObservableCollection<IEmployee> SelectedPositionEmployees
    {
      get { return this.selectedPositionEmployees; }
      set { this.SetProperty(ref this.selectedPositionEmployees, value); }
    }

    private IPosition selectedPosition;

    public IPosition SelectedPosition
    {
      get { return this.selectedPosition; }
      set { this.SetProperty(ref this.selectedPosition, value); }
    }

    #endregion Properties

    /// <summary>
    /// Constructor for the Positions View Model
    /// </summary>
    /// <param name="container"></param>
    public PositionsViewModel(IContainerProvider container)
    {
      this.ContainerProvider = container;
      this.PropertyChanged += this.PositionsViewModel_PropertyChanged;

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
    protected void SetDataAccess(string identification = "")
    {
      this.DataAccess = this.ContainerProvider.Resolve<IAllDataAccess>(identification);
    }

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
      this.RefreshAvailablePositions();
    }

    /// <summary>
    /// Gets all available positions from the database.
    /// </summary>
    protected void RefreshAvailablePositions()
    {
      string currentlySelected = this.SelectedPosition?.Matchcode;
      this.SelectedPosition = null;

      this.AvailablePositions = new ObservableCollection<IPosition>(this.DataAccess.GetPositions());

      this.SelectedPosition = this.AvailablePositions.FirstOrDefault(p => p.Matchcode.Equals(currentlySelected, System.StringComparison.OrdinalIgnoreCase));
    }

    /// <summary>
    /// Gets all available employees from the database.
    /// </summary>
    protected void RefreshAvailableEmployees()
    {
      this.AvailableEmployees = new ObservableCollection<IEmployee>(this.DataAccess.GetEmployees());
    }

    /// <summary>
    /// Refreshes the selected rooms collection for the selected employee.
    /// </summary>
    protected void RefreshSelectedPositionEmployees()
    {
      if (this.SelectedPosition?.Employees?.Any() != true)
      {
        this.SelectedPositionEmployees = null;
        return;
      }

      this.SelectedPositionEmployees = new ObservableCollection<IEmployee>(this.AvailableEmployees.Where(e => this.SelectedPosition.Employees.Contains((int)e.ID)));
    }

    /// <summary>
    /// Contains the routine when the selected department changed.
    /// </summary>
    private void SelectedPositionChanged()
    {
      if (this.SelectedPosition != null)
      {
        this.SelectedPosition.Validator = this.ContainerProvider.Resolve<IValidator<IPosition>>();
        this.SelectedPosition.PropertyChanged += this.SelectedPosition_PropertyChanged;
      }

      this.RefreshCommands();

      this.RefreshSelectedPositionEmployees();
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

    private async void PositionsViewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
    {
      if (e.PropertyName.Equals(nameof(this.SelectedPosition), StringComparison.OrdinalIgnoreCase))
      {
        await Task.Run(this.SelectedPositionChanged);
        return;
      }
    }

    private async void SelectedPosition_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
    {
      await Task.Run(() => this.SelectedPosition.Validate());

      this.RefreshCommands();
    }

    #endregion Internal Event Handler

    /// <summary>
    /// Shows the select employees dialog.
    /// </summary>
    private void ShowSelectEmployeesDialog()
    {
      IDialogParameters dialogParameters = new DialogParameters();
      dialogParameters.Add("selectedIDs", this.SelectedPosition.Employees);

      this.DialogService.ShowDialog("SelectEmployeesDialog", dialogParameters, cb =>
      {
        if (cb.Result == ButtonResult.OK)
        {
          this.SelectedPosition.Employees = cb.Parameters.GetValue<IEnumerable<int>>("selectedIDs");

          this.RefreshSelectedPositionEmployees();
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

      await Task.Run(this.RefreshAllData);

      this.IsRefreshing = false;
    }

    #endregion RefreshCommand

    #region SaveCommand

    public DelegateCommand SaveCommand { get; private set; }

    private async void OnSaveCommand()
    {
      await Task.Run(() => this.DataAccess.SaveOrUpdatePosition(this.SelectedPosition));
      this.RefreshCommand.Execute();
    }

    private bool CanSaveCommand()
    {
      return this.SelectedPosition != null &&
        !this.SelectedPosition.HasErrors;
    }

    #endregion SaveCommand

    #region DeleteCommand

    public DelegateCommand DeleteCommand { get; private set; }

    private async void OnDeleteCommand()
    {
      await Task.Run(() => this.DataAccess.DeleteDepartment(this.SelectedPosition));
    }

    private bool CanDeleteCommand()
    {
      if (this.SelectedPosition == null) return false;

      return this.SelectedPosition.ID != null;
    }

    #endregion DeleteCommand

    #region NewCommand

    public DelegateCommand NewCommand { get; private set; }

    private async void OnNewCommand()
    {
      await Task.Run(() => this.SelectedPosition = this.ContainerProvider.Resolve<IPosition>());

      this.SelectedPosition.Employees = new List<int>();
    }

    #endregion NewCommand

    #region EditSelectedEmployeesCommand

    public DelegateCommand EditSelectedEmployeesCommand { get; private set; }

    private void OnEditSelectedEmployeesCommand()
    {
      this.ShowSelectEmployeesDialog();
    }

    private bool CanEditSelectedEmployeesCommand()
    {
      return this.SelectedPosition != null;
    }

    #endregion EditSelectedEmployeesCommand

    #endregion Commands
  }
}