namespace Gamadu.PVA.Core.DataAccess
{
  using Gamadu.PVA.Core.Models;
  using System.Collections.Generic;

  /// <summary>
  /// Interface for the data access for <see cref="IContract"/> objects.
  /// </summary>
  public interface IContractDataAccess
  {
    #region Single

    /// <summary>
    /// Saves a <see cref="IContract"/>
    /// </summary>
    /// <param name="contract"></param>
    /// <returns>Number of affected rows.</returns>
    int SaveContract(IContract contract);

    /// <summary>
    /// Updates a <see cref="IContract"/>
    /// </summary>
    /// <param name="contract"></param>
    /// <returns>Number of affected rows.</returns>
    int UpdateContract(IContract contract);

    /// <summary>
    /// Deletes a <see cref="IContract"/>
    /// </summary>
    /// <param name="id"></param>
    /// <returns>Number of affected rows.</returns>
    int DeleteContract(IIdentifiable id);

    /// <summary>
    /// Gets a <see cref="IContract"/>
    /// </summary>
    /// <param name="id"></param>
    /// <returns>The <see cref="IContract"/> object.</returns>
    IContract GetContract(IIdentifiable id);

    /// <summary>
    /// Deletes a <see cref="IContract"/>
    /// </summary>
    /// <param name="id"></param>
    /// <returns>Number of affected rows.</returns>
    int DeleteContract(int id);

    /// <summary>
    /// Gets a <see cref="IContract"/>
    /// </summary>
    /// <param name="id"></param>
    /// <returns>The <see cref="IContract"/> object.</returns>
    IContract GetContract(int id);

    #endregion Single

    #region Many

    /// <summary>
    /// Saves many <see cref="IContract"/>
    /// </summary>
    /// <param name="contracts"></param>
    /// <returns>Number of affected rows.</returns>
    int SaveContracts(IEnumerable<IContract> contracts);

    /// <summary>
    /// Updates many <see cref="IContract"/>
    /// </summary>
    /// <param name="contracts"></param>
    /// <returns>Number of affected rows.</returns>
    int UpdateContracts(IEnumerable<IContract> contracts);

    /// <summary>
    /// Deletes many <see cref="IContract"/>
    /// </summary>
    /// <param name="ids"></param>
    /// <returns>Number of affected rows.</returns>
    int DeleteContracts(IEnumerable<IIdentifiable> ids);

    /// <summary>
    /// Gets many <see cref="IContract"/>
    /// </summary>
    /// <param name="ids"></param>
    /// <returns>The collection of <see cref="IContract"/> objects.</returns>
    IEnumerable<IContract> GetContracts(IEnumerable<IIdentifiable> ids);

    /// <summary>
    /// Deletes many <see cref="IContract"/>
    /// </summary>
    /// <param name="ids"></param>
    /// <returns>Number of affected rows.</returns>
    int DeleteContracts(IEnumerable<int> ids);

    /// <summary>
    /// Gets many <see cref="IContract"/>
    /// </summary>
    /// <param name="ids"></param>
    /// <returns>The collection of <see cref="IContract"/> objects.</returns>
    IEnumerable<IContract> GetContracts(IEnumerable<int> ids);

    #endregion Many

    #region All

    /// <summary>
    /// Deletes all <see cref="IContract"/>
    /// </summary>
    /// <returns>Number of affected rows.</returns>
    IEnumerable<IContract> GetContracts();

    /// <summary>
    /// Gets all <see cref="IContract"/>
    /// </summary>
    /// <returns>The collection of <see cref="IContract"/> objects.</returns>
    int DeleteContracts();

    #endregion All
  }
}