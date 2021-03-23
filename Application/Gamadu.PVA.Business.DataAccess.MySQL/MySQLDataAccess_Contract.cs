namespace Gamadu.PVA.Business.DataAccess.MySQL
{
  using Dapper;
  using Gamadu.PVA.Business.Models;
  using System.Collections.Generic;
  using System.Data;
  using System.Linq;

  public partial class MySQLDataAccess
  {
    #region Contract

    /// <inheritdoc/>
    public int SaveContract(IContract contract)
    {
      string sql = "SaveContract";
      int affectedRows = 0;

      using (IDbConnection connection = this.GetDbConnection())
      {
        affectedRows = connection.Execute(sql,
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
      }

      affectedRows += this.SaveContractEmployee(contract);

      return affectedRows;
    }

    /// <summary>
    /// Saves the employee of a contract.
    /// </summary>
    /// <param name="contract">The contract to save.</param>
    /// <returns>The amount of affected rows.</returns>
    private int SaveContractEmployee(IContract contract)
    {
      if (contract == null)
        return 0;

      string sql = "SaveContractEmployees";

      int? contractID = this.GetContractDatabaseID(contract);

      if (contractID == null) return 0;

      using (IDbConnection connection = this.GetDbConnection())
      {
        return connection.Execute(sql,
          new
          {
            C_ID = (int)contractID,
            E_ID = (int)contract.Employee
          }, commandType: CommandType.StoredProcedure);
      }
    }

    /// <summary>
    /// Gets a contract's database ID.
    /// </summary>
    /// <param name="contract">The contract</param>
    /// <returns>The ID or null.</returns>
    private int? GetContractDatabaseID(IContract contract)
    {
      if (contract == null) return null;

      string sql = "GetContractID";

      int? id = null;

      using (IDbConnection connection = this.GetDbConnection())
      {
        id = connection.ExecuteScalar<int?>(sql,
          new
          {
            Matchcode = contract.Matchcode?.ToUpper()
          }, commandType: CommandType.StoredProcedure);
      }

      return id;
    }

    /// <inheritdoc/>
    public int UpdateContract(IContract contract)
    {
      string sql = "UpdateContract";
      int affectedRows = 0;

      using (IDbConnection connection = this.GetDbConnection())
      {
        affectedRows = connection.Execute(sql,
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
      }

      affectedRows += this.SaveContractEmployee(contract);

      return affectedRows;
    }

    /// <inheritdoc/>
    public int DeleteContract(IIdentifiable id)
    {
      return this.DeleteContract((int)id.ID);
    }

    /// <inheritdoc/>
    public IContract GetContract(IIdentifiable id)
    {
      return this.GetContract((int)id.ID);
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

        if (contract != null)
        {
          contract.Employee = this.GetContractEmployee(id);
        }

        return contract;
      }
    }

    /// <summary>
    /// Gets the ID of the employee associated with the contract.
    /// </summary>
    /// <param name="id">The contract id.</param>
    /// <returns></returns>
    private int? GetContractEmployee(int id)
    {
      string sql = "GetContractEmployees";

      using (IDbConnection connection = this.GetDbConnection())
      {
        int? employee = connection.QueryFirst<int?>(sql,
          new
          {
            C_ID = id
          }, commandType: CommandType.StoredProcedure);

        return employee;
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
      List<IContract> contracts = new List<IContract>();

      using (IDbConnection connection = this.GetDbConnection())
      {
        contracts = new List<IContract>(connection.Query<Contract>(sql, commandType: CommandType.StoredProcedure));
      }

      if (contracts?.Any() == true)
      {
        for (int i = 0; i < contracts.Count(); i++)
        {
          contracts[i].Employee = this.GetContractEmployee((int)contracts[i].ID);
        }
      }

      return contracts;
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
