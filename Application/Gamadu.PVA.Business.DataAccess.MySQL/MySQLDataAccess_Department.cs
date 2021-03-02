﻿namespace Gamadu.PVA.Business.DataAccess.MySQL
{
  using Dapper;
  using Gamadu.PVA.Business.Models;
  using System.Collections.Generic;
  using System.Data;

  public partial class MySQLDataAccess
  {
    #region Department

    /// <inheritdoc/>
    public int SaveDepartment(IDepartment department)
    {
      string sql = "SaveDepartment";

      using (IDbConnection connection = this.GetDbConnection())
      {
        int affectedRows = connection.Execute(sql,
          new
          {
            Matchcode = department.Matchcode?.ToUpper(),
            Name = department.Name?.Trim(),
            CostCenter = department.CostCenter?.Trim(),
            Manager = department.Manager,
            Description = department.Description?.Trim()
          }, commandType: CommandType.StoredProcedure);
        return affectedRows;
      }
    }

    /// <inheritdoc/>
    public int UpdateDepartment(IDepartment department)
    {
      string sql = "UpdateDepartment";

      using (IDbConnection connection = this.GetDbConnection())
      {
        int affectedRows = connection.Execute(sql,
          new
          {
            D_ID = department.ID,
            Matchcode = department.Matchcode?.ToUpper(),
            Name = department.Name,
            CostCenter = department.CostCenter,
            Manager = department.Manager,
            Description = department.Description
          }, commandType: CommandType.StoredProcedure);
        return affectedRows;
      }
    }

    /// <inheritdoc/>
    public int DeleteDepartment(IIdentifiable id)
    {
      return this.DeleteDepartment(id.ID);
    }

    /// <inheritdoc/>
    public IDepartment GetDepartment(IIdentifiable id)
    {
      return this.GetDepartment(id.ID);
    }

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

        return department;
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

      using (IDbConnection connection = this.GetDbConnection())
      {
        IEnumerable<IDepartment> departments = connection.Query<Department>(sql, commandType: CommandType.StoredProcedure);

        return departments;
      }
    }

    #endregion Department
  }
}
