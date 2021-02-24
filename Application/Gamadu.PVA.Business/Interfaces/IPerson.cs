using Gamadu.PVA.Business.Enums;
using System;
using System.Collections.Generic;

namespace Gamadu.PVA.Business.Interfaces
{
  public interface IPerson
  {
    /// <summary>
    /// Gets or sets the value for the AdditionalInformation.
    /// </summary>
    string AdditionalInformation { get; set; }

    /// <summary>
    /// Gets or sets the value for the Address.
    /// </summary>
    IAddress Address { get; set; }

    /// <summary>
    /// Gets or sets the value for the Birth.
    /// </summary>
    DateTime Birth { get; set; }

    /// <summary>
    /// Gets or sets the value for the Contract.
    /// </summary>
    IContract Contract { get; set; }

    /// <summary>
    /// Gets or sets the value for the Department.
    /// </summary>
    IDepartment Department { get; set; }

    /// <summary>
    /// Gets or sets the value for the Email.
    /// </summary>
    string Email { get; set; }

    /// <summary>
    /// Gets or sets the value for the Forename.
    /// </summary>
    string Forename { get; set; }

    /// <summary>
    /// Gets or sets the value for the Gender.
    /// </summary>
    Gender Gender { get; set; }

    /// <summary>
    /// Gets or sets the value for the PhoneNumber.
    /// </summary>
    string PhoneNumber { get; set; }

    /// <summary>
    /// Gets or sets the value for the Position.
    /// </summary>
    IPosition Position { get; set; }

    /// <summary>
    /// Gets or sets the value for the Rooms.
    /// </summary>
    IEnumerable<IRoom> Rooms { get; set; }

    /// <summary>
    /// Gets or sets the value for the Surname.
    /// </summary>
    string Surname { get; set; }
  }
}