namespace Gamadu.PVA.Business.Models
{
  using Prism.Mvvm;
  using System;

  public class Address : BindableBase, IAddress
  {
    #region Backing Fields

    /// <summary>
    /// Backing field for <see cref="ID"/>.
    /// </summary>
    private int id;

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

    /// <inheritdoc/>
    public int ID
    {
      get { return this.id; }
      set { this.SetProperty(ref this.id, value); }
    }

    /// <inheritdoc/>
    public string Street
    {
      get { return this.street; }
      set { this.SetProperty(ref this.street, value); }
    }

    /// <inheritdoc/>
    public string StreetNumber
    {
      get { return this.streetNumber; }
      set { this.SetProperty(ref this.streetNumber, value); }
    }

    /// <inheritdoc/>
    public string City
    {
      get { return this.city; }
      set { this.SetProperty(ref this.city, value); }
    }

    /// <inheritdoc/>
    public string PostalCode
    {
      get { return this.postalCode; }
      set { this.SetProperty(ref this.postalCode, value); }
    }

    #endregion Properties

    #region Methods

    /// <inheritdoc/>
    public bool Equals(IAddress other)
    {
      return this.Street.Equals(other.Street, StringComparison.OrdinalIgnoreCase)
        && this.StreetNumber.Equals(other.StreetNumber, StringComparison.OrdinalIgnoreCase)
        && this.City.Equals(other.City, StringComparison.OrdinalIgnoreCase)
        && this.PostalCode.Equals(other.PostalCode, StringComparison.OrdinalIgnoreCase);
    }

    #endregion Methods
  }
}
