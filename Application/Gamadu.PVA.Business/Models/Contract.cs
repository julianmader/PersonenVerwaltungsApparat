namespace Gamadu.PVA.Business.Models
{
  using System;

  public class Contract : IdentifiableBase, IContract
  {
    #region Backing Fields

    /// <summary>
    /// Backing field for <see cref="Name"/>.
    /// </summary>
    private string name;

    /// <summary>
    /// Backing field for <see cref="WorkTime"/>.
    /// </summary>
    private int workTime;

    /// <summary>
    /// Backing field for <see cref="Holidays"/>.
    /// </summary>
    private int holidays;

    /// <summary>
    /// Backing field for <see cref="Salary"/>.
    /// </summary>
    private int salary;

    /// <summary>
    /// Backing field for <see cref="TrailEnd"/>.
    /// </summary>
    private DateTime trailEnd;

    /// <summary>
    /// Backing field for <see cref="Start
    /// </summary>
    private DateTime start;

    /// <summary>
    /// Backing field for <see cref="End"/>.
    /// </summary>
    private DateTime end;

    /// <summary>
    /// Backing field for <see cref="Employee"/>.
    /// </summary>
    private IPerson employee;

    /// <summary>
    /// Backing field for <see cref="Description"/>.
    /// </summary>
    private string description;

    #endregion Backing Fields

    #region Properties

    /// <inheritdoc/>
    public string Name
    {
      get { return this.name; }
      set { this.SetProperty(ref this.name, value); }
    }

    /// <inheritdoc/>
    public int WorkTime
    {
      get { return this.workTime; }
      set { this.SetProperty(ref this.workTime, value); }
    }

    /// <inheritdoc/>
    public int Holidays
    {
      get { return this.holidays; }
      set { this.SetProperty(ref this.holidays, value); }
    }

    /// <inheritdoc/>
    public int Salary
    {
      get { return this.salary; }
      set { this.SetProperty(ref this.salary, value); }
    }

    /// <inheritdoc/>
    public DateTime Start
    {
      get { return this.start; }
      set { this.SetProperty(ref this.start, value); }
    }

    /// <inheritdoc/>
    public DateTime End
    {
      get { return this.end; }
      set { this.SetProperty(ref this.end, value); }
    }

    /// <inheritdoc/>
    public DateTime TrailEnd
    {
      get { return this.trailEnd; }
      set { this.SetProperty(ref this.trailEnd, value); }
    }

    /// <inheritdoc/>
    public IPerson Employee
    {
      get { return this.employee; }
      set { this.SetProperty(ref this.employee, value); }
    }

    /// <inheritdoc/>
    public string Description
    {
      get { return this.description; }
      set { this.SetProperty(ref this.description, value); }
    }

    #endregion Properties
  }
}
