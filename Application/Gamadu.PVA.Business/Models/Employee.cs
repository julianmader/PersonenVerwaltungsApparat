namespace Gamadu.PVA.Business.Models
{
  using Gamadu.PVA.Business.Enums;
  using Gamadu.PVA.Business.Models.Bases;
  using System;
  using System.Collections.Generic;

  public class Employee : ValidateableModelBase<Employee>, IEmployee
  {
    #region Backing Fields

    /// <summary>
    /// Backing field for <see cref="Gender"/>.
    /// </summary>
    private Gender gender;

    /// <summary>
    /// Backing field for <see cref="Forename"/>.
    /// </summary>
    private string forename;

    /// <summary>
    /// Backing field for <see cref="Surname"/>.
    /// </summary>
    private string surname;

    /// <summary>
    /// Backing field for <see cref="Birth"/>.
    /// </summary>
    private DateTime birth;

    /// <summary>
    /// Backing field for <see cref="Email"/>.
    /// </summary>
    private string email;

    /// <summary>
    /// Backing field for <see cref="PhoneNumber"/>.
    /// </summary>
    private string phoneNumber;

    /// <summary>
    /// Backing field for <see cref="Department"/>.
    /// </summary>
    private int? department;

    /// <summary>
    /// Backing field for <see cref="Position"/>.
    /// </summary>
    private int? position;

    /// <summary>
    /// Backing field for <see cref="Contract"/>.
    /// </summary>
    private int? contract;

    /// <summary>
    /// Backing field for <see cref="Rooms"/>.
    /// </summary>
    private IEnumerable<int> rooms;

    /// <summary>
    /// Backing field for <see cref="AdditionalInformation"/>.
    /// </summary>
    private string additionalInformation;

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
    public Gender Gender
    {
      get { return this.gender; }
      set { this.SetProperty(ref this.gender, value); }
    }

    /// <inheritdoc/>
    public string Forename
    {
      get { return this.forename; }
      set { this.SetProperty(ref this.forename, value); }
    }

    /// <inheritdoc/>
    public string Surname
    {
      get { return this.surname; }
      set { this.SetProperty(ref this.surname, value); }
    }

    /// <inheritdoc/>
    public DateTime Birth
    {
      get { return this.birth; }
      set { this.SetProperty(ref this.birth, value); }
    }

    /// <inheritdoc/>
    public string PhoneNumber
    {
      get { return this.phoneNumber; }
      set { this.SetProperty(ref this.phoneNumber, value); }
    }

    /// <inheritdoc/>
    public string Email
    {
      get { return this.email; }
      set { this.SetProperty(ref this.email, value); }
    }

    /// <inheritdoc/>
    public int? Department
    {
      get { return this.department; }
      set { this.SetProperty(ref this.department, value); }
    }

    /// <inheritdoc/>
    public int? Position
    {
      get { return this.position; }
      set { this.SetProperty(ref this.position, value); }
    }

    /// <inheritdoc/>
    public int? Contract
    {
      get { return this.contract; }
      set { this.SetProperty(ref this.contract, value); }
    }

    /// <inheritdoc/>
    public IEnumerable<int> Rooms
    {
      get { return this.rooms; }
      set { this.SetProperty(ref this.rooms, value); }
    }

    /// <inheritdoc/>
    public string AdditionalInformation
    {
      get { return this.additionalInformation; }
      set { this.SetProperty(ref this.additionalInformation, value); }
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

    public override string ToString()
    {
      return $"{this.Matchcode} - {this.Forename} {this.Surname}";
    }

    public override void Validate() => this.Validator.Validate(this);

    #endregion Methods
  }
}
