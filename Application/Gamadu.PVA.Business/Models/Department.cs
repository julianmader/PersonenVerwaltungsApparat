using Gamadu.PVA.Business.Interfaces;
using System.Collections.Generic;

namespace Gamadu.PVA.Business.Models
{
  public class Department : IdentifiableBase, IDepartment
  {
    #region Backing Fields

    /// <summary>
    /// Backing field for <see cref="Name"/>.
    /// </summary>
    private string name;

    /// <summary>
    /// Backing field for <see cref="CostCenter"/>
    /// </summary>
    private string costCenter;

    /// <summary>
    /// Backing field for <see cref="Manager"/>
    /// </summary>
    private IPerson manager;

    /// <summary>
    /// Backing field for <see cref="Description"/>.
    /// </summary>
    private string description;

    /// <summary>
    /// Backing field for <see cref="Employees"/>.
    /// </summary>
    private IEnumerable<IPerson> employees;

    #endregion Backing Fields

    #region Properties

    /// <inheritdoc/>
    public string Name
    {
      get { return this.name; }
      set { this.SetProperty(ref this.name, value); }
    }

    /// <inheritdoc/>
    public string CostCenter
    {
      get { return costCenter; }
      set { SetProperty(ref costCenter, value); }
    }

    /// <inheritdoc/>
    public IPerson Manager
    {
      get { return manager; }
      set { SetProperty(ref manager, value); }
    }

    /// <inheritdoc/>
    public string Description
    {
      get { return this.description; }
      set { this.SetProperty(ref this.description, value); }
    }

    /// <inheritdoc/>
    public IEnumerable<IPerson> Employees
    {
      get { return employees; }
      set { SetProperty(ref employees, value); }
    }

    #endregion Properties
  }
}
