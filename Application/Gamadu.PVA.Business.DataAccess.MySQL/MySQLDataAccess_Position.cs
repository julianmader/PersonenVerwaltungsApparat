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

    public int SavePosition(IPosition position)
    {
      throw new NotImplementedException();
    }

    public int UpdatePosition(IPosition position)
    {
      throw new NotImplementedException();
    }

    public int DeletePosition(IIdentifiable id)
    {
      throw new NotImplementedException();
    }

    public IPosition GetPosition(IIdentifiable id)
    {
      throw new NotImplementedException();
    }

    public int DeletePosition(int id)
    {
      throw new NotImplementedException();
    }

    public IPosition GetPosition(int id)
    {
      throw new NotImplementedException();
    }

    public int SavePositions(IEnumerable<IPosition> positions)
    {
      throw new NotImplementedException();
    }

    public int UpdatePositions(IEnumerable<IPosition> positions)
    {
      throw new NotImplementedException();
    }

    public int DeletePositions(IEnumerable<IIdentifiable> ids)
    {
      throw new NotImplementedException();
    }

    public IEnumerable<IPosition> GetPositions(IEnumerable<IIdentifiable> ids)
    {
      throw new NotImplementedException();
    }

    public int DeletePositions(IEnumerable<int> ids)
    {
      throw new NotImplementedException();
    }

    public IEnumerable<IPosition> GetPositions(IEnumerable<int> ids)
    {
      throw new NotImplementedException();
    }

    public int DeletePositions()
    {
      throw new NotImplementedException();
    }

    public IEnumerable<IPosition> GetPositions()
    {
      throw new NotImplementedException();
    }

    #endregion Position
  }
}
