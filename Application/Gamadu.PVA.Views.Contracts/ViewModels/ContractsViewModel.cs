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

namespace Gamadu.PVA.Views.Contracts.ViewModels
{
  public class ContractsViewModel : BindableBase
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

    private ObservableCollection<IContract> availableContracts;
    public ObservableCollection<IContract> AvailableContracts
    {
      get { return this.availableContracts; }
      set { this.SetProperty(ref this.availableContracts, value); }
    }

    private ObservableCollection<IEmployee> selectedContractEmployees;
    public ObservableCollection<IEmployee> SelectedContractEmployees
    {
      get { return this.selectedContractEmployees; }
      set { this.SetProperty(ref this.selectedContractEmployees, value); }
    }

    private IContract selectedContract;
    public IContract SelectedContract
    {
      get { return this.selectedContract; }
      set { this.SetProperty(ref this.selectedContract, value); }
    }

    #endregion Properties

    /// <summary>
    /// Constructor for the Contracts View Model
    /// </summary>
    /// <param name="container"></param>
    public ContractsViewModel(IContainerProvider container)
    {
      this.ContainerProvider = container;
      this.PropertyChanged += this.ContractsViewModel_PropertyChanged;

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
      this.RefreshAvailableContracts();
    }

    /// <summary>
    /// Gets all available contracts from the database.
    /// </summary>
    protected void RefreshAvailableContracts()
    {
      string currentlySelected = this.SelectedContract?.Matchcode;
      this.SelectedContract = null;

      this.AvailableContracts = new ObservableCollection<IContract>(this.DataAccess.GetContracts());

      this.SelectedContract = this.AvailableContracts.FirstOrDefault(c => c.Matchcode.Equals(currentlySelected, System.StringComparison.OrdinalIgnoreCase));
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
    protected void RefreshSelectedContractEmployees()
    {
      if (this.SelectedContract?.Employees?.Any() != true)
      {
        this.SelectedContractEmployees = null;
        return;
      }

      this.SelectedContractEmployees = new ObservableCollection<IEmployee>(this.AvailableEmployees.Where(e => this.SelectedContract.Employees.Contains((int)e.ID)));
    }

    /// <summary>
    /// Contains the routine when the selected contract changed.
    /// </summary>
    private void SelectedContractChanged()
    {
      this.RefreshCommands();

      this.RefreshSelectedContractEmployees();
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

    private async void ContractsViewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
    {
      if (e.PropertyName.Equals(nameof(this.SelectedContract), StringComparison.OrdinalIgnoreCase))
      {
        await Task.Run(this.SelectedContractChanged);
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
      dialogParameters.Add("selectedIDs", this.SelectedContract.Employees);

      this.DialogService.ShowDialog("SelectEmployeesDialog", dialogParameters, cb =>
      {
        if (cb.Result == ButtonResult.OK)
        {
          this.SelectedContract.Employees = cb.Parameters.GetValue<IEnumerable<int>>("selectedIDs");

          this.RefreshSelectedContractEmployees();
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
      await Task.Run(() => this.DataAccess.SaveOrUpdateContract(this.SelectedContract));
      this.RefreshCommand.Execute();
    }

    private bool CanSaveCommand()
    {
      return this.SelectedContract != null;
    }

    #endregion SaveCommand

    #region DeleteCommand

    public DelegateCommand DeleteCommand { get; private set; }

    private async void OnDeleteCommand()
    {
      await Task.Run(() => this.DataAccess.DeleteContract(this.SelectedContract));
    }

    private bool CanDeleteCommand()
    {
      if (this.SelectedContract == null) return false;

      return this.SelectedContract.ID != null;
    }

    #endregion DeleteCommand

    #region NewCommand

    public DelegateCommand NewCommand { get; private set; }

    private async void OnNewCommand()
    {
      await Task.Run(() => this.SelectedContract = this.ContainerProvider.Resolve<IContract>());
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
      return this.SelectedContract != null;
    }

    #endregion EditSelectedEmployeesCommand

    #endregion Commands
  }
}
