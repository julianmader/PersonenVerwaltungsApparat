namespace Gamadu.PVA.Business.Models
{
  public interface IAddress
  {
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
  }
}