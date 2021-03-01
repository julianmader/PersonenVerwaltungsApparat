namespace Gamadu.PVA.Business.DataAccess.MySQL
{
  using Dapper;
  using Gamadu.PVA.Business.Models;
  using System;
  using System.Collections.Generic;
  using System.Data;

  public partial class MySQLDataAccess
  {
    #region Room

    public int SaveRoom(IRoom room)
    {
      throw new NotImplementedException();
    }

    public int UpdateRoom(IRoom room)
    {
      throw new NotImplementedException();
    }

    public int DeleteRoom(IIdentifiable id)
    {
      throw new NotImplementedException();
    }

    public IRoom GetRoom(IIdentifiable id)
    {
      throw new NotImplementedException();
    }

    public int DeleteRoom(int id)
    {
      throw new NotImplementedException();
    }

    public IRoom GetRoom(int id)
    {
      throw new NotImplementedException();
    }

    public int SaveRooms(IEnumerable<IRoom> rooms)
    {
      throw new NotImplementedException();
    }

    public int UpdateRooms(IEnumerable<IRoom> rooms)
    {
      throw new NotImplementedException();
    }

    public int DeleteRooms(IEnumerable<IIdentifiable> ids)
    {
      throw new NotImplementedException();
    }

    public IEnumerable<IRoom> GetRooms(IEnumerable<IIdentifiable> ids)
    {
      throw new NotImplementedException();
    }

    public int DeleteRooms(IEnumerable<int> ids)
    {
      throw new NotImplementedException();
    }

    public IEnumerable<IRoom> GetRooms(IEnumerable<int> ids)
    {
      throw new NotImplementedException();
    }

    public int DeleteRooms()
    {
      throw new NotImplementedException();
    }

    public IEnumerable<IRoom> GetRooms()
    {
      throw new NotImplementedException();
    }

    #endregion Room
  }
}
