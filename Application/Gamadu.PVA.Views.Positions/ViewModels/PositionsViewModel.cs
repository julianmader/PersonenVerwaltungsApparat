﻿namespace Gamadu.PVA.Views.Positions.ViewModels
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

  public class PositionsViewModel : BindableBase
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

    private ObservableCollection<IPosition> availablePositions;

    public ObservableCollection<IPosition> AvailablePositions
    {
      get => this.availablePositions;
      set => this.SetProperty(ref this.availablePositions, value);
    }

    private ObservableCollection<IEmployee> selectedPositionEmployees;

    public ObservableCollection<IEmployee> SelectedPositionEmployees
    {
      get => this.selectedPositionEmployees;
      set => this.SetProperty(ref this.selectedPositionEmployees, value);
    }

    private IPosition selectedPosition;

    public IPosition SelectedPosition
    {
      get => this.selectedPosition;
      set => this.SetProperty(ref this.selectedPosition, value);
    }

    private IPosition compareSelectedPosition;

    public IPosition CompareSelectedPosition
    {
      get => this.compareSelectedPosition;
      set => this.SetProperty(ref this.compareSelectedPosition, value);
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

      this.ListboxSelectionChangedCommand = new DelegateCommand(this.OnListboxSelectionChangedCommand);
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
    protected void RefreshAvailableEmployees() => this.AvailableEmployees = new ObservableCollection<IEmployee>(this.DataAccess.GetEmployees());

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
      this.CompareSelectedPosition = null;

      if (this.SelectedPosition != null)
      {
        this.CompareSelectedPosition = this.SelectedPosition.MemberwiseCopy();
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
      this.SaveCommand?.RaiseCanExecuteChanged();
      this.DeleteCommand?.RaiseCanExecuteChanged();
      this.EditSelectedEmployeesCommand?.RaiseCanExecuteChanged();
      this.ListboxSelectionChangedCommand?.RaiseCanExecuteChanged();
    }

    #endregion Refresh Commands Methods

    #region Internal Event Handler

    private async void PositionsViewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
    {
      if (e.PropertyName.Equals(nameof(this.SelectedPosition), StringComparison.OrdinalIgnoreCase))
      {
        await Task.Run(this.SelectedPositionChanged).ConfigureAwait(false);
        return;
      }
    }

    private async void SelectedPosition_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
    {
      await Task.Run(() => this.SelectedPosition.Validate()).ConfigureAwait(false);

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
        { "selectedIDs", this.SelectedPosition.Employees }
      };

      this.DialogService.ShowDialog("SelectEmployeesDialog", dialogParameters, cb =>
      {
        if (cb.Result == ButtonResult.OK)
        {
          this.SelectedPosition.Employees = cb.Parameters.GetValue<IEnumerable<int>>("selectedIDs");

          this.RefreshSelectedPositionEmployees();
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
          this.SelectedPosition = this.CompareSelectedPosition.MemberwiseCopy();
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
      await Task.Run(() => this.DataAccess.SaveOrUpdatePosition(this.SelectedPosition)).ConfigureAwait(false);
      this.RefreshCommand.Execute();
    }

    private bool CanSaveCommand() => this.SelectedPosition?.HasErrors == false && this.SelectedPosition?.Equals(this.CompareSelectedPosition) == false;

    #endregion SaveCommand

    #region DeleteCommand

    public DelegateCommand DeleteCommand { get; private set; }

    private async void OnDeleteCommand() => await Task.Run(() => this.DataAccess.DeleteDepartment(this.SelectedPosition)).ConfigureAwait(false);

    private bool CanDeleteCommand() => this.SelectedPosition?.ID != null;

    #endregion DeleteCommand

    #region NewCommand

    public DelegateCommand NewCommand { get; private set; }

    private async void OnNewCommand()
    {
      await Task.Run(() => this.SelectedPosition = this.ContainerProvider.Resolve<IPosition>()).ConfigureAwait(false);

      this.SelectedPosition.Employees = new List<int>();
      this.CompareSelectedPosition = this.SelectedPosition.MemberwiseCopy();
    }

    #endregion NewCommand

    #region EditSelectedEmployeesCommand

    public DelegateCommand EditSelectedEmployeesCommand { get; private set; }

    private void OnEditSelectedEmployeesCommand() => this.ShowSelectEmployeesDialog();

    private bool CanEditSelectedEmployeesCommand() => this.SelectedPosition != null;

    #endregion EditSelectedEmployeesCommand

    #region ListboxSelectionChangedCommand

    public DelegateCommand ListboxSelectionChangedCommand { get; private set; }

    private void OnListboxSelectionChangedCommand()
    {
      if (this.SelectedPosition == null) return;

      if (!this.SelectedPosition.Equals(this.CompareSelectedPosition))
        this.ShowSaveChangesDialog();
    }

    #endregion ListboxSelectionChangedCommand

    #endregion Commands
  }
}