namespace Gamadu.PVA.Business.Models
{
  using Gamadu.PVA.Business.Enums;
  using System;
  using System.Collections.Generic;

  public class Person : IdentifiableBase, IPerson
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
    /// Backing field for <see cref="Address"/>.
    /// </summary>
    private IAddress address;

    /// <summary>
    /// Backing field for <see cref="PhoneNumber"/>.
    /// </summary>
    private string phoneNumber;

    /// <summary>
    /// Backing field for <see cref="Department"/>.
    /// </summary>
    private IDepartment department;

    /// <summary>
    /// Backing field for <see cref="Position"/>.
    /// </summary>
    private IPosition position;

    /// <summary>
    /// Backing field for <see cref="Contract"/>.
    /// </summary>
    private IContract contract;

    /// <summary>
    /// Backing field for <see cref="Rooms"/>.
    /// </summary>
    private IEnumerable<IRoom> rooms;

    /// <summary>
    /// Backing field for <see cref="AdditionalInformation"/>.
    /// </summary>
    private string additionalInformation;

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
    public IAddress Address
    {
      get { return this.address; }
      set { this.SetProperty(ref this.address, value); }
    }

    /// <inheritdoc/>
    public IDepartment Department
    {
      get { return this.department; }
      set { this.SetProperty(ref this.department, value); }
    }

    /// <inheritdoc/>
    public IPosition Position
    {
      get { return this.position; }
      set { this.SetProperty(ref this.position, value); }
    }

    /// <inheritdoc/>
    public IContract Contract
    {
      get { return this.contract; }
      set { this.SetProperty(ref this.contract, value); }
    }

    /// <inheritdoc/>
    public IEnumerable<IRoom> Rooms
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

    #endregion Properties
  }
}
