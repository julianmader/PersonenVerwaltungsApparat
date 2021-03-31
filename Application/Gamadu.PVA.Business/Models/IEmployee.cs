using Gamadu.PVA.Business.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Gamadu.PVA.Business.Models
{
  public interface IEmployee : IIdentifiable, IMatchable, IValidateable<IEmployee>, INotifyPropertyChanged
  {
    /// <summary>
    /// Gets or sets the value for the AdditionalInformation.
    /// </summary>
    string AdditionalInformation { get; set; }

    /// <summary>
    /// Gets or sets the value for the City.
    /// </summary>
    string City { get; set; }

    /// <summary>
    /// Gets or sets the value for the PostalCode.
    /// </summary>
    string PostalCode { get; set; }

    /// <summary>
    /// Gets or sets the value for the Street.
    /// </summary>
    string Street { get; set; }

    /// <summary>
    /// Gets or sets the value for the StreetNumber.
    /// </summary>
    string StreetNumber { get; set; }

    /// <summary>
    /// Gets or sets the value for the Birth.
    /// </summary>
    DateTime Birth { get; set; }

    /// <summary>
    /// Gets or sets the value for the Contract.
    /// </summary>
    int? Contract { get; set; }

    /// <summary>
    /// Gets or sets the value for the Department.
    /// </summary>
    int? Department { get; set; }

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
    int? Position { get; set; }

    /// <summary>
    /// Gets or sets the value for the Rooms.
    /// </summary>
    IEnumerable<int> Rooms { get; set; }

    /// <summary>
    /// Gets or sets the value for the Surname.
    /// </summary>
    string Surname { get; set; }
  }
}