namespace Gamadu.PVA.Business.DataAccess.MySQL
{
  using Dapper;
  using Gamadu.PVA.Business.Models;
  using System.Collections.Generic;
  using System.Data;

  public partial class MySQLDataAccess
  {
    #region Contract

    /// <inheritdoc/>
    public int SaveContract(IContract contract)
    {
      string sql = "SaveContract";

      using (IDbConnection connection = this.GetDbConnection())
      {
        int affectedRows = connection.Execute(sql,
          new
          {
            Matchcode = contract.Matchcode?.ToUpper(),
            Name = contract.Name,
            WorkTime = contract.WorkTime,
            Holidays = contract.Holidays,
            Salary = contract.Salary,
            Start = contract.Start,
            End = contract.End,
            TrailEnd = contract.TrailEnd,
            Description = contract.Description,
            HasEnd = contract.HasEnd
          }, commandType: CommandType.StoredProcedure);
        return affectedRows;
      }
    }

    /// <inheritdoc/>
    public int UpdateContract(IContract contract)
    {
      string sql = "UpdateContract";

      using (IDbConnection connection = this.GetDbConnection())
      {
        int affectedRows = connection.Execute(sql,
          new
          {
            C_ID = contract.ID,
            Matchcode = contract.Matchcode?.ToUpper(),
            Name = contract.Name,
            WorkTime = contract.WorkTime,
            Holidays = contract.Holidays,
            Salary = contract.Salary,
            Start = contract.Start,
            End = contract.End,
            TrailEnd = contract.TrailEnd,
            Description = contract.Description,
            HasEnd = contract.HasEnd
          }, commandType: CommandType.StoredProcedure);
        return affectedRows;
      }
    }

    /// <inheritdoc/>
    public int DeleteContract(IIdentifiable id)
    {
      return this.DeleteContract(id.ID);
    }

    /// <inheritdoc/>
    public IContract GetContract(IIdentifiable id)
    {
      return this.GetContract(id.ID);
    }

    /// <inheritdoc/>
    public int DeleteContract(int id)
    {
      string sql = "DeleteContract";

      using (IDbConnection connection = this.GetDbConnection())
      {
        int affectedRows = connection.Execute(sql,
          new
          {
            C_ID = id
          }, commandType: CommandType.StoredProcedure);

        return affectedRows;
      }
    }

    /// <inheritdoc/>
    public IContract GetContract(int id)
    {
      string sql = "GetContract";

      using (IDbConnection connection = this.GetDbConnection())
      {
        IContract contract = connection.QueryFirst<Contract>(sql,
          new
          {
            C_ID = id
          }, commandType: CommandType.StoredProcedure);

        return contract;
      }
    }

    /// <inheritdoc/>
    public int SaveContracts(IEnumerable<IContract> contracts)
    {
      int affectedRows = 0;

      foreach (IContract contract in contracts)
      {
        affectedRows += this.SaveContract(contract);
      }

      return affectedRows;
    }

    /// <inheritdoc/>
    public int UpdateContracts(IEnumerable<IContract> contracts)
    {
      int affectedRows = 0;

      foreach (IContract contract in contracts)
      {
        affectedRows += this.UpdateContract(contract);
      }

      return affectedRows;
    }

    /// <inheritdoc/>
    public int DeleteContracts(IEnumerable<IIdentifiable> ids)
    {
      int affectedRows = 0;

      foreach (IIdentifiable id in ids)
      {
        affectedRows += this.DeleteContract(id);
      }

      return affectedRows;
    }

    /// <inheritdoc/>
    public IEnumerable<IContract> GetContracts(IEnumerable<IIdentifiable> ids)
    {
      List<IContract> contracts = new List<IContract>();

      foreach (IIdentifiable id in ids)
      {
        IContract contract = this.GetContract(id);

        if (contract != null)
        {
          contracts.Add(contract);
        }
      }

      return contracts;
    }

    /// <inheritdoc/>
    public int DeleteContracts(IEnumerable<int> ids)
    {
      int affectedRows = 0;

      foreach (int id in ids)
      {
        affectedRows += this.DeleteContract(id);
      }

      return affectedRows;
    }

    /// <inheritdoc/>
    public IEnumerable<IContract> GetContracts(IEnumerable<int> ids)
    {
      List<IContract> contracts = new List<IContract>();

      foreach (int id in ids)
      {
        IContract contract = this.GetContract(id);

        if (contract != null)
        {
          contracts.Add(contract);
        }
      }

      return contracts;
    }

    /// <inheritdoc/>
    public IEnumerable<IContract> GetContracts()
    {
      string sql = "GetAllContracts";

      using (IDbConnection connection = this.GetDbConnection())
      {
        IEnumerable<IContract> contracts = connection.Query<Contract>(sql, commandType: CommandType.StoredProcedure);

        return contracts;
      }
    }

    /// <inheritdoc/>
    public int DeleteContracts()
    {
      string sql = "DeleteAllContracts";

      using (IDbConnection connection = this.GetDbConnection())
      {
        int affectedRows = connection.Execute(sql, commandType: CommandType.StoredProcedure);

        return affectedRows;
      }
    }

    #endregion Contract
  }
}
