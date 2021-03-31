using System.Collections.Generic;
using System.ComponentModel;

namespace Gamadu.PVA.Business.Models
{
  public interface IDepartment : IIdentifiable, IMatchable, INameable, IValidateable<IDepartment>, INotifyPropertyChanged
  {
    /// <summary>
    /// Gets or sets the value for the Cost Center
    /// </summary>
    string CostCenter { get; set; }

    /// <summary>
    /// Gets or sets the value for the Description.
    /// </summary>
    string Description { get; set; }

    /// <summary>
    /// Gets or sets the value for the Manager
    /// </summary>
    int? Manager { get; set; }

    /// <summary>
    /// Gets or sets the employees for the department.
    /// </summary>
    IEnumerable<int> Employees { get; set; }
  }
}