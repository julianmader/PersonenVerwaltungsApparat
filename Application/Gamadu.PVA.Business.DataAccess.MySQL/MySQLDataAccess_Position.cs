namespace Gamadu.PVA.Business.DataAccess.MySQL
{
  using Dapper;
  using Gamadu.PVA.Business.Models;
  using System.Collections.Generic;
  using System.Data;
  using System.Linq;

  public partial class MySQLDataAccess
  {
    #region Position

    /// <inheritdoc/>
    public int SavePosition(IPosition position)
    {
      string sql = "SavePosition";
      int affectedRows = 0;

      using (IDbConnection connection = this.GetDbConnection())
      {
        affectedRows = connection.Execute(sql,
          new
          {
            Matchcode = position.Matchcode?.ToUpper(),
            Name = position.Name,
            Description = position.Description
          }, commandType: CommandType.StoredProcedure);
      }

      affectedRows += this.SavePositionEmployees(position);

      return affectedRows;
    }

    /// <summary>
    /// Saves the employees of a position.
    /// </summary>
    /// <param name="position">The position to save.</param>
    /// <returns>The amount of affected rows.</returns>
    private int SavePositionEmployees(IPosition position)
    {
      if (position == null)
        return 0;

      if (!position.Employees.Any())
        return 0;

      string sql = "SavePositionEmployees";

      int affectedRows = 0;

      int? positionID = this.GetPositionDatabaseID(position);

      if (positionID == null) return 0;

      using (IDbConnection connection = this.GetDbConnection())
      {

        foreach (int id in position.Employees)
        {
          affectedRows += connection.Execute(sql,
            new
            {
              P_ID = (int)positionID,
              E_ID = id,
            }, commandType: CommandType.StoredProcedure);
        }
      }

      return affectedRows;
    }

    /// <summary>
    /// Gets a position's database ID.
    /// </summary>
    /// <param name="position">The position</param>
    /// <returns>The ID or null.</returns>
    private int? GetPositionDatabaseID(IPosition position)
    {
      if (position == null) return null;

      string sql = "GetPositionID";

      int? id = null;

      using (IDbConnection connection = this.GetDbConnection())
      {
        id = connection.ExecuteScalar<int?>(sql,
          new
          {
            Matchcode = position.Matchcode?.ToUpper()
          }, commandType: CommandType.StoredProcedure);
      }

      return id;
    }

    /// <inheritdoc/>
    public int UpdatePosition(IPosition position)
    {
      string sql = "UpdatePosition";
      int affectedRows = 0;

      using (IDbConnection connection = this.GetDbConnection())
      {
        affectedRows = connection.Execute(sql,
          new
          {
            P_ID = position.ID,
            Matchcode = position.Matchcode?.ToUpper(),
            Name = position.Name,
            Description = position.Description
          }, commandType: CommandType.StoredProcedure);
      }

      affectedRows += this.SavePositionEmployees(position);

      return affectedRows;
    }

    /// <inheritdoc/>
    public int DeletePosition(IIdentifiable id)
    {
      return this.DeletePosition((int)id.ID);
    }

    /// <inheritdoc/>
    public IPosition GetPosition(IIdentifiable id)
    {
      return this.GetPosition((int)id.ID);
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

        if (position != null)
        {
          position.Employees = this.GetPositionEmployees(id);
        }

        return position;
      }
    }

    /// <summary>
    /// Gets the IDs of the employees associated with the position.
    /// </summary>
    /// <param name="id">The position id.</param>
    /// <returns></returns>
    private IEnumerable<int> GetPositionEmployees(int id)
    {
      string sql = "GetPositionEmployees";

      using (IDbConnection connection = this.GetDbConnection())
      {
        IEnumerable<int> employees = connection.Query<int>(sql,
          new
          {
            P_ID = id
          }, commandType: CommandType.StoredProcedure);

        return employees;
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
      List<IPosition> positions = new List<IPosition>();

      using (IDbConnection connection = this.GetDbConnection())
      {
        positions = new List<IPosition>(connection.Query<Position>(sql, commandType: CommandType.StoredProcedure));
      }

      if (positions?.Any() == true)
      {
        for (int i = 0; i < positions.Count(); i++)
        {
          positions[i].Employees = this.GetPositionEmployees((int)positions[i].ID);
        }
      }

      return positions;
    }

    #endregion Position
  }
}
