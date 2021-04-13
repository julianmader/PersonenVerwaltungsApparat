namespace Gamadu.PVA.Core.Models
{
  using Gamadu.PVA.Core.Enums;
  using Gamadu.PVA.Core.Models.Bases;
  using System;
  using System.Collections.Generic;
  using System.Linq;

  public class Employee : ValidateableModelBase<IEmployee>, IEmployee
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
      get => this.gender;
      set => this.SetProperty(ref this.gender, value);
    }

    /// <inheritdoc/>
    public string Forename
    {
      get => this.forename;
      set => this.SetProperty(ref this.forename, value);
    }

    /// <inheritdoc/>
    public string Surname
    {
      get => this.surname;
      set => this.SetProperty(ref this.surname, value);
    }

    /// <inheritdoc/>
    public DateTime Birth
    {
      get => this.birth;
      set => this.SetProperty(ref this.birth, value);
    }

    /// <inheritdoc/>
    public string PhoneNumber
    {
      get => this.phoneNumber;
      set => this.SetProperty(ref this.phoneNumber, value);
    }

    /// <inheritdoc/>
    public string Email
    {
      get => this.email;
      set => this.SetProperty(ref this.email, value);
    }

    /// <inheritdoc/>
    public int? Department
    {
      get => this.department;
      set => this.SetProperty(ref this.department, value);
    }

    /// <inheritdoc/>
    public int? Position
    {
      get => this.position;
      set => this.SetProperty(ref this.position, value);
    }

    /// <inheritdoc/>
    public int? Contract
    {
      get => this.contract;
      set => this.SetProperty(ref this.contract, value);
    }

    /// <inheritdoc/>
    public IEnumerable<int> Rooms
    {
      get => this.rooms;
      set => this.SetProperty(ref this.rooms, value);
    }

    /// <inheritdoc/>
    public string AdditionalInformation
    {
      get => this.additionalInformation;
      set => this.SetProperty(ref this.additionalInformation, value);
    }

    /// <inheritdoc/>
    public string Street
    {
      get => this.street;
      set => this.SetProperty(ref this.street, value);
    }

    /// <inheritdoc/>
    public string StreetNumber
    {
      get => this.streetNumber;
      set => this.SetProperty(ref this.streetNumber, value);
    }

    /// <inheritdoc/>
    public string City
    {
      get => this.city;
      set => this.SetProperty(ref this.city, value);
    }

    /// <inheritdoc/>
    public string PostalCode
    {
      get => this.postalCode;
      set => this.SetProperty(ref this.postalCode, value);
    }

    #endregion Properties

    #region Methods

    public override string ToString() => $"{this.Matchcode} - {this.Forename} {this.Surname}";

    public override void Validate() => this.Validate(this);

    public bool Equals(IEmployee other)
    {
      if (other == null) return false;

      if (this.Matchcode.ToUpper() != other.Matchcode.ToUpper()) return false;
      if (this.Gender != other.Gender) return false;
      if (this.Forename != other.Forename) return false;
      if (this.Surname != other.Surname) return false;
      if (this.Birth != other.Birth) return false;
      if (this.PhoneNumber != other.PhoneNumber) return false;
      if (this.Street != other.Street) return false;
      if (this.StreetNumber != other.StreetNumber) return false;
      if (this.City != other.City) return false;
      if (this.PostalCode != other.PostalCode) return false;
      if (this.Department != other.Department) return false;
      if (this.Position != other.Position) return false;
      if (this.Contract != other.Contract) return false;
      if (this.AdditionalInformation != other.AdditionalInformation) return false;
      if (!this.Rooms.SequenceEqual(other.Rooms)) return false;

      return true;
    }

    public IEmployee MemberwiseCopy() => this.MemberwiseClone() as IEmployee;

    #endregion Methods
  }
}