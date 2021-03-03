using Gamadu.PVA.Business.DataAccess;
using Gamadu.PVA.Business.Models;
using Prism.Ioc;
using Prism.Mvvm;
using System.Collections.Generic;

namespace Gamadu.PVA.Views.Employees.ViewModels
{
  public class EmployeesViewModel : BindableBase
  {
    #region Properties

    public IContainerProvider ContainerProvider { get; set; }

    public IAllDataAccess DataAccess { get; set; }

    private IEnumerable<IEmployee> availableEmployees;
    public IEnumerable<IEmployee> AvailableEmployees
    {
      get { return availableEmployees; }
      set { SetProperty(ref availableEmployees, value); }
    }

    private IEnumerable<IDepartment> availableDepartments;
    public IEnumerable<IDepartment> AvailableDepartments
    {
      get { return availableDepartments; }
      set { SetProperty(ref availableDepartments, value); }
    }

    private IEnumerable<IPosition> availablePositions;
    public IEnumerable<IPosition> AvailablePositions
    {
      get { return availablePositions; }
      set { SetProperty(ref availablePositions, value); }
    }

    private IEnumerable<IContract> availableContracts;
    public IEnumerable<IContract> AvailableContracts
    {
      get { return availableContracts; }
      set { SetProperty(ref availableContracts, value); }
    }

    private IEnumerable<IRoom> availableRooms;
    public IEnumerable<IRoom> AvailableRooms
    {
      get { return availableRooms; }
      set { SetProperty(ref availableRooms, value); }
    }

    private IEmployee selectedEmployee;
    public IEmployee SelectedEmployee
    {
      get { return selectedEmployee; }
      set { SetProperty(ref selectedEmployee, value); }
    }

    #endregion Properties

    /// <summary>
    /// Constructor for the Employees View Model
    /// </summary>
    public EmployeesViewModel(IContainerProvider container)
    {
      this.ContainerProvider = container;

      this.SetDataAccess("MySQL");

      this.RefreshAllData();
    }

    #region Methods

    public void SetDataAccess(string identification = "")
    {
      this.DataAccess = this.ContainerProvider.Resolve<IAllDataAccess>(identification);
    }

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
      this.AvailableEmployees = DataAccess.GetEmployees();
    }

    /// <summary>
    /// Gets all available departments from the database.
    /// </summary>
    protected void RefreshAvailableDepartments()
    {
      this.AvailableDepartments = DataAccess.GetDepartments();
    }

    /// <summary>
    /// Gets all available positions from the database.
    /// </summary>
    protected void RefreshAvailablePositions()
    {
      this.AvailablePositions = DataAccess.GetPositions();
    }

    /// <summary>
    /// Gets all available contracts from the database.
    /// </summary>
    protected void RefreshAvailableContracts()
    {
      this.AvailableContracts = DataAccess.GetContracts();
    }

    /// <summary>
    /// Gets all available rooms from the database.
    /// </summary>
    protected void RefreshAvailableRooms()
    {
      this.AvailableRooms = DataAccess.GetRooms();
    }

    #endregion Methods
  }
}
