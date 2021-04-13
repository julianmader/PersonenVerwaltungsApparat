namespace Gamadu.PVA.Core.Models
{
  using System;
  using System.Collections.Generic;
  using System.ComponentModel;

  public interface IContract : IIdentifiable, IMatchable, INameable, IValidateable<IContract>, INotifyPropertyChanged, IEquatable<IContract>
  {
    /// <summary>
    /// Gets or sets the value for the Description.
    /// </summary>
    string Description { get; set; }

    /// <summary>
    /// Gets or sets the value for the End.
    /// </summary>
    DateTime? End { get; set; }

    /// <summary>
    /// Gets or sets the value for the End.
    /// </summary>
    bool HasEnd { get; set; }

    /// <summary>
    /// Gets or sets the value for the Holidays.
    /// </summary>
    int? Holidays { get; set; }

    /// <summary>
    /// Gets or sets the value for the employees.
    /// </summary>
    IEnumerable<int> Employees { get; set; }

    /// <summary>
    /// Gets or sets the value for the Salary.
    /// </summary>
    int? Salary { get; set; }

    /// <summary>
    /// Gets or sets the value for the Start.
    /// </summary>
    DateTime? Start { get; set; }

    /// <summary>
    /// Gets or sets the value for the TrailEnd.
    /// </summary>
    DateTime? TrailEnd { get; set; }

    /// <summary>
    /// Gets or sets the value for the WorkTime.
    /// </summary>
    int? WorkTime { get; set; }

    IContract MemberwiseCopy();
  }
}