namespace Gamadu.PVA.Business.DataAccess.MySQL
{
  using Dapper;
  using Gamadu.PVA.Business.Models;
  using System;
  using System.Collections.Generic;
  using System.Data;

  public partial class MySQLDataAccess
  {
    #region Position

    /// <inheritdoc/>
    public int SavePosition(IPosition position)
    {
      string sql = "SavePosition";

      using (IDbConnection connection = this.GetDbConnection())
      {
        int affectedRows = connection.Execute(sql,
          new
          {
            Matchcode = position.Matchcode?.ToUpper(),
            Name = position.Name,
            Description = position.Description
          }, commandType: CommandType.StoredProcedure);
        return affectedRows;
      }
    }

    /// <inheritdoc/>
    public int UpdatePosition(IPosition position)
    {
      string sql = "UpdatePosition";

      using (IDbConnection connection = this.GetDbConnection())
      {
        int affectedRows = connection.Execute(sql,
          new
          {
            P_ID = position.ID,
            Matchcode = position.Matchcode?.ToUpper(),
            Name = position.Name,
            Description = position.Description
          }, commandType: CommandType.StoredProcedure);
        return affectedRows;
      }
    }

    /// <inheritdoc/>
    public int DeletePosition(IIdentifiable id)
    {
      return this.DeletePosition(id.ID);
    }

    /// <inheritdoc/>
    public IPosition GetPosition(IIdentifiable id)
    {
      return this.GetPosition(id.ID);
    }

    /// <inheritdoc/>
    public int DeletePosition(int id)
    {
      string sql = "DeletePosition";

      using (IDbConnection connection = this.GetDbConnection())
      {
        int affectedRows = connection.Execute(sql,
          new
          {
            P_ID = id
          }, commandType: CommandType.StoredProcedure);
        return affectedRows;
      }
    }

    /// <inheritdoc/>
    public IPosition GetPosition(int id)
    {
      string sql = "GetPosition";

      using (IDbConnection connection = this.GetDbConnection())
      {
        IPosition position = connection.QueryFirst<Position>(sql,
          new
          {
            P_ID = id
          }, commandType: CommandType.StoredProcedure);

        return position;
      }
    }

    /// <inheritdoc/>
    public int SavePositions(IEnumerable<IPosition> positions)
    {
      int affectedRows = 0;

      foreach (IPosition position in positions)
      {
        affectedRows += this.SavePosition(position);
      }

      return affectedRows;
    }

    /// <inheritdoc/>
    public int UpdatePositions(IEnumerable<IPosition> positions)
    {
      int affectedRows = 0;

      foreach (IPosition position in positions)
      {
        affectedRows += this.UpdatePosition(position);
      }

      return affectedRows;
    }

    /// <inheritdoc/>
    public int DeletePositions(IEnumerable<IIdentifiable> ids)
    {
      int affectedRows = 0;

      foreach (IIdentifiable id in ids)
      {
        affectedRows += this.DeletePosition(id);
      }

      return affectedRows;
    }

    /// <inheritdoc/>
    public IEnumerable<IPosition> GetPositions(IEnumerable<IIdentifiable> ids)
    {
      List<IPosition> positions = new List<IPosition>();

      foreach (IIdentifiable id in ids)
      {
        IPosition position = this.GetPosition(id);

        if (position != null)
        {
          positions.Add(position);
        }
      }

      return positions;
    }

    /// <inheritdoc/>
    public int DeletePositions(IEnumerable<int> ids)
    {
      int affectedRows = 0;

      foreach (int id in ids)
      {
        affectedRows += this.DeletePosition(id);
      }

      return affectedRows;
    }

    /// <inheritdoc/>
    public IEnumerable<IPosition> GetPositions(IEnumerable<int> ids)
    {
      List<IPosition> positions = new List<IPosition>();

      foreach (int id in ids)
      {
        IPosition position = this.GetPosition(id);

        if (position != null)
        {
          positions.Add(position);
        }
      }

      return positions;
    }

    /// <inheritdoc/>
    public int DeletePositions()
    {
      string sql = "DeleteAllPositions";

      using (IDbConnection connection = this.GetDbConnection())
      {
        int affectedRows = connection.Execute(sql, commandType: CommandType.StoredProcedure);

        return affectedRows;
      }
    }

    /// <inheritdoc/>
    public IEnumerable<IPosition> GetPositions()
    {
      string sql = "GetAllPositions";

      using (IDbConnection connection = this.GetDbConnection())
      {
        IEnumerable<IPosition> positions = connection.Query<Position>(sql, commandType: CommandType.StoredProcedure);

        return positions;
      }
    }

    #endregion Position
  }
}
