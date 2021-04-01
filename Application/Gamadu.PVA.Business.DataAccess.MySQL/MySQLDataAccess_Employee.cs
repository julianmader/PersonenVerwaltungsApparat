namespace Gamadu.PVA.Core.DataAccess.MySQL
{
  using Dapper;
  using Gamadu.PVA.Core.Models;
  using System.Collections.Generic;
  using System.Data;
  using System.Linq;

  public partial class MySQLDataAccess
  {
    #region Employee

    /// <inheritdoc/>
    public int SaveEmployee(IEmployee employee)
    {
      string sql = "SaveEmployee";
      int affectedRows = 0;

      using (IDbConnection connection = this.GetDbConnection())
      {
        affectedRows = connection.Execute(sql,
          new
          {
            Matchcode = employee.Matchcode?.ToUpper(),
            Gender = employee.Gender,
            Forename = employee.Forename?.Trim(),
            Surname = employee.Surname?.Trim(),
            Birth = employee.Birth,
            PhoneNumber = employee.PhoneNumber?.Trim(),
            Email = employee.Email?.Trim(),
            Department = employee.Department,
            Position = employee.Position,
            Contract = employee.Contract,
            AdditionalInformation = employee.AdditionalInformation?.Trim(),
            Street = employee.Street?.Trim(),
            StreetNumber = employee.StreetNumber?.Trim(),
            City = employee.City?.Trim(),
            PostalCode = employee.PostalCode?.Trim()
          }, commandType: CommandType.StoredProcedure);
      }

      affectedRows += this.SaveEmployeeRooms(employee);

      return affectedRows;
    }

    /// <summary>
    /// Saves the rooms of a employee in the connection table.
    /// </summary>
    /// <param name="employee">The employee to save.</param>
    /// <returns>The amount of affected rows.</returns>
    private int SaveEmployeeRooms(IEmployee employee)
    {
      if (employee == null)
        return 0;

      if (!employee.Rooms.Any())
        return 0;

      string sql = "SaveRoomEmployees";

      int affectedRows = 0;

      int? employeeID = this.GetEmployeeDatabaseID(employee);

      if (employeeID == null) return 0;

      using (IDbConnection connection = this.GetDbConnection())
      {
        foreach (int id in employee.Rooms)
        {
          affectedRows += connection.Execute(sql,
            new
            {
              R_ID = id,
              E_ID = (int)employeeID,
            }, commandType: CommandType.StoredProcedure);
        }
      }

      return affectedRows;
    }

    /// <summary>
    /// Gets a employee's database ID.
    /// </summary>
    /// <param name="employee">The employee</param>
    /// <returns>The ID or null.</returns>
    private int? GetEmployeeDatabaseID(IEmployee employee)
    {
      if (employee == null) return null;

      string sql = "GetEmployeeID";

      int? id = null;

      using (IDbConnection connection = this.GetDbConnection())
      {
        id = connection.ExecuteScalar<int?>(sql,
          new
          {
            Matchcode = employee.Matchcode?.ToUpper()
          }, commandType: CommandType.StoredProcedure);
      }

      return id;
    }

    /// <inheritdoc/>
    public int UpdateEmployee(IEmployee employee)
    {
      string sql = "UpdateEmployee";

      int affectedRows = 0;

      using (IDbConnection connection = this.GetDbConnection())
      {
        affectedRows = connection.Execute(sql,
          new
          {
            E_ID = employee.ID,
            Matchcode = employee.Matchcode?.ToUpper(),
            Gender = employee.Gender,
            Forename = employee.Forename?.Trim(),
            Surname = employee.Surname?.Trim(),
            Birth = employee.Birth,
            PhoneNumber = employee.PhoneNumber?.Trim(),
            Email = employee.Email?.Trim(),
            Department = employee.Department,
            Position = employee.Position,
            Contract = employee.Contract,
            AdditionalInformation = employee.AdditionalInformation?.Trim(),
            Street = employee.Street?.Trim(),
            StreetNumber = employee.StreetNumber?.Trim(),
            City = employee.City?.Trim(),
            PostalCode = employee.PostalCode?.Trim()
          }, commandType: CommandType.StoredProcedure);
      }

      affectedRows += this.SaveEmployeeRooms(employee);

      return affectedRows;
    }

    /// <inheritdoc/>
    public int DeleteEmployee(IIdentifiable id)
    {
      return this.DeleteEmployee((int)id.ID);
    }

    /// <inheritdoc/>
    public IEmployee GetEmployee(IIdentifiable id)
    {
      return this.GetEmployee((int)id.ID);
    }

    /// <inheritdoc/>
    public int DeleteEmployee(int id)
    {
      string sql = "DeleteEmployee";

      using (IDbConnection connection = this.GetDbConnection())
      {
        int affectedRows = connection.Execute(sql,
          new
          {
            E_ID = id
          }, commandType: CommandType.StoredProcedure);

        return affectedRows;
      }
    }

    /// <inheritdoc/>
    public IEmployee GetEmployee(int id)
    {
      string sql = "GetEmployee";

      using (IDbConnection connection = this.GetDbConnection())
      {
        IEmployee employee = connection.QueryFirst<Employee>(sql,
          new
          {
            E_ID = id
          }, commandType: CommandType.StoredProcedure);

        if (employee != null)
        {
          employee.Rooms = this.GetEmployeeRooms(id);
        }

        return employee;
      }
    }

    /// <summary>
    /// Gets the IDs of the rooms associated with the employee.
    /// </summary>
    /// <param name="id">The employee id.</param>
    /// <returns></returns>
    private IEnumerable<int> GetEmployeeRooms(int id)
    {
      string sql = "GetEmployeeRooms";

      using (IDbConnection connection = this.GetDbConnection())
      {
        IEnumerable<int> rooms = connection.Query<int>(sql,
          new
          {
            E_ID = id
          }, commandType: CommandType.StoredProcedure);

        return rooms;
      }
    }

    /// <inheritdoc/>
    public int SaveEmployees(IEnumerable<IEmployee> employees)
    {
      int affectedRows = 0;

      foreach (IEmployee employee in employees)
      {
        affectedRows += this.SaveEmployee(employee);
      }

      return affectedRows;
    }

    /// <inheritdoc/>
    public int UpdateEmployees(IEnumerable<IEmployee> employees)
    {
      int affectedRows = 0;

      foreach (IEmployee employee in employees)
      {
        affectedRows += this.UpdateEmployee(employee);
      }

      return affectedRows;
    }

    /// <inheritdoc/>
    public int DeleteEmployees(IEnumerable<IIdentifiable> ids)
    {
      int affectedRows = 0;

      foreach (IIdentifiable id in ids)
      {
        affectedRows += this.DeleteEmployee(id);
      }

      return affectedRows;
    }

    /// <inheritdoc/>
    public IEnumerable<IEmployee> GetEmployees(IEnumerable<IIdentifiable> ids)
    {
      List<IEmployee> employees = new List<IEmployee>();

      foreach (IIdentifiable id in ids)
      {
        IEmployee employee = this.GetEmployee(id);

        if (employee != null)
        {
          employees.Add(employee);
        }
      }

      return employees;
    }

    /// <inheritdoc/>
    public int DeleteEmployees(IEnumerable<int> ids)
    {
      int affectedRows = 0;

      foreach (int id in ids)
      {
        affectedRows += this.DeleteEmployee(id);
      }

      return affectedRows;
    }

    /// <inheritdoc/>
    public IEnumerable<IEmployee> GetEmployees(IEnumerable<int> ids)
    {
      List<IEmployee> employees = new List<IEmployee>();

      foreach (int id in ids)
      {
        IEmployee employee = this.GetEmployee(id);

        if (employee != null)
        {
          employees.Add(employee);
        }
      }

      return employees;
    }

    /// <inheritdoc/>
    public int DeleteEmployees()
    {
      string sql = "DeleteAllEmployees";

      using (IDbConnection connection = this.GetDbConnection())
      {
        int affectedRows = connection.Execute(sql, commandType: CommandType.StoredProcedure);

        return affectedRows;
      }
    }

    /// <inheritdoc/>
    public IEnumerable<IEmployee> GetEmployees()
    {
      string sql = "GetAllEmployees";
      List<IEmployee> employees = new List<IEmployee>();

      using (IDbConnection connection = this.GetDbConnection())
      {
        employees = new List<IEmployee>(connection.Query<Employee>(sql, commandType: CommandType.StoredProcedure));
      }

      if (employees?.Any() == true)
      {
        for (int i = 0; i < employees.Count(); i++)
        {
          employees[i].Rooms = this.GetEmployeeRooms((int)employees[i].ID);
        }
      }

      return employees;
    }

    #endregion Employee
  }
}