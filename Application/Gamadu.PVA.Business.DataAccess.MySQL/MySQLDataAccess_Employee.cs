namespace Gamadu.PVA.Business.DataAccess.MySQL
{
  using Dapper;
  using Gamadu.PVA.Business.Models;
  using System.Collections.Generic;
  using System.Data;

  public partial class MySQLDataAccess
  {
    #region Employee

    /// <inheritdoc/>
    public int SaveEmployee(IEmployee employee)
    {
      string sql = "SaveEmployee";

      using (IDbConnection connection = this.GetDbConnection())
      {
        int affectedRows = connection.Execute(sql,
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
        return affectedRows;
      }
    }

    /// <inheritdoc/>
    public int UpdateEmployee(IEmployee employee)
    {
      string sql = "UpdateEmployee";

      using (IDbConnection connection = this.GetDbConnection())
      {
        int affectedRows = connection.Execute(sql,
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
        return affectedRows;
      }
    }

    /// <inheritdoc/>
    public int DeleteEmployee(IIdentifiable id)
    {
      return this.DeleteEmployee(id.ID);
    }

    /// <inheritdoc/>
    public IEmployee GetEmployee(IIdentifiable id)
    {
      return this.GetEmployee(id.ID);
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

        return employee;
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

      using (IDbConnection connection = this.GetDbConnection())
      {
        IEnumerable<IEmployee> employees = connection.Query<Employee>(sql, commandType: CommandType.StoredProcedure);

        return employees;
      }
    }

    #endregion Employee
  }
}
