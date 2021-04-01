namespace Gamadu.PVA.Core.DataAccess.MySQL
{
  using Dapper;
  using Gamadu.PVA.Core.Models;
  using System.Collections.Generic;
  using System.Data;
  using System.Linq;

  public partial class MySQLDataAccess
  {
    #region Department

    /// <inheritdoc/>
    public int SaveDepartment(IDepartment department)
    {
      string sql = "SaveDepartment";
      int affectedRows = 0;

      using (IDbConnection connection = this.GetDbConnection())
      {
        affectedRows = connection.Execute(sql,
          new
          {
            Matchcode = department.Matchcode?.ToUpper(),
            Name = department.Name?.Trim(),
            CostCenter = department.CostCenter?.Trim(),
            Manager = department.Manager,
            Description = department.Description?.Trim()
          }, commandType: CommandType.StoredProcedure);
      }

      affectedRows += this.SaveDepartmentEmployees(department);

      return affectedRows;
    }

    /// <summary>
    /// Saves the employees of a department.
    /// </summary>
    /// <param name="department">The department to save.</param>
    /// <returns>The amount of affected rows.</returns>
    private int SaveDepartmentEmployees(IDepartment department)
    {
      if (department == null)
        return 0;

      if (!department.Employees.Any())
        return 0;

      string sql = "SaveDepartmentEmployees";

      int affectedRows = 0;

      int? departmentID = this.GetDepartmentDatabaseID(department);

      if (departmentID == null) return 0;

      using (IDbConnection connection = this.GetDbConnection())
      {
        foreach (int id in department.Employees)
        {
          affectedRows += connection.Execute(sql,
            new
            {
              D_ID = (int)departmentID,
              E_ID = id,
            }, commandType: CommandType.StoredProcedure);
        }
      }

      return affectedRows;
    }

    /// <summary>
    /// Gets a department's database ID.
    /// </summary>
    /// <param name="department">The department</param>
    /// <returns>The ID or null.</returns>
    private int? GetDepartmentDatabaseID(IDepartment department)
    {
      if (department == null) return null;

      string sql = "GetDepartmentID";

      int? id = null;

      using (IDbConnection connection = this.GetDbConnection())
      {
        id = connection.ExecuteScalar<int?>(sql,
          new
          {
            Matchcode = department.Matchcode?.ToUpper()
          }, commandType: CommandType.StoredProcedure);
      }

      return id;
    }

    /// <inheritdoc/>
    public int UpdateDepartment(IDepartment department)
    {
      string sql = "UpdateDepartment";
      int affectedRows = 0;

      using (IDbConnection connection = this.GetDbConnection())
      {
        affectedRows = connection.Execute(sql,
          new
          {
            D_ID = department.ID,
            Matchcode = department.Matchcode?.ToUpper(),
            Name = department.Name,
            CostCenter = department.CostCenter,
            Manager = department.Manager,
            Description = department.Description
          }, commandType: CommandType.StoredProcedure);
      }

      affectedRows += this.SaveDepartmentEmployees(department);

      return affectedRows;
    }

    /// <inheritdoc/>
    public int DeleteDepartment(IIdentifiable id) => this.DeleteDepartment((int)id.ID);

    /// <inheritdoc/>
    public IDepartment GetDepartment(IIdentifiable id) => this.GetDepartment((int)id.ID);

    /// <inheritdoc/>
    public int DeleteDepartment(int id)
    {
      string sql = "DeleteDepartment";

      using (IDbConnection connection = this.GetDbConnection())
      {
        int affectedRows = connection.Execute(sql,
          new
          {
            D_ID = id
          }, commandType: CommandType.StoredProcedure);
        return affectedRows;
      }
    }

    /// <inheritdoc/>
    public IDepartment GetDepartment(int id)
    {
      string sql = "GetDepartment";

      using (IDbConnection connection = this.GetDbConnection())
      {
        IDepartment department = connection.QueryFirst<Department>(sql,
          new
          {
            D_ID = id
          }, commandType: CommandType.StoredProcedure);

        if (department != null)
        {
          department.Employees = this.GetDepartmentEmployees(id);
        }

        return department;
      }
    }

    /// <summary>
    /// Gets the IDs of the employees associated with the department.
    /// </summary>
    /// <param name="id">The department id.</param>
    /// <returns></returns>
    private IEnumerable<int> GetDepartmentEmployees(int id)
    {
      string sql = "GetDepartmentEmployees";

      using (IDbConnection connection = this.GetDbConnection())
      {
        IEnumerable<int> employees = connection.Query<int>(sql,
          new
          {
            D_ID = id
          }, commandType: CommandType.StoredProcedure);

        return employees;
      }
    }

    /// <inheritdoc/>
    public int SaveDepartments(IEnumerable<IDepartment> departments)
    {
      int affectedRows = 0;

      foreach (IDepartment department in departments)
      {
        affectedRows += this.SaveDepartment(department);
      }

      return affectedRows;
    }

    /// <inheritdoc/>
    public int UpdateDepartments(IEnumerable<IDepartment> departments)
    {
      int affectedRows = 0;

      foreach (IDepartment department in departments)
      {
        affectedRows += this.UpdateDepartment(department);
      }

      return affectedRows;
    }

    /// <inheritdoc/>
    public int DeleteDepartments(IEnumerable<IIdentifiable> ids)
    {
      int affectedRows = 0;

      foreach (IIdentifiable id in ids)
      {
        affectedRows += this.DeleteDepartment(id);
      }

      return affectedRows;
    }

    /// <inheritdoc/>
    public IEnumerable<IDepartment> GetDepartments(IEnumerable<IIdentifiable> ids)
    {
      List<IDepartment> departments = new List<IDepartment>();

      foreach (IIdentifiable id in ids)
      {
        IDepartment department = this.GetDepartment(id);

        if (department != null)
        {
          departments.Add(department);
        }
      }

      return departments;
    }

    /// <inheritdoc/>
    public int DeleteDepartments(IEnumerable<int> ids)
    {
      int affectedRows = 0;

      foreach (int id in ids)
      {
        affectedRows += this.DeleteDepartment(id);
      }

      return affectedRows;
    }

    /// <inheritdoc/>
    public IEnumerable<IDepartment> GetDepartments(IEnumerable<int> ids)
    {
      List<IDepartment> departments = new List<IDepartment>();

      foreach (int id in ids)
      {
        IDepartment department = this.GetDepartment(id);

        if (department != null)
        {
          departments.Add(department);
        }
      }

      return departments;
    }

    /// <inheritdoc/>
    public int DeleteDepartments()
    {
      string sql = "DeleteAllDepartments";

      using (IDbConnection connection = this.GetDbConnection())
      {
        int affectedRows = connection.Execute(sql, commandType: CommandType.StoredProcedure);

        return affectedRows;
      }
    }

    /// <inheritdoc/>
    public IEnumerable<IDepartment> GetDepartments()
    {
      string sql = "GetAllDepartments";
      List<IDepartment> departments = new List<IDepartment>();

      using (IDbConnection connection = this.GetDbConnection())
      {
        departments = new List<IDepartment>(connection.Query<Department>(sql, commandType: CommandType.StoredProcedure));
      }

      if (departments?.Any() == true)
      {
        for (int i = 0; i < departments.Count; i++)
        {
          departments[i].Employees = this.GetDepartmentEmployees((int)departments[i].ID);
        }
      }

      return departments;
    }

    #endregion Department
  }
}