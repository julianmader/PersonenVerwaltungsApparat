namespace Gamadu.PVA.Core.DataAccess.MySQL
{
  using Dapper;
  using Gamadu.PVA.Core.Models;
  using System.Collections.Generic;
  using System.Data;
  using System.Linq;

  public partial class MySQLDataAccess
  {
    #region Room

    /// <inheritdoc/>
    public int SaveRoom(IRoom room)
    {
      string sql = "SaveRoom";

      int affectedRows = 0;

      using (IDbConnection connection = this.GetDbConnection())
      {
        affectedRows += connection.Execute(sql,
          new
          {
            Matchcode = room.Matchcode?.ToUpper(),
            Name = room.Name?.Trim(),
            RoomNumber = room.RoomNumber,
            FloorNumber = room.FloorNumber,
            Size = room.Size,
            Description = room.Description?.Trim()
          }, commandType: CommandType.StoredProcedure);
      }

      affectedRows += this.SaveRoomEmployees(room);

      return affectedRows;
    }

    /// <summary>
    /// Saves the employees of a room in the connection table.
    /// </summary>
    /// <param name="room">The room to save.</param>
    /// <returns>The amount of affected rows.</returns>
    private int SaveRoomEmployees(IRoom room)
    {
      if (room == null)
        return 0;

      if (!room.Employees.Any())
        return 0;

      string sql = "SaveRoomEmployees";

      int affectedRows = 0;

      int? roomID = this.GetRoomDatabaseID(room);

      if (roomID == null) return 0;

      using (IDbConnection connection = this.GetDbConnection())
      {
        foreach (int id in room.Employees)
        {
          affectedRows += connection.Execute(sql,
            new
            {
              R_ID = (int)roomID,
              E_ID = id,
            }, commandType: CommandType.StoredProcedure);
        }
      }

      return affectedRows;
    }

    /// <summary>
    /// Gets a room's database ID.
    /// </summary>
    /// <param name="room">The room</param>
    /// <returns>The ID or null.</returns>
    private int? GetRoomDatabaseID(IRoom room)
    {
      if (room == null) return null;

      string sql = "GetRoomID";

      int? id = null;

      using (IDbConnection connection = this.GetDbConnection())
      {
        id = connection.ExecuteScalar<int?>(sql,
          new
          {
            Matchcode = room.Matchcode?.ToUpper()
          }, commandType: CommandType.StoredProcedure);
      }

      return id;
    }

    /// <inheritdoc/>
    public int UpdateRoom(IRoom room)
    {
      string sql = "UpdateRoom";

      int affectedRows = 0;

      using (IDbConnection connection = this.GetDbConnection())
      {
        affectedRows += connection.Execute(sql,
          new
          {
            R_ID = room.ID,
            Matchcode = room.Matchcode?.ToUpper(),
            Name = room.Name?.Trim(),
            RoomNumber = room.RoomNumber,
            FloorNumber = room.FloorNumber,
            Size = room.Size,
            Description = room.Description?.Trim()
          }, commandType: CommandType.StoredProcedure);
      }

      affectedRows += this.SaveRoomEmployees(room);

      return affectedRows;
    }

    /// <inheritdoc/>
    public int DeleteRoom(IIdentifiable id) => this.DeleteRoom((int)id.ID);

    /// <inheritdoc/>
    public IRoom GetRoom(IIdentifiable id) => this.GetRoom((int)id.ID);

    /// <inheritdoc/>
    public int DeleteRoom(int id)
    {
      string sql = "DeleteRoom";

      using (IDbConnection connection = this.GetDbConnection())
      {
        int affectedRows = connection.Execute(sql,
          new
          {
            R_ID = id
          }, commandType: CommandType.StoredProcedure);
        return affectedRows;
      }
    }

    /// <inheritdoc/>
    public IRoom GetRoom(int id)
    {
      string sql = "GetRoom";

      using (IDbConnection connection = this.GetDbConnection())
      {
        IRoom room = connection.QueryFirst<Room>(sql,
          new
          {
            R_ID = id
          }, commandType: CommandType.StoredProcedure);

        if (room != null)
        {
          room.Employees = this.GetRoomEmployees(id);
        }

        return room;
      }
    }

    /// <summary>
    /// Gets the IDs of the employees associated with the room.
    /// </summary>
    /// <param name="id">The room id.</param>
    /// <returns></returns>
    private IEnumerable<int> GetRoomEmployees(int id)
    {
      string sql = "GetRoomEmployees";

      using (IDbConnection connection = this.GetDbConnection())
      {
        IEnumerable<int> employees = connection.Query<int>(sql,
          new
          {
            R_ID = id
          }, commandType: CommandType.StoredProcedure);

        return employees;
      }
    }

    /// <inheritdoc/>
    public int SaveRooms(IEnumerable<IRoom> rooms)
    {
      int affectedRows = 0;

      foreach (IRoom room in rooms)
      {
        affectedRows += this.SaveRoom(room);
      }

      return affectedRows;
    }

    /// <inheritdoc/>
    public int UpdateRooms(IEnumerable<IRoom> rooms)
    {
      int affectedRows = 0;

      foreach (IRoom room in rooms)
      {
        affectedRows += this.UpdateRoom(room);
      }

      return affectedRows;
    }

    /// <inheritdoc/>
    public int DeleteRooms(IEnumerable<IIdentifiable> ids)
    {
      int affectedRows = 0;

      foreach (IIdentifiable id in ids)
      {
        affectedRows += this.DeleteRoom(id);
      }

      return affectedRows;
    }

    /// <inheritdoc/>
    public IEnumerable<IRoom> GetRooms(IEnumerable<IIdentifiable> ids)
    {
      List<IRoom> rooms = new List<IRoom>();

      foreach (IIdentifiable id in ids)
      {
        IRoom room = this.GetRoom(id);

        if (room != null)
        {
          rooms.Add(room);
        }
      }

      return rooms;
    }

    /// <inheritdoc/>
    public int DeleteRooms(IEnumerable<int> ids)
    {
      int affectedRows = 0;

      foreach (int id in ids)
      {
        affectedRows += this.DeleteRoom(id);
      }

      return affectedRows;
    }

    /// <inheritdoc/>
    public IEnumerable<IRoom> GetRooms(IEnumerable<int> ids)
    {
      List<IRoom> rooms = new List<IRoom>();

      foreach (int id in ids)
      {
        IRoom room = this.GetRoom(id);

        if (room != null)
        {
          rooms.Add(room);
        }
      }

      return rooms;
    }

    /// <inheritdoc/>
    public int DeleteRooms()
    {
      string sql = "DeleteAllRooms";

      using (IDbConnection connection = this.GetDbConnection())
      {
        int affectedRows = connection.Execute(sql, commandType: CommandType.StoredProcedure);

        return affectedRows;
      }
    }

    /// <inheritdoc/>
    public IEnumerable<IRoom> GetRooms()
    {
      string sql = "GetAllRooms";
      List<IRoom> rooms = new List<IRoom>();

      using (IDbConnection connection = this.GetDbConnection())
      {
        rooms = new List<IRoom>(connection.Query<Room>(sql, commandType: CommandType.StoredProcedure));
      }

      if (rooms?.Any() == true)
      {
        for (int i = 0; i < rooms.Count(); i++)
        {
          rooms[i].Employees = this.GetRoomEmployees((int)rooms[i].ID);
        }
      }

      return rooms;
    }

    #endregion Room
  }
}