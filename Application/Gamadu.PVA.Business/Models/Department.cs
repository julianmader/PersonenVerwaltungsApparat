namespace Gamadu.PVA.Core.Models
{
  using Gamadu.PVA.Core.Models.Bases;
  using System.Collections.Generic;
  using System.Linq;

  public class Department : ValidateableModelBase<IDepartment>, IDepartment
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
    private int? manager;

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
      get => this.name;
      set => this.SetProperty(ref this.name, value);
    }

    /// <inheritdoc/>
    public string CostCenter
    {
      get => this.costCenter;
      set => this.SetProperty(ref this.costCenter, value);
    }

    /// <inheritdoc/>
    public int? Manager
    {
      get => this.manager;
      set => this.SetProperty(ref this.manager, value);
    }

    /// <inheritdoc/>
    public string Description
    {
      get => this.description;
      set => this.SetProperty(ref this.description, value);
    }

    /// <inheritdoc/>
    public IEnumerable<int> Employees
    {
      get => this.employees;
      set => this.SetProperty(ref this.employees, value);
    }

    #endregion Properties

    #region Methods

    public override string ToString() => $"{this.Matchcode} - {this.Name}";

    public override void Validate() => this.Validate(this);

    public bool Equals(IDepartment other)
    {
      if (other == null) return false;

      if (this.Matchcode.ToUpper() != other.Matchcode.ToUpper()) return false;
      if (this.Name != other.Name) return false;
      if (this.CostCenter != other.CostCenter) return false;
      if (this.Description != other.Description) return false;
      if (this.Manager != other.Manager) return false;
      if (!this.Employees.SequenceEqual(other.Employees)) return false;

      return true;
    }

    public IDepartment MemberwiseCopy() => this.MemberwiseClone() as IDepartment;

    #endregion Methods
  }
}