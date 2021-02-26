namespace Gamadu.PVA.Business.DataAccess.MySQL
{
  using Dapper;
  using Gamadu.PVA.Business.Models;
  using MySqlConnector;
  using System;
  using System.Collections.Generic;
  using System.Data;

  public class MySQLDataAccess : IAllDataAccess
  {
    private string AddressesTable => "tb_addresses";
    private string EmployeesTable => "tb_employees";
    private string EmployeesAddressesTable => "tb_employeesaddresses";
    private string ContractsTable => "tb_contracts";
    private string DepartmentsTable => "tb_departments";
    private string DepartmentsEmployeesTable => "tb_departmentsemployees";
    private string PositionsTable => "tb_positions";
    private string PositionsEmployeesTable => "tb_positionsemployees";
    private string RoomsTable => "tb_rooms";
    private string RoomsEmployeesTable => "tb_roomsemployees";

    /// <summary>
    /// The connection string.
    /// </summary>
    private string connectionString;

    /// <summary>
    /// Initializes a new MySQL data access instance.
    /// </summary>
    /// <param name="server">The server hostname.</param>
    /// <param name="database">The database name.</param>
    /// <param name="user">The user ID.</param>
    /// <param name="password">The user password.</param>
    public MySQLDataAccess(string server, string database, string user, string password)
    {
      this.DefineConnection(server, database, user, password);
    }

    /// <summary>
    /// Initializes a new MySQL data access instance.
    /// </summary>
    public MySQLDataAccess()
    {

    }

    /// <summary>
    /// Defines the connection credentials.
    /// </summary>
    /// <param name="server">The server hostname.</param>
    /// <param name="database">The database name.</param>
    /// <param name="user">The user ID.</param>
    /// <param name="password">The user password.</param>
    public void DefineConnection(string server, string database, string user, string password)
    {
      MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder()
      {
        Server = server,
        Database = database,
        UserID = user,
        Password = password,
        ConnectionTimeout = 10
      };

      this.connectionString = builder.ConnectionString;
    }

    /// <summary>
    /// Creates the <see cref="IDbConnection"/> object.
    /// </summary>
    private IDbConnection GetDbConnection()
    {
      return new MySqlConnection(this.connectionString);
    }

    public int SaveEmployee(IEmployee person)
    {
      string sql = $"INSERT INTO {this.EmployeesTable} ()";

      using (IDbConnection connection = this.GetDbConnection())
      {
        int affectedRows = connection.Execute(sql, new { });
      }

      throw new NotImplementedException();
    }

    public int UpdateEmployee(IEmployee person)
    {
      throw new NotImplementedException();
    }

    public int DeleteEmployee(IIdentifiable id)
    {
      throw new NotImplementedException();
    }

    public IEmployee GetEmployee(IIdentifiable id)
    {
      throw new NotImplementedException();
    }

    public int DeleteEmployee(int id)
    {
      throw new NotImplementedException();
    }

    public IEmployee GetEmployee(int id)
    {
      throw new NotImplementedException();
    }

    public int SaveEmployees(IEnumerable<IEmployee> persons)
    {
      throw new NotImplementedException();
    }

    public int UpdateEmployees(IEnumerable<IEmployee> persons)
    {
      throw new NotImplementedException();
    }

    public int DeleteEmployees(IEnumerable<IIdentifiable> ids)
    {
      throw new NotImplementedException();
    }

    public IEnumerable<IEmployee> GetEmployees(IEnumerable<IIdentifiable> ids)
    {
      throw new NotImplementedException();
    }

    public int DeleteEmployees(IEnumerable<int> ids)
    {
      throw new NotImplementedException();
    }

    public IEnumerable<IEmployee> GetEmployees(IEnumerable<int> ids)
    {
      throw new NotImplementedException();
    }

    public int DeleteEmployees()
    {
      throw new NotImplementedException();
    }

    public IEnumerable<IEmployee> GetEmployees()
    {
      throw new NotImplementedException();
    }

    public int SaveContract(IContract contract)
    {
      throw new NotImplementedException();
    }

    public int UpdateContract(IContract contract)
    {
      throw new NotImplementedException();
    }

    public int DeleteContract(IIdentifiable id)
    {
      throw new NotImplementedException();
    }

    public IContract GetContract(IIdentifiable id)
    {
      throw new NotImplementedException();
    }

    public int DeleteContract(int id)
    {
      throw new NotImplementedException();
    }

    public IContract GetContract(int id)
    {
      throw new NotImplementedException();
    }

    public int SaveContracts(IEnumerable<IContract> contracts)
    {
      throw new NotImplementedException();
    }

    public int UpdateContracts(IEnumerable<IContract> contracts)
    {
      throw new NotImplementedException();
    }

    public int DeleteContracts(IEnumerable<IIdentifiable> ids)
    {
      throw new NotImplementedException();
    }

    public IEnumerable<IContract> GetContracts(IEnumerable<IIdentifiable> ids)
    {
      throw new NotImplementedException();
    }

    public int DeleteContracts(IEnumerable<int> ids)
    {
      throw new NotImplementedException();
    }

    public IEnumerable<IContract> GetContracts(IEnumerable<int> ids)
    {
      throw new NotImplementedException();
    }

    public IEnumerable<IContract> GetContracts()
    {
      throw new NotImplementedException();
    }

    public int DeleteContracts()
    {
      throw new NotImplementedException();
    }

    public int SaveDepartment(IDepartment department)
    {
      throw new NotImplementedException();
    }

    public int UpdateDepartment(IDepartment department)
    {
      throw new NotImplementedException();
    }

    public int DeleteDepartment(IIdentifiable id)
    {
      throw new NotImplementedException();
    }

    public IDepartment GetDepartment(IIdentifiable id)
    {
      throw new NotImplementedException();
    }

    public int DeleteDepartment(int id)
    {
      throw new NotImplementedException();
    }

    public IDepartment GetDepartment(int id)
    {
      throw new NotImplementedException();
    }

    public int SaveDepartments(IEnumerable<IDepartment> departments)
    {
      throw new NotImplementedException();
    }

    public int UpdateDepartments(IEnumerable<IDepartment> departments)
    {
      throw new NotImplementedException();
    }

    public int DeleteDepartments(IEnumerable<IIdentifiable> ids)
    {
      throw new NotImplementedException();
    }

    public IEnumerable<IDepartment> GetDepartments(IEnumerable<IIdentifiable> ids)
    {
      throw new NotImplementedException();
    }

    public int DeleteDepartments(IEnumerable<int> ids)
    {
      throw new NotImplementedException();
    }

    public IEnumerable<IDepartment> GetDepartments(IEnumerable<int> ids)
    {
      throw new NotImplementedException();
    }

    public int DeleteDepartments()
    {
      throw new NotImplementedException();
    }

    public IEnumerable<IDepartment> GetDepartments()
    {
      throw new NotImplementedException();
    }

    public int SavePosition(IPosition position)
    {
      throw new NotImplementedException();
    }

    public int UpdatePosition(IPosition position)
    {
      throw new NotImplementedException();
    }

    public int DeletePosition(IIdentifiable id)
    {
      throw new NotImplementedException();
    }

    public IPosition GetPosition(IIdentifiable id)
    {
      throw new NotImplementedException();
    }

    public int DeletePosition(int id)
    {
      throw new NotImplementedException();
    }

    public IPosition GetPosition(int id)
    {
      throw new NotImplementedException();
    }

    public int SavePositions(IEnumerable<IPosition> positions)
    {
      throw new NotImplementedException();
    }

    public int UpdatePositions(IEnumerable<IPosition> positions)
    {
      throw new NotImplementedException();
    }

    public int DeletePositions(IEnumerable<IIdentifiable> ids)
    {
      throw new NotImplementedException();
    }

    public IEnumerable<IPosition> GetPositions(IEnumerable<IIdentifiable> ids)
    {
      throw new NotImplementedException();
    }

    public int DeletePositions(IEnumerable<int> ids)
    {
      throw new NotImplementedException();
    }

    public IEnumerable<IPosition> GetPositions(IEnumerable<int> ids)
    {
      throw new NotImplementedException();
    }

    public int DeletePositions()
    {
      throw new NotImplementedException();
    }

    public IEnumerable<IPosition> GetPositions()
    {
      throw new NotImplementedException();
    }

    public int SaveRoom(IRoom room)
    {
      throw new NotImplementedException();
    }

    public int UpdateRoom(IRoom room)
    {
      throw new NotImplementedException();
    }

    public int DeleteRoom(IIdentifiable id)
    {
      throw new NotImplementedException();
    }

    public IRoom GetRoom(IIdentifiable id)
    {
      throw new NotImplementedException();
    }

    public int DeleteRoom(int id)
    {
      throw new NotImplementedException();
    }

    public IRoom GetRoom(int id)
    {
      throw new NotImplementedException();
    }

    public int SaveRooms(IEnumerable<IRoom> rooms)
    {
      throw new NotImplementedException();
    }

    public int UpdateRooms(IEnumerable<IRoom> rooms)
    {
      throw new NotImplementedException();
    }

    public int DeleteRooms(IEnumerable<IIdentifiable> ids)
    {
      throw new NotImplementedException();
    }

    public IEnumerable<IRoom> GetRooms(IEnumerable<IIdentifiable> ids)
    {
      throw new NotImplementedException();
    }

    public int DeleteRooms(IEnumerable<int> ids)
    {
      throw new NotImplementedException();
    }

    public IEnumerable<IRoom> GetRooms(IEnumerable<int> ids)
    {
      throw new NotImplementedException();
    }

    public int DeleteRooms()
    {
      throw new NotImplementedException();
    }

    public IEnumerable<IRoom> GetRooms()
    {
      throw new NotImplementedException();
    }
  }
}
