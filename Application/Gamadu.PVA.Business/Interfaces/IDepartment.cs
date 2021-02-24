using System.Collections.Generic;

namespace Gamadu.PVA.Business.Interfaces
{
  public interface IDepartment
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
    IEnumerable<IPerson> Employees { get; set; }

    /// <summary>
    /// Gets or sets the value for the Manager
    /// </summary>
    IPerson Manager { get; set; }

    /// <summary>
    /// Gets or sets the value for the Name.
    /// </summary>
    string Name { get; set; }
  }
}