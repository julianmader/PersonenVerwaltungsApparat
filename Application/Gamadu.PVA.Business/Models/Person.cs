namespace Gamadu.PVA.Business.Models
{
  using Gamadu.PVA.Business.Data;
  using Prism.Mvvm;
  using System;

  public class Person : BindableBase
  {
    #region Backing Fields

    /// <summary>
    /// Backing field for <see cref="ID"/>.
    /// </summary>
    private int id;

    /// <summary>
    /// Backing field for <see cref="Matchcode"/>.
    /// </summary>
    private string matchcode;

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
    private Address address;

    /// <summary>
    /// Backing field for <see cref="PhoneNumber"/>.
    /// </summary>
    private string phoneNumber;

    /// <summary>
    /// Backing field for <see cref="Department"/>.
    /// </summary>
    private Department department;

    /// <summary>
    /// Backing field for <see cref="Position"/>.
    /// </summary>
    private Position position;

    /// <summary>
    /// Backing field for <see cref="Contract"/>.
    /// </summary>
    private Contract contract;

    /// <summary>
    /// Backing field for <see cref="Rooms"/>.
    /// </summary>
    private Room rooms;

    /// <summary>
    /// Backing field for <see cref="AdditionalInformation"/>.
    /// </summary>
    private string additionalInformation;

    #endregion Backing Fields

    #region Properties

    /// <summary>
    /// Gets or sets the value for the ID.
    /// </summary>
    public int ID
    {
      get { return this.id; }
      set { this.SetProperty(ref this.id, value); }
    }

    /// <summary>
    /// Gets or sets the value for the Matchcode.
    /// </summary>
    public string Matchcode
    {
      get { return this.matchcode; }
      set { this.SetProperty(ref this.matchcode, value); }
    }

    /// <summary>
    /// Gets or sets the value for the Gender.
    /// </summary>
    public Gender Gender
    {
      get { return this.gender; }
      set { this.SetProperty(ref this.gender, value); }
    }

    /// <summary>
    /// Gets or sets the value for the Forename.
    /// </summary>
    public string Forename
    {
      get { return this.forename; }
      set { this.SetProperty(ref this.forename, value); }
    }

    /// <summary>
    /// Gets or sets the value for the Surname.
    /// </summary>
    public string Surname
    {
      get { return this.surname; }
      set { this.SetProperty(ref this.surname, value); }
    }

    /// <summary>
    /// Gets or sets the value for the Birth.
    /// </summary>
    public DateTime Birth
    {
      get { return this.birth; }
      set { this.SetProperty(ref this.birth, value); }
    }

    /// <summary>
    /// Gets or sets the value for the PhoneNumber.
    /// </summary>
    public string PhoneNumber
    {
      get { return this.phoneNumber; }
      set { this.SetProperty(ref this.phoneNumber, value); }
    }

    /// <summary>
    /// Gets or sets the value for the Email.
    /// </summary>
    public string Email
    {
      get { return this.email; }
      set { this.SetProperty(ref this.email, value); }
    }

    /// <summary>
    /// Gets or sets the value for the Address.
    /// </summary>
    public Address Address
    {
      get { return this.address; }
      set { this.SetProperty(ref this.address, value); }
    }

    /// <summary>
    /// Gets or sets the value for the Department.
    /// </summary>
    public Department Department
    {
      get { return this.department; }
      set { this.SetProperty(ref this.department, value); }
    }

    /// <summary>
    /// Gets or sets the value for the Position.
    /// </summary>
    public Position Position
    {
      get { return this.position; }
      set { this.SetProperty(ref this.position, value); }
    }

    /// <summary>
    /// Gets or sets the value for the Contract.
    /// </summary>
    public Contract Contract
    {
      get { return this.contract; }
      set { this.SetProperty(ref this.contract, value); }
    }

    /// <summary>
    /// Gets or sets the value for the Rooms.
    /// </summary>
    public Room Rooms
    {
      get { return this.rooms; }
      set { this.SetProperty(ref this.rooms, value); }
    }

    /// <summary>
    /// Gets or sets the value for the AdditionalInformation.
    /// </summary>
    public string AdditionalInformation
    {
      get { return this.additionalInformation; }
      set { this.SetProperty(ref this.additionalInformation, value); }
    }

    #endregion Properties
  }
}
