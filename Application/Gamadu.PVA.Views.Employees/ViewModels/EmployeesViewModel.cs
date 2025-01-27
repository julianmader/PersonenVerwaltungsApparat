﻿namespace Gamadu.PVA.Views.Employees.ViewModels
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

  public class EmployeesViewModel : BindableBase
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

    private ObservableCollection<IDepartment> availableDepartments;

    public ObservableCollection<IDepartment> AvailableDepartments
    {
      get => this.availableDepartments;
      set => this.SetProperty(ref this.availableDepartments, value);
    }

    private ObservableCollection<IPosition> availablePositions;

    public ObservableCollection<IPosition> AvailablePositions
    {
      get => this.availablePositions;
      set => this.SetProperty(ref this.availablePositions, value);
    }

    private ObservableCollection<IContract> availableContracts;

    public ObservableCollection<IContract> AvailableContracts
    {
      get => this.availableContracts;
      set => this.SetProperty(ref this.availableContracts, value);
    }

    private ObservableCollection<IRoom> availableRooms;

    public ObservableCollection<IRoom> AvailableRooms
    {
      get => this.availableRooms;
      set => this.SetProperty(ref this.availableRooms, value);
    }

    private ObservableCollection<IRoom> selectedEmployeeRooms;

    public ObservableCollection<IRoom> SelectedEmployeeRooms
    {
      get => this.selectedEmployeeRooms;
      set => this.SetProperty(ref this.selectedEmployeeRooms, value);
    }

    private IEmployee selectedEmployee;

    public IEmployee SelectedEmployee
    {
      get => this.selectedEmployee;
      set => this.SetProperty(ref this.selectedEmployee, value);
    }

    private IEmployee compareSelectedEmployee;

    public IEmployee CompareSelectedEmployee
    {
      get => this.compareSelectedEmployee;
      set => this.SetProperty(ref this.compareSelectedEmployee, value);
    }

    #endregion Properties

    /// <summary>
    /// Constructor for the Employees View Model
    /// </summary>
    public EmployeesViewModel(IContainerProvider container)
    {
      this.ContainerProvider = container;
      this.PropertyChanged += this.EmployeesViewModel_PropertyChanged;

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

      this.EditSelectedRoomsCommand = new DelegateCommand(this.OnEditSelectedRoomsCommand, this.CanEditSelectedRoomsCommand);

      this.ListboxSelectionChangedCommand = new DelegateCommand(this.OnListboxSelectionChangedCommand);
    }

    #region Refresh Data Methods

    /// <summary>
    /// Refreshes all data from the database.
    /// </summary>
    protected void RefreshAllData()
    {
      this.RefreshAvailableDepartments();
      this.RefreshAvailablePositions();
      this.RefreshAvailableContracts();
      this.RefreshAvailableRooms();
      this.RefreshAvailableEmployees();
    }

    /// <summary>
    /// Gets all available employees from the database.
    /// </summary>
    protected void RefreshAvailableEmployees()
    {
      string currentlySelected = this.SelectedEmployee?.Matchcode;
      this.SelectedEmployee = null;

      this.AvailableEmployees = new ObservableCollection<IEmployee>(this.DataAccess.GetEmployees());

      this.SelectedEmployee = this.AvailableEmployees.FirstOrDefault(e => e.Matchcode.Equals(currentlySelected, System.StringComparison.OrdinalIgnoreCase));
    }

    /// <summary>
    /// Gets all available departments from the database.
    /// </summary>
    protected void RefreshAvailableDepartments() => this.AvailableDepartments = new ObservableCollection<IDepartment>(this.DataAccess.GetDepartments());

    /// <summary>
    /// Gets all available positions from the database.
    /// </summary>
    protected void RefreshAvailablePositions() => this.AvailablePositions = new ObservableCollection<IPosition>(this.DataAccess.GetPositions());

    /// <summary>
    /// Gets all available contracts from the database.
    /// </summary>
    protected void RefreshAvailableContracts() => this.AvailableContracts = new ObservableCollection<IContract>(this.DataAccess.GetContracts());

    /// <summary>
    /// Gets all available rooms from the database.
    /// </summary>
    protected void RefreshAvailableRooms() => this.AvailableRooms = new ObservableCollection<IRoom>(this.DataAccess.GetRooms());

    /// <summary>
    /// Refreshes the selected rooms collection for the selected employee.
    /// </summary>
    protected void RefreshSelectedEmployeeRooms()
    {
      if (this.SelectedEmployee?.Rooms?.Any() != true)
      {
        this.SelectedEmployeeRooms = null;
        return;
      }

      this.SelectedEmployeeRooms = new ObservableCollection<IRoom>(this.AvailableRooms.Where(r => this.SelectedEmployee.Rooms.Contains((int)r.ID)));
    }

    /// <summary>
    /// Contains the routine when the selected employee changed.
    /// </summary>
    private void SelectedEmployeeChanged()
    {
      this.CompareSelectedEmployee = null;

      if (this.SelectedEmployee != null)
      {
        this.CompareSelectedEmployee = this.SelectedEmployee.MemberwiseCopy();
        this.SelectedEmployee.Validator = this.ContainerProvider.Resolve<IValidator<IEmployee>>();
        this.SelectedEmployee.PropertyChanged += this.SelectedEmployee_PropertyChanged;
      }

      this.RefreshCommands();

      this.RefreshSelectedEmployeeRooms();
    }

    #endregion Refresh Data Methods

    #region Refresh Commands Methods

    /// <summary>
    /// Updates the commands can execute status.
    /// </summary>
    private void RefreshCommands()
    {
      this.SaveCommand?.RaiseCanExecuteChanged();
      this.DeleteCommand?.RaiseCanExecuteChanged();
      this.EditSelectedRoomsCommand?.RaiseCanExecuteChanged();
      this.ListboxSelectionChangedCommand?.RaiseCanExecuteChanged();
    }

    #endregion Refresh Commands Methods

    #region Internal Event Handler

    private async void EmployeesViewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
    {
      if (e.PropertyName.Equals(nameof(this.SelectedEmployee), StringComparison.OrdinalIgnoreCase))
      {
        await Task.Run(this.SelectedEmployeeChanged).ConfigureAwait(false);
        return;
      }
    }

    private async void SelectedEmployee_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
    {
      await Task.Run(() => this.SelectedEmployee.Validate()).ConfigureAwait(false);

      this.RefreshCommands();
    }

    #endregion Internal Event Handler

    /// <summary>
    /// Shows the select rooms dialog.
    /// </summary>
    private void ShowSelectRoomsDialog()
    {
      IDialogParameters dialogParameters = new DialogParameters
      {
        { "selectedIDs", this.SelectedEmployee.Rooms }
      };

      this.DialogService.ShowDialog("SelectRoomsDialog", dialogParameters, cb =>
      {
        if (cb.Result == ButtonResult.OK)
        {
          this.SelectedEmployee.Rooms = cb.Parameters.GetValue<IEnumerable<int>>("selectedIDs");

          this.RefreshSelectedEmployeeRooms();
        }
      });
    }

    private void ShowSaveChangesDialog()
    {
      this.DialogService.ShowDialog("SaveChangesDialog", cb =>
      {
        if (cb.Result == ButtonResult.OK)
        {
          this.SaveCommand.Execute();
          return;
        }

        if (cb.Result == ButtonResult.Cancel)
        {
          this.SelectedEmployee = this.CompareSelectedEmployee.MemberwiseCopy();
          return;
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
      await Task.Run(() => this.DataAccess.SaveOrUpdateEmployee(this.SelectedEmployee)).ConfigureAwait(false);
      this.RefreshCommand.Execute();
    }

    private bool CanSaveCommand() => this.SelectedEmployee?.HasErrors == false && this.SelectedEmployee?.Equals(this.CompareSelectedEmployee) == false;

    #endregion SaveCommand

    #region DeleteCommand

    public DelegateCommand DeleteCommand { get; private set; }

    private async void OnDeleteCommand() => await Task.Run(() => this.DataAccess.DeleteEmployee(this.SelectedEmployee)).ConfigureAwait(false);

    private bool CanDeleteCommand() => this.SelectedEmployee?.ID != null;

    #endregion DeleteCommand

    #region NewCommand

    public DelegateCommand NewCommand { get; private set; }

    private async void OnNewCommand()
    {
      await Task.Run(() => this.SelectedEmployee = this.ContainerProvider.Resolve<IEmployee>()).ConfigureAwait(false);

      this.SelectedEmployee.Rooms = new List<int>();
      this.SelectedEmployee.Birth = DateTime.Now;

      this.CompareSelectedEmployee = this.SelectedEmployee.MemberwiseCopy();
    }

    #endregion NewCommand

    #region EditSelectedRoomsCommand

    public DelegateCommand EditSelectedRoomsCommand { get; private set; }

    private void OnEditSelectedRoomsCommand() => this.ShowSelectRoomsDialog();

    private bool CanEditSelectedRoomsCommand() => this.SelectedEmployee != null;

    #endregion EditSelectedRoomsCommand

    #region ListboxSelectionChangedCommand

    public DelegateCommand ListboxSelectionChangedCommand { get; private set; }

    private void OnListboxSelectionChangedCommand()
    {
      if (this.SelectedEmployee == null) return;

      if (!this.SelectedEmployee.Equals(this.CompareSelectedEmployee))
        this.ShowSaveChangesDialog();
    }

    #endregion ListboxSelectionChangedCommand

    #endregion Commands
  }
}