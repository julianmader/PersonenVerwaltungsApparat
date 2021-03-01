using System;

namespace Gamadu.PVA.Business.Models
{
  public interface IContract : IIdentifiable, IMatchable
  {
    /// <summary>
    /// Gets or sets the value for the Description.
    /// </summary>
    string Description { get; set; }

    /// <summary>
    /// Gets or sets the value for the Employee.
    /// </summary>
    int Employee { get; set; }

    /// <summary>
    /// Gets or sets the value for the End.
    /// </summary>
    DateTime End { get; set; }

    /// <summary>
    /// Gets or sets the value for the End.
    /// </summary>
    bool HasEnd { get; set; }

    /// <summary>
    /// Gets or sets the value for the Holidays.
    /// </summary>
    int Holidays { get; set; }

    /// <summary>
    /// Gets or sets the value for the Name.
    /// </summary>
    string Name { get; set; }

    /// <summary>
    /// Gets or sets the value for the Salary.
    /// </summary>
    int Salary { get; set; }

    /// <summary>
    /// Gets or sets the value for the Start.
    /// </summary>
    DateTime Start { get; set; }

    /// <summary>
    /// Gets or sets the value for the TrailEnd.
    /// </summary>
    DateTime TrailEnd { get; set; }

    /// <summary>
    /// Gets or sets the value for the WorkTime.
    /// </summary>
    int WorkTime { get; set; }
  }
}