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
    private int manager;

    /// <summary>
    /// Backing field for <see cref="Description"/>.
    /// </summary>
    private string description;

    /// <summary>
    /// Backing field for <see cref="Employees"/>.
    /// </summary>
    private IEnumerable<int> employees;

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
      get { return this.costCenter; }
      set { this.SetProperty(ref this.costCenter, value); }
    }

    /// <inheritdoc/>
    public int Manager
    {
      get { return this.manager; }
      set { this.SetProperty(ref this.manager, value); }
    }

    /// <inheritdoc/>
    public string Description
    {
      get { return this.description; }
      set { this.SetProperty(ref this.description, value); }
    }

    /// <inheritdoc/>
    public IEnumerable<int> Employees
    {
      get { return this.employees; }
      set { this.SetProperty(ref this.employees, value); }
    }

    #endregion Properties
  }
}
