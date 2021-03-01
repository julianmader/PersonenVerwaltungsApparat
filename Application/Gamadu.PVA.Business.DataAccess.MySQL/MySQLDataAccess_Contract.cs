namespace Gamadu.PVA.Business.DataAccess.MySQL
{
  using Dapper;
  using Gamadu.PVA.Business.Models;
  using System.Collections.Generic;
  using System.Data;

  public partial class MySQLDataAccess
  {
    #region Contract

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
            Employee = contract.Employee,
            Description = contract.Description,
            HasEnd = contract.HasEnd
          }, commandType: CommandType.StoredProcedure);
        return affectedRows;
      }
    }

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
            Employee = contract.Employee,
            Description = contract.Description,
            HasEnd = contract.HasEnd
          }, commandType: CommandType.StoredProcedure);
        return affectedRows;
      }
    }

    public int DeleteContract(IIdentifiable id)
    {
      return this.DeleteContract(id.ID);
    }

    public IContract GetContract(IIdentifiable id)
    {
      return this.GetContract(id.ID);
    }

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

    public int SaveContracts(IEnumerable<IContract> contracts)
    {
      int affectedRows = 0;

      foreach (IContract contract in contracts)
      {
        affectedRows += this.SaveContract(contract);
      }

      return affectedRows;
    }

    public int UpdateContracts(IEnumerable<IContract> contracts)
    {
      int affectedRows = 0;

      foreach (IContract contract in contracts)
      {
        affectedRows += this.UpdateContract(contract);
      }

      return affectedRows;
    }

    public int DeleteContracts(IEnumerable<IIdentifiable> ids)
    {
      int affectedRows = 0;

      foreach (IIdentifiable id in ids)
      {
        affectedRows += this.DeleteContract(id);
      }

      return affectedRows;
    }

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

    public int DeleteContracts(IEnumerable<int> ids)
    {
      int affectedRows = 0;

      foreach (int id in ids)
      {
        affectedRows += this.DeleteContract(id);
      }

      return affectedRows;
    }

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

    public IEnumerable<IContract> GetContracts()
    {
      string sql = "GetAllContracts";

      using (IDbConnection connection = this.GetDbConnection())
      {
        IEnumerable<IContract> contracts = connection.Query<Contract>(sql, commandType: CommandType.StoredProcedure);

        return contracts;
      }
    }

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
