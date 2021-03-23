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

namespace Gamadu.PVA.Views.Dialogs.ViewModels
{
  public class SelectEmployeesViewModel : BindableBase, IDialogAware
  {
    #region Properties

    public event Action<IDialogResult> RequestClose;

    protected IContainerProvider ContainerProvider { get; set; }

    protected IEmployeeDataAccess DataAccess { get; set; }

    public string Title { get; }

    /// <summary>
    /// Backing field for <see cref="CheckableEmployees"/>.
    /// </summary>
    private ObservableCollection<ICheckableEmployee> checkableEmployees;

    /// <summary>
    /// Gets or sets the value for the CheckableEmployees.
    /// </summary>
    public ObservableCollection<ICheckableEmployee> CheckableEmployees
    {
      get { return this.checkableEmployees; }
      set { this.SetProperty(ref this.checkableEmployees, value); }
    }

    #endregion Properties

    public SelectEmployeesViewModel(IContainerProvider container)
    {
      this.Title = "Select Employees";

      this.ContainerProvider = container;

      this.SetDataAccess("MySQL");

      this.InitializeCommands();
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
      this.CloseCommand = new DelegateCommand<bool?>(this.OnCloseCommand);
    }

    /// <summary>
    /// Sets the checkable employees collection, based on the available employees.
    /// </summary>
    /// <param name="selectedIDs">The selected employees' ids</param>
    protected void SetCheckableEmployees(IEnumerable<int> selectedIDs)
    {
      IEnumerable<IEmployee> availableEmployees = this.DataAccess.GetEmployees();

      if (availableEmployees?.Any() == false) return;

      List<ICheckableEmployee> temp = new List<ICheckableEmployee>();

      foreach (IEmployee employee in availableEmployees)
      {
        ICheckableEmployee checkableEmployee = this.ContainerProvider.Resolve<ICheckableEmployee>();

        if (selectedIDs != null)
          checkableEmployee.IsChecked = selectedIDs.Contains((int)employee.ID);
        else
          checkableEmployee.IsChecked = false;
        checkableEmployee.ID = employee.ID;
        checkableEmployee.Matchcode = employee.Matchcode;
        checkableEmployee.Forename = employee.Forename;
        checkableEmployee.Surname = employee.Surname;

        temp.Add(checkableEmployee);
      }

      this.CheckableEmployees = new ObservableCollection<ICheckableEmployee>(temp);
    }

    #endregion Methods

    #region Commands

    public DelegateCommand<bool?> CloseCommand { get; private set; }

    private void OnCloseCommand(bool? accept)
    {
      ButtonResult buttonResult = ButtonResult.None;

      if ((bool)accept) buttonResult = ButtonResult.OK;
      if (!(bool)accept) buttonResult = ButtonResult.Cancel;

      IEnumerable<int> selectedIDs = this.CheckableEmployees?.Where(ce => ce.IsChecked).Select(cr => (int)cr.ID).ToList();

      IDialogParameters dialogParameters = new DialogParameters();
      dialogParameters.Add("selectedIDs", selectedIDs);

      IDialogResult dialogResult = new DialogResult(buttonResult, dialogParameters);

      this.RaiseRequestClose(dialogResult);
    }

    public void RaiseRequestClose(IDialogResult dialogResult)
    {
      RequestClose?.Invoke(dialogResult);
    }

    public bool CanCloseDialog()
    {
      return true;
    }

    public void OnDialogClosed()
    {
    }

    public void OnDialogOpened(IDialogParameters parameters)
    {
      IEnumerable<int> selectedIDs = parameters.GetValue<IEnumerable<int>>("selectedIDs");

      this.SetCheckableEmployees(selectedIDs);
    }

    #endregion Commands
  }
}