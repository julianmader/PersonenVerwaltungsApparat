using System.Collections.Generic;

namespace Gamadu.PVA.Business.Models
{
  public interface IRoom : IIdentifiable
  {
    /// <summary>
    /// Gets or sets the value for the Description.
    /// </summary>
    string Description { get; set; }

    /// <summary>
    /// Gets or sets the value for the Employees.
    /// </summary>
    IEnumerable<IPerson> Employees { get; set; }

    /// <summary>
    /// Gets or sets the value for the FloorNumber.
    /// </summary>
    int FloorNumber { get; set; }

    /// <summary>
    /// Gets or sets the value for the Name.
    /// </summary>
    string Name { get; set; }

    /// <summary>
    /// Gets or sets the value for the RoomNumber.
    /// </summary>
    int RoomNumber { get; set; }

    /// <summary>
    /// Gets or sets the value for the Size.
    /// </summary>
    int Size { get; set; }
  }
}