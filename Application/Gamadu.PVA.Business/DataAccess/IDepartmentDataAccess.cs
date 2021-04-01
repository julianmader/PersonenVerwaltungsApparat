namespace Gamadu.PVA.Core.DataAccess
{
  using Gamadu.PVA.Core.Models;
  using System.Collections.Generic;

  /// <summary>
  /// Interface for the data access for <see cref="IDepartment"/> objects.
  /// </summary>
  public interface IDepartmentDataAccess
  {
    #region Single

    /// <summary>
    /// Saves a <see cref="IDepartment"/>
    /// </summary>
    /// <param name="department"></param>
    /// <returns>Number of affected rows.</returns>
    int SaveDepartment(IDepartment department);

    /// <summary>
    /// Updates a <see cref="IDepartment"/>
    /// </summary>
    /// <param name="department"></param>
    /// <returns>Number of affected rows.</returns>
    int UpdateDepartment(IDepartment department);

    /// <summary>
    /// Deletes a <see cref="IDepartment"/>
    /// </summary>
    /// <param name="id"></param>
    /// <returns>Number of affected rows.</returns>
    int DeleteDepartment(IIdentifiable id);

    /// <summary>
    /// Gets a <see cref="IDepartment"/>
    /// </summary>
    /// <param name="id"></param>
    /// <returns>The <see cref="IDepartment"/> object.</returns>
    IDepartment GetDepartment(IIdentifiable id);

    /// <summary>
    /// Deletes a <see cref="IDepartment"/>
    /// </summary>
    /// <param name="id"></param>
    /// <returns>Number of affected rows.</returns>
    int DeleteDepartment(int id);

    /// <summary>
    /// Gets a <see cref="IDepartment"/>
    /// </summary>
    /// <param name="id"></param>
    /// <returns>The <see cref="IDepartment"/> object.</returns>
    IDepartment GetDepartment(int id);

    #endregion Single

    #region Many

    /// <summary>
    /// Saves many <see cref="IDepartment"/>
    /// </summary>
    /// <param name="departments"></param>
    /// <returns>Number of affected rows.</returns>
    int SaveDepartments(IEnumerable<IDepartment> departments);

    /// <summary>
    /// Updates many <see cref="IDepartment"/>
    /// </summary>
    /// <param name="departments"></param>
    /// <returns>Number of affected rows.</returns>
    int UpdateDepartments(IEnumerable<IDepartment> departments);

    /// <summary>
    /// Deletes many <see cref="IDepartment"/>
    /// </summary>
    /// <param name="ids"></param>
    /// <returns>Number of affected rows.</returns>
    int DeleteDepartments(IEnumerable<IIdentifiable> ids);

    /// <summary>
    /// Gets many <see cref="IDepartment"/>
    /// </summary>
    /// <param name="ids"></param>
    /// <returns>The collection of <see cref="IDepartment"/> objects.</returns>
    IEnumerable<IDepartment> GetDepartments(IEnumerable<IIdentifiable> ids);

    /// <summary>
    /// Deletes many <see cref="IDepartment"/>
    /// </summary>
    /// <param name="ids"></param>
    /// <returns>Number of affected rows.</returns>
    int DeleteDepartments(IEnumerable<int> ids);

    /// <summary>
    /// Gets many <see cref="IDepartment"/>
    /// </summary>
    /// <param name="ids"></param>
    /// <returns>The collection of <see cref="IDepartment"/> objects.</returns>
    IEnumerable<IDepartment> GetDepartments(IEnumerable<int> ids);

    #endregion Many

    #region All

    /// <summary>
    /// Deletes all <see cref="IDepartment"/>
    /// </summary>
    /// <returns>Number of affected rows.</returns>
    int DeleteDepartments();

    /// <summary>
    /// Gets all <see cref="IDepartment"/>
    /// </summary>
    /// <returns>The collection of <see cref="IDepartment"/> objects.</returns>
    IEnumerable<IDepartment> GetDepartments();

    #endregion All
  }
}