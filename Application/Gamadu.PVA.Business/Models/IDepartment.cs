using System.Collections.Generic;

namespace Gamadu.PVA.Business.Models
{
  public interface IDepartment : IIdentifiable, IMatchable
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
    /// Gets or sets the value for the Employees.
    /// </summary>
    IEnumerable<IEmployee> Employees { get; set; }

    /// <summary>
    /// Gets or sets the value for the Manager
    /// </summary>
    IEmployee Manager { get; set; }

    /// <summary>
    /// Gets or sets the value for the Name.
    /// </summary>
    string Name { get; set; }
  }
}