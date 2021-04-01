namespace Gamadu.PVA.Core.Models
{
  using Gamadu.PVA.Core.Models.Bases;
  using System.Collections.Generic;

  public class Position : ValidateableModelBase<IPosition>, IPosition
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

    #region Methods

    public override string ToString()
    {
      return $"{this.Matchcode} - {this.Name}";
    }

    public override void Validate() => this.Validate(this);

    #endregion Methods
  }
}