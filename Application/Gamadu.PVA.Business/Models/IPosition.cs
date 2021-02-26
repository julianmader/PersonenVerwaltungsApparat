using System.Collections.Generic;

namespace Gamadu.PVA.Business.Models
{
  public interface IPosition : IIdentifiable
  {
    /// <summary>
    /// Gets or sets the value for the Description.
    /// </summary>
    string Description { get; set; }

    /// <summary>
    /// Gets or sets the value for the Employees.
    /// </summary>
    IEnumerable<IEmployee> Employees { get; set; }

    /// <summary>
    /// Gets or sets the value for the Name.
    /// </summary>
    string Name { get; set; }
  }
}