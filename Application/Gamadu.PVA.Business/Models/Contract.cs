namespace Gamadu.PVA.Core.Models
{
  using Gamadu.PVA.Core.Models.Bases;
  using System;
  using System.Collections.Generic;
  using System.Linq;

  public class Contract : ValidateableModelBase<IContract>, IContract
  {
    #region Backing Fields

    /// <summary>
    /// Backing field for <see cref="Name"/>.
    /// </summary>
    private string name;

    /// <summary>
    /// Backing field for <see cref="WorkTime"/>.
    /// </summary>
    private int? workTime;

    /// <summary>
    /// Backing field for <see cref="Holidays"/>.
    /// </summary>
    private int? holidays;

    /// <summary>
    /// Backing field for <see cref="Salary"/>.
    /// </summary>
    private int? salary;

    /// <summary>
    /// Backing field for <see cref="TrailEnd"/>.
    /// </summary>
    private DateTime? trailEnd;

    /// <summary>
    /// Backing field for <see cref="Start
    /// </summary>
    private DateTime? start;

    /// <summary>
    /// Backing field for <see cref="End"/>.
    /// </summary>
    private DateTime? end;

    /// <summary>
    /// Backing field for <see cref="HasEnd"/>.
    /// </summary>
    private bool hasEnd;

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
    public int? WorkTime
    {
      get => this.workTime;
      set => this.SetProperty(ref this.workTime, value);
    }

    /// <inheritdoc/>
    public int? Holidays
    {
      get => this.holidays;
      set => this.SetProperty(ref this.holidays, value);
    }

    /// <inheritdoc/>
    public int? Salary
    {
      get => this.salary;
      set => this.SetProperty(ref this.salary, value);
    }

    /// <inheritdoc/>
    public DateTime? Start
    {
      get => this.start;
      set => this.SetProperty(ref this.start, value);
    }

    /// <inheritdoc/>
    public DateTime? End
    {
      get => this.end;
      set => this.SetProperty(ref this.end, value);
    }

    /// <inheritdoc/>
    public bool HasEnd
    {
      get => this.hasEnd;
      set => this.SetProperty(ref this.hasEnd, value);
    }

    /// <inheritdoc/>
    public DateTime? TrailEnd
    {
      get => this.trailEnd;
      set => this.SetProperty(ref this.trailEnd, value);
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

    public bool Equals(IContract other)
    {
      if (other == null) return false;

      if (this.Matchcode.ToUpper() != other.Matchcode.ToUpper()) return false;
      if (this.Name != other.Name) return false;
      if (this.Description != other.Description) return false;
      if (this.End != other.End) return false;
      if (this.HasEnd != other.HasEnd) return false;
      if (this.Holidays != other.Holidays) return false;
      if (this.Salary != other.Salary) return false;
      if (this.Start != other.Start) return false;
      if (this.TrailEnd != other.TrailEnd) return false;
      if (this.WorkTime != other.WorkTime) return false;
      if (!this.Employees.SequenceEqual(other.Employees)) return false;

      return true;
    }

    public IContract MemberwiseCopy() => this.MemberwiseClone() as IContract;

    #endregion Methods
  }
}