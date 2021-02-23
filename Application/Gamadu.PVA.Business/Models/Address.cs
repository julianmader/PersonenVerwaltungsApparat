namespace Gamadu.PVA.Business.Models
{
  using Prism.Mvvm;

  public class Address : BindableBase
  {
    #region Backing Fields

    /// <summary>
    /// Backing field for <see cref="Street"/>.
    /// </summary>
    private string street;

    /// <summary>
    /// Backing field for <see cref="StreetNumber"/>.
    /// </summary>
    private string streetNumber;

    /// <summary>
    /// Backing field for <see cref="City"/>.
    /// </summary>
    private string city;

    /// <summary>
    /// Backing field for <see cref="PostalCode"/>.
    /// </summary>
    private string postalCode;

    #endregion Backing Fields

    #region Properties

    /// <summary>
    /// Gets or sets the value for the Street.
    /// </summary>
    public string Street
    {
      get { return this.street; }
      set { this.SetProperty(ref this.street, value); }
    }

    /// <summary>
    /// Gets or sets the value for the StreetNumber.
    /// </summary>
    public string StreetNumber
    {
      get { return this.streetNumber; }
      set { this.SetProperty(ref this.streetNumber, value); }
    }

    /// <summary>
    /// Gets or sets the value for the City.
    /// </summary>
    public string City
    {
      get { return this.city; }
      set { this.SetProperty(ref this.city, value); }
    }

    /// <summary>
    /// Gets or sets the value for the PostalCode.
    /// </summary>
    public string PostalCode
    {
      get { return this.postalCode; }
      set { this.SetProperty(ref this.postalCode, value); }
    }

    #endregion Properties
  }
}
