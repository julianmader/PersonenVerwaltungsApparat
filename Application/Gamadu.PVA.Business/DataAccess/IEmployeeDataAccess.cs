namespace Gamadu.PVA.Core.DataAccess
{
  using Gamadu.PVA.Core.Models;
  using System.Collections.Generic;

  /// <summary>
  /// Interface for the data access for <see cref="IEmployee"/> objects.
  /// </summary>
  public interface IEmployeeDataAccess
  {
    #region Single

    /// <summary>
    /// Saves a <see cref="IEmployee"/>
    /// </summary>
    /// <param name="person"></param>
    /// <returns>Number of affected rows.</returns>
    int SaveEmployee(IEmployee person);

    /// <summary>
    /// Updates a <see cref="IEmployee"/>
    /// </summary>
    /// <param name="person"></param>
    /// <returns>Number of affected rows.</returns>
    int UpdateEmployee(IEmployee person);

    /// <summary>
    /// Deletes a <see cref="IEmployee"/>
    /// </summary>
    /// <param name="id"></param>
    /// <returns>Number of affected rows.</returns>
    int DeleteEmployee(IIdentifiable id);

    /// <summary>
    /// Gets a <see cref="IEmployee"/>
    /// </summary>
    /// <param name="id"></param>
    /// <returns>The <see cref="IEmployee"/> object.</returns>
    IEmployee GetEmployee(IIdentifiable id);

    /// <summary>
    /// Deletes a <see cref="IEmployee"/>
    /// </summary>
    /// <param name="id"></param>
    /// <returns>Number of affected rows.</returns>
    int DeleteEmployee(int id);

    /// <summary>
    /// Gets a <see cref="IEmployee"/>
    /// </summary>
    /// <param name="id"></param>
    /// <returns>The <see cref="IEmployee"/> object.</returns>
    IEmployee GetEmployee(int id);

    #endregion Single

    #region Many

    /// <summary>
    /// Saves many <see cref="IEmployee"/>
    /// </summary>
    /// <param name="persons"></param>
    /// <returns>Number of affected rows.</returns>
    int SaveEmployees(IEnumerable<IEmployee> persons);

    /// <summary>
    /// Updates many <see cref="IEmployee"/>
    /// </summary>
    /// <param name="persons"></param>
    /// <returns>Number of affected rows.</returns>
    int UpdateEmployees(IEnumerable<IEmployee> persons);

    /// <summary>
    /// Deletes many <see cref="IEmployee"/>
    /// </summary>
    /// <param name="ids"></param>
    /// <returns>Number of affected rows.</returns>
    int DeleteEmployees(IEnumerable<IIdentifiable> ids);

    /// <summary>
    /// Gets many <see cref="IEmployee"/>
    /// </summary>
    /// <param name="ids"></param>
    /// <returns>The collection of <see cref="IEmployee"/> objects.</returns>
    IEnumerable<IEmployee> GetEmployees(IEnumerable<IIdentifiable> ids);

    /// <summary>
    /// Deletes many <see cref="IEmployee"/>
    /// </summary>
    /// <param name="ids"></param>
    /// <returns>Number of affected rows.</returns>
    int DeleteEmployees(IEnumerable<int> ids);

    /// <summary>
    /// Gets many <see cref="IEmployee"/>
    /// </summary>
    /// <param name="ids"></param>
    /// <returns>The collection of <see cref="IEmployee"/> objects.</returns>
    IEnumerable<IEmployee> GetEmployees(IEnumerable<int> ids);

    #endregion Many

    #region All

    /// <summary>
    /// Deletes all <see cref="IEmployee"/>
    /// </summary>
    /// <returns>Number of affected rows.</returns>
    int DeleteEmployees();

    /// <summary>
    /// Gets all <see cref="IEmployee"/>
    /// </summary>
    /// <returns>The collection of <see cref="IEmployee"/> objects.</returns>
    IEnumerable<IEmployee> GetEmployees();

    #endregion All
  }
}