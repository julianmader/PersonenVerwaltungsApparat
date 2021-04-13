namespace Gamadu.PVA.Core.Models
{
  using System;
  using System.Collections.Generic;
  using System.ComponentModel;

  public interface IPosition : IIdentifiable, IMatchable, INameable, IValidateable<IPosition>, INotifyPropertyChanged, IEquatable<IPosition>
  {
    /// <summary>
    /// Gets or sets the value for the Description.
    /// </summary>
    string Description { get; set; }

    /// <summary>
    /// Gets or sets the value for the Employees.
    /// </summary>
    IEnumerable<int> Employees { get; set; }

    IPosition MemberwiseCopy();
  }
}