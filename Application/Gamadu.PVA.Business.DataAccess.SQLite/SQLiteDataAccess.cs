namespace Gamadu.PVA.Business.DataAccess.SQLite
{
  using Dapper;
  using Gamadu.PVA.Business.Models;
  using Microsoft.Data.Sqlite;
  using System;
  using System.Collections.Generic;
  using System.Data;
  using System.IO;

  public class SQLiteDataAccess : IAllDataAccess
  {
    private string PersonsTable => "TB_Employees";
    private string ContractsTable => "TB_Contracts";
    private string DepartmentsTable => "TB_Departments";
    private string PositionsTable => "TB_Positions";
    private string RoomsTable => "TB_Rooms";

    /// <summary>
    /// Backing field for <see cref="File"/>.
    /// </summary>
    private FileInfo file;

    /// <summary>
    /// Gets or sets the value for the SQLite file.
    /// </summary>
    public FileInfo File { get; set; }

    /// <summary>
    /// Initializes a new SQLite data access instance.
    /// </summary>
    /// <param name="filePath">The path of the SQLite file.</param>
    public SQLiteDataAccess(string filePath)
    {
      this.File = new FileInfo(filePath);
    }

    /// <summary>
    /// Creates the <see cref="IDbConnection"/> object.
    /// </summary>
    private IDbConnection GetDbConnection()
    {
      return new SqliteConnection(this.File.FullName);
    }

    public int SavePerson(IPerson person)
    {
      string sql = $"INSERT INTO {this.PersonsTable} ()";

      using (IDbConnection connection = this.GetDbConnection())
      {
        int affectedRows = connection.Execute(sql, new { });
      }

      throw new NotImplementedException();
    }

    public int UpdatePerson(IPerson person)
    {
      throw new NotImplementedException();
    }

    public int DeletePerson(IIdentifiable id)
    {
      throw new NotImplementedException();
    }

    public IPerson GetPerson(IIdentifiable id)
    {
      throw new NotImplementedException();
    }

    public int DeletePerson(int id)
    {
      throw new NotImplementedException();
    }

    public IPerson GetPerson(int id)
    {
      throw new NotImplementedException();
    }

    public int SavePersons(IEnumerable<IPerson> persons)
    {
      throw new NotImplementedException();
    }

    public int UpdatePersons(IEnumerable<IPerson> persons)
    {
      throw new NotImplementedException();
    }

    public int DeletePersons(IEnumerable<IIdentifiable> ids)
    {
      throw new NotImplementedException();
    }

    public IEnumerable<IPerson> GetPersons(IEnumerable<IIdentifiable> ids)
    {
      throw new NotImplementedException();
    }

    public int DeletePersons(IEnumerable<int> ids)
    {
      throw new NotImplementedException();
    }

    public IEnumerable<IPerson> GetPersons(IEnumerable<int> ids)
    {
      throw new NotImplementedException();
    }

    public int DeletePersons()
    {
      throw new NotImplementedException();
    }

    public IEnumerable<IPerson> GetPersons()
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
