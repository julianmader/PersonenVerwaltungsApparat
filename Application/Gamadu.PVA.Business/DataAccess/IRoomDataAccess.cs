namespace Gamadu.PVA.Business.DataAccess
{
  using Gamadu.PVA.Business.Models;
  using System.Collections.Generic;

  /// <summary>
  /// Interface for the data access for <see cref="IRoom"/> objects.
  /// </summary>
  public interface IRoomDataAccess
  {
    #region Single

    /// <summary>
    /// Saves a <see cref="IRoom"/>
    /// </summary>
    /// <param name="room"></param>
    /// <returns>Number of affected rows.</returns>
    int SaveRoom(IRoom room);

    /// <summary>
    /// Updates a <see cref="IRoom"/>
    /// </summary>
    /// <param name="room"></param>
    /// <returns>Number of affected rows.</returns>
    int UpdateRoom(IRoom room);

    /// <summary>
    /// Deletes a <see cref="IRoom"/>
    /// </summary>
    /// <param name="id"></param>
    /// <returns>Number of affected rows.</returns>
    int DeleteRoom(IIdentifiable id);

    /// <summary>
    /// Gets a <see cref="IRoom"/>
    /// </summary>
    /// <param name="id"></param>
    /// <returns>The <see cref="IRoom"/> object.</returns>
    IRoom GetRoom(IIdentifiable id);

    /// <summary>
    /// Deletes a <see cref="IRoom"/>
    /// </summary>
    /// <param name="id"></param>
    /// <returns>Number of affected rows.</returns>
    int DeleteRoom(int id);

    /// <summary>
    /// Gets a <see cref="IRoom"/>
    /// </summary>
    /// <param name="id"></param>
    /// <returns>The <see cref="IRoom"/> object.</returns>
    IRoom GetRoom(int id);

    #endregion Single

    #region Many

    /// <summary>
    /// Saves many <see cref="IRoom"/>
    /// </summary>
    /// <param name="rooms"></param>
    /// <returns>Number of affected rows.</returns>
    int SaveRooms(IEnumerable<IRoom> rooms);

    /// <summary>
    /// Updates many <see cref="IRoom"/>
    /// </summary>
    /// <param name="rooms"></param>
    /// <returns>Number of affected rows.</returns>
    int UpdateRooms(IEnumerable<IRoom> rooms);

    /// <summary>
    /// Deletes many <see cref="IRoom"/>
    /// </summary>
    /// <param name="ids"></param>
    /// <returns>Number of affected rows.</returns>
    int DeleteRooms(IEnumerable<IIdentifiable> ids);

    /// <summary>
    /// Gets many <see cref="IRoom"/>
    /// </summary>
    /// <param name="ids"></param>
    /// <returns>The collection of <see cref="IRoom"/> objects.</returns>
    IEnumerable<IRoom> GetRooms(IEnumerable<IIdentifiable> ids);

    /// <summary>
    /// Deletes many <see cref="IRoom"/>
    /// </summary>
    /// <param name="ids"></param>
    /// <returns>Number of affected rows.</returns>
    int DeleteRooms(IEnumerable<int> ids);

    /// <summary>
    /// Gets many <see cref="IRoom"/>
    /// </summary>
    /// <param name="ids"></param>
    /// <returns>The collection of <see cref="IRoom"/> objects.</returns>
    IEnumerable<IRoom> GetRooms(IEnumerable<int> ids);

    #endregion Many

    #region All

    /// <summary>
    /// Deletes all <see cref="IRoom"/>
    /// </summary>
    /// <returns>Number of affected rows.</returns>
    int DeleteRooms();

    /// <summary>
    /// Gets all <see cref="IRoom"/>
    /// </summary>
    /// <returns>The collection of <see cref="IRoom"/> objects.</returns>
    IEnumerable<IRoom> GetRooms();

    #endregion All
  }
}
