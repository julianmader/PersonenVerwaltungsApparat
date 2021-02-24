namespace Gamadu.PVA.Business.Models
{
  using Gamadu.PVA.Business.Interfaces;
  using System.Collections.Generic;

  public class Position : IdentifiableBase, IPosition
  {
    #region Backing Fields

    /// <summary>
    /// Backing field for <see cref="Name"/>.
    /// </summary>
    private string name;

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
