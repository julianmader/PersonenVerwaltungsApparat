namespace Gamadu.PVA.Business.DataAccess
{
  using Gamadu.PVA.Business.Models;
  using System.Collections.Generic;

  /// <summary>
  /// Interface for the data access for <see cref="IPerson"/> objects.
  /// </summary>
  public interface IPersonDataAccess
  {
    #region Single

    /// <summary>
    /// Saves a <see cref="IPerson"/>
    /// </summary>
    /// <param name="person"></param>
    /// <returns>Number of affected rows.</returns>
    int SavePerson(IPerson person);

    /// <summary>
    /// Updates a <see cref="IPerson"/>
    /// </summary>
    /// <param name="person"></param>
    /// <returns>Number of affected rows.</returns>
    int UpdatePerson(IPerson person);

    /// <summary>
    /// Deletes a <see cref="IPerson"/>
    /// </summary>
    /// <param name="id"></param>
    /// <returns>Number of affected rows.</returns>
    int DeletePerson(IIdentifiable id);

    /// <summary>
    /// Gets a <see cref="IPerson"/>
    /// </summary>
    /// <param name="id"></param>
    /// <returns>The <see cref="IPerson"/> object.</returns>
    IPerson GetPerson(IIdentifiable id);

    /// <summary>
    /// Deletes a <see cref="IPerson"/>
    /// </summary>
    /// <param name="id"></param>
    /// <returns>Number of affected rows.</returns>
    int DeletePerson(int id);

    /// <summary>
    /// Gets a <see cref="IPerson"/>
    /// </summary>
    /// <param name="id"></param>
    /// <returns>The <see cref="IPerson"/> object.</returns>
    IPerson GetPerson(int id);

    #endregion Single

    #region Many

    /// <summary>
    /// Saves many <see cref="IPerson"/>
    /// </summary>
    /// <param name="persons"></param>
    /// <returns>Number of affected rows.</returns>
    int SavePersons(IEnumerable<IPerson> persons);

    /// <summary>
    /// Updates many <see cref="IPerson"/>
    /// </summary>
    /// <param name="persons"></param>
    /// <returns>Number of affected rows.</returns>
    int UpdatePersons(IEnumerable<IPerson> persons);

    /// <summary>
    /// Deletes many <see cref="IPerson"/>
    /// </summary>
    /// <param name="ids"></param>
    /// <returns>Number of affected rows.</returns>
    int DeletePersons(IEnumerable<IIdentifiable> ids);

    /// <summary>
    /// Gets many <see cref="IPerson"/>
    /// </summary>
    /// <param name="ids"></param>
    /// <returns>The collection of <see cref="IPerson"/> objects.</returns>
    IEnumerable<IPerson> GetPersons(IEnumerable<IIdentifiable> ids);

    /// <summary>
    /// Deletes many <see cref="IPerson"/>
    /// </summary>
    /// <param name="ids"></param>
    /// <returns>Number of affected rows.</returns>
    int DeletePersons(IEnumerable<int> ids);

    /// <summary>
    /// Gets many <see cref="IPerson"/>
    /// </summary>
    /// <param name="ids"></param>
    /// <returns>The collection of <see cref="IPerson"/> objects.</returns>
    IEnumerable<IPerson> GetPersons(IEnumerable<int> ids);

    #endregion Many

    #region All

    /// <summary>
    /// Deletes all <see cref="IPerson"/>
    /// </summary>
    /// <returns>Number of affected rows.</returns>
    int DeletePersons();

    /// <summary>
    /// Gets all <see cref="IPerson"/>
    /// </summary>
    /// <returns>The collection of <see cref="IPerson"/> objects.</returns>
    IEnumerable<IPerson> GetPersons();

    #endregion All
  }
}
