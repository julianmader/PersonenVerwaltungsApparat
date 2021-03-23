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

namespace Gamadu.PVA.Views.Departments.ViewModels
{
  public class DepartmentsViewModel : BindableBase
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

    private ObservableCollection<IDepartment> availableDepartments;
    public ObservableCollection<IDepartment> AvailableDepartments
    {
      get { return this.availableDepartments; }
      set { this.SetProperty(ref this.availableDepartments, value); }
    }

    private ObservableCollection<IEmployee> selectedDepartmentEmployees;
    public ObservableCollection<IEmployee> SelectedDepartmentEmployees
    {
      get { return this.selectedDepartmentEmployees; }
      set { this.SetProperty(ref this.selectedDepartmentEmployees, value); }
    }

    private IDepartment selectedDepartment;
    public IDepartment SelectedDepartment
    {
      get { return this.selectedDepartment; }
      set { this.SetProperty(ref this.selectedDepartment, value); }
    }

    #endregion Properties

    /// <summary>
    /// Constructor for the Departments View Model
    /// </summary>
    /// <param name="container"></param>
    public DepartmentsViewModel(IContainerProvider container)
    {
      this.ContainerProvider = container;
      this.PropertyChanged += this.DepartmentsViewModel_PropertyChanged;

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
      this.RefreshAvailableDepartments();
    }

    /// <summary>
    /// Gets all available departments from the database.
    /// </summary>
    protected void RefreshAvailableDepartments()
    {
      string currentlySelected = this.SelectedDepartment?.Matchcode;
      this.SelectedDepartment = null;

      this.AvailableDepartments = new ObservableCollection<IDepartment>(this.DataAccess.GetDepartments());

      this.SelectedDepartment = this.AvailableDepartments.FirstOrDefault(d => d.Matchcode.Equals(currentlySelected, System.StringComparison.OrdinalIgnoreCase));
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
    protected void RefreshSelectedDepartmentEmployees()
    {
      if (this.SelectedDepartment?.Employees?.Any() != true)
      {
        this.SelectedDepartmentEmployees = null;
        return;
      }

      this.SelectedDepartmentEmployees = new ObservableCollection<IEmployee>(this.AvailableEmployees.Where(e => this.SelectedDepartment.Employees.Contains((int)e.ID)));
    }

    /// <summary>
    /// Contains the routine when the selected department changed.
    /// </summary>
    private void SelectedDepartmentChanged()
    {
      this.RefreshCommands();

      this.RefreshSelectedDepartmentEmployees();
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

    private async void DepartmentsViewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
    {
      if (e.PropertyName.Equals(nameof(this.SelectedDepartment), StringComparison.OrdinalIgnoreCase))
      {
        await Task.Run(this.SelectedDepartmentChanged);
        return;
      }
    }

    #endregion Internal Event Handler

    /// <summary>
    /// Shows the select employees dialog.
    /// </summary>
    private void ShowSelectEmployeesDialog()
    {
      IDialogParameters dialogParameters = new DialogParameters();
      dialogParameters.Add("selectedIDs", this.SelectedDepartment.Employees);

      this.DialogService.ShowDialog("SelectEmployeesDialog", dialogParameters, cb =>
      {
        if (cb.Result == ButtonResult.OK)
        {
          this.SelectedDepartment.Employees = cb.Parameters.GetValue<IEnumerable<int>>("selectedIDs");

          this.RefreshSelectedDepartmentEmployees();
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
      await Task.Run(() => this.DataAccess.SaveOrUpdateDepartment(this.SelectedDepartment));
      this.RefreshCommand.Execute();
    }

    private bool CanSaveCommand()
    {
      return this.SelectedDepartment != null;
    }

    #endregion SaveCommand

    #region DeleteCommand

    public DelegateCommand DeleteCommand { get; private set; }

    private async void OnDeleteCommand()
    {
      await Task.Run(() => this.DataAccess.DeleteDepartment(this.SelectedDepartment));
    }

    private bool CanDeleteCommand()
    {
      if (this.SelectedDepartment == null) return false;

      return this.SelectedDepartment.ID != null;
    }

    #endregion DeleteCommand

    #region NewCommand

    public DelegateCommand NewCommand { get; private set; }

    private async void OnNewCommand()
    {
      await Task.Run(() => this.SelectedDepartment = this.ContainerProvider.Resolve<IDepartment>());

      this.SelectedDepartment.Employees = new List<int>();
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
      return this.SelectedDepartment != null;
    }

    #endregion EditSelectedEmployeesCommand

    #endregion Commands
  }
}
