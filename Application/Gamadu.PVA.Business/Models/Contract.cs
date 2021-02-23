namespace Gamadu.PVA.Business.Models
{
  using Prism.Mvvm;
  using System;

  public class Contract : BindableBase
  {
    #region Backing Fields

    /// <summary>
    /// Backing field for <see cref="ID"/>.
    /// </summary>
    private int id;

    /// <summary>
    /// Backing field for <see cref="Matchcode"/>.
    /// </summary>
    private string matchcode;

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
    private Person employee;

    /// <summary>
    /// Backing field for <see cref="AdditionalInformation"/>.
    /// </summary>
    private string additionalInformation;

    #endregion Backing Fields

    #region Properties

    /// <summary>
    /// Gets or sets the value for the ID.
    /// </summary>
    public int ID
    {
      get { return this.id; }
      set { this.SetProperty(ref this.id, value); }
    }

    /// <summary>
    /// Gets or sets the value for the Matchcode.
    /// </summary>
    public string Matchcode
    {
      get { return this.matchcode; }
      set { this.SetProperty(ref this.matchcode, value); }
    }

    /// <summary>
    /// Gets or sets the value for the Name.
    /// </summary>
    public string Name
    {
      get { return this.name; }
      set { this.SetProperty(ref this.name, value); }
    }

    /// <summary>
    /// Gets or sets the value for the WorkTime.
    /// </summary>
    public int WorkTime
    {
      get { return this.workTime; }
      set { this.SetProperty(ref this.workTime, value); }
    }

    /// <summary>
    /// Gets or sets the value for the Holidays.
    /// </summary>
    public int Holidays
    {
      get { return this.holidays; }
      set { this.SetProperty(ref this.holidays, value); }
    }

    /// <summary>
    /// Gets or sets the value for the Salary.
    /// </summary>
    public int Salary
    {
      get { return this.salary; }
      set { this.SetProperty(ref this.salary, value); }
    }

    /// <summary>
    /// Gets or sets the value for the Start.
    /// </summary>
    public DateTime Start
    {
      get { return this.start; }
      set { this.SetProperty(ref this.start, value); }
    }

    /// <summary>
    /// Gets or sets the value for the End.
    /// </summary>
    public DateTime End
    {
      get { return this.end; }
      set { this.SetProperty(ref this.end, value); }
    }

    /// <summary>
    /// Gets or sets the value for the TrailEnd.
    /// </summary>
    public DateTime TrailEnd
    {
      get { return this.trailEnd; }
      set { this.SetProperty(ref this.trailEnd, value); }
    }

    /// <summary>
    /// Gets or sets the value for the Employee.
    /// </summary>
    public Person Employee
    {
      get { return this.employee; }
      set { this.SetProperty(ref this.employee, value); }
    }

    /// <summary>
    /// Gets or sets the value for the AdditionalInformation.
    /// </summary>
    public string AdditionalInformation
    {
      get { return this.additionalInformation; }
      set { this.SetProperty(ref this.additionalInformation, value); }
    }

    #endregion Properties
  }
}
