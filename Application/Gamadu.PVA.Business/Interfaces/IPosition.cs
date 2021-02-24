﻿using System.Collections.Generic;

namespace Gamadu.PVA.Business.Interfaces
{
  public interface IPosition
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
    /// Gets or sets the value for the Name.
    /// </summary>
    string Name { get; set; }
  }
}