namespace Gamadu.PVA.Core.DataAccess
{
  using Gamadu.PVA.Core.Models;
  using System.Collections.Generic;

  /// <summary>
  /// Interface for the data access for <see cref="IPosition"/> objects.
  /// </summary>
  public interface IPositionDataAccess
  {
    #region Single

    /// <summary>
    /// Saves a <see cref="IPosition"/>
    /// </summary>
    /// <param name="position"></param>
    /// <returns>Number of affected rows.</returns>
    int SavePosition(IPosition position);

    /// <summary>
    /// Updates a <see cref="IPosition"/>
    /// </summary>
    /// <param name="position"></param>
    /// <returns>Number of affected rows.</returns>
    int UpdatePosition(IPosition position);

    /// <summary>
    /// Deletes a <see cref="IPosition"/>
    /// </summary>
    /// <param name="id"></param>
    /// <returns>Number of affected rows.</returns>
    int DeletePosition(IIdentifiable id);

    /// <summary>
    /// Gets a <see cref="IPosition"/>
    /// </summary>
    /// <param name="id"></param>
    /// <returns>The <see cref="IPosition"/> object.</returns>
    IPosition GetPosition(IIdentifiable id);

    /// <summary>
    /// Deletes a <see cref="IPosition"/>
    /// </summary>
    /// <param name="id"></param>
    /// <returns>Number of affected rows.</returns>
    int DeletePosition(int id);

    /// <summary>
    /// Gets a <see cref="IPosition"/>
    /// </summary>
    /// <param name="id"></param>
    /// <returns>The <see cref="IPosition"/> object.</returns>
    IPosition GetPosition(int id);

    #endregion Single

    #region Many

    /// <summary>
    /// Saves many <see cref="IPosition"/>
    /// </summary>
    /// <param name="positions"></param>
    /// <returns>Number of affected rows.</returns>
    int SavePositions(IEnumerable<IPosition> positions);

    /// <summary>
    /// Updates many <see cref="IPosition"/>
    /// </summary>
    /// <param name="positions"></param>
    /// <returns>Number of affected rows.</returns>
    int UpdatePositions(IEnumerable<IPosition> positions);

    /// <summary>
    /// Deletes many <see cref="IPosition"/>
    /// </summary>
    /// <param name="ids"></param>
    /// <returns>Number of affected rows.</returns>
    int DeletePositions(IEnumerable<IIdentifiable> ids);

    /// <summary>
    /// Gets many <see cref="IPosition"/>
    /// </summary>
    /// <param name="ids"></param>
    /// <returns>The collection of <see cref="IPosition"/> objects.</returns>
    IEnumerable<IPosition> GetPositions(IEnumerable<IIdentifiable> ids);

    /// <summary>
    /// Deletes many <see cref="IPosition"/>
    /// </summary>
    /// <param name="ids"></param>
    /// <returns>Number of affected rows.</returns>
    int DeletePositions(IEnumerable<int> ids);

    /// <summary>
    /// Gets many <see cref="IPosition"/>
    /// </summary>
    /// <param name="ids"></param>
    /// <returns>The collection of <see cref="IPosition"/> objects.</returns>
    IEnumerable<IPosition> GetPositions(IEnumerable<int> ids);

    #endregion Many

    #region All

    /// <summary>
    /// Deletes all <see cref="IPosition"/>
    /// </summary>
    /// <returns>Number of affected rows.</returns>
    int DeletePositions();

    /// <summary>
    /// Gets all <see cref="IPosition"/>
    /// </summary>
    /// <returns>The collection of <see cref="IPosition"/> objects.</returns>
    IEnumerable<IPosition> GetPositions();

    #endregion All
  }
}