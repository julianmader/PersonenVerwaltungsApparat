namespace Gamadu.PVA.Business.Models
{
  using System.Collections.Generic;

  public class Room : IdentifiableBase, IRoom
  {
    #region Backing Fields

    /// <summary>
    /// Backing field for <see cref="Name"/>.
    /// </summary>
    private string name;

    /// <summary>
    /// Backing field for <see cref="RoomNumber"/>.
    /// </summary>
    private int roomNumber;

    /// <summary>
    /// Backing field for <see cref="FloorNumber"/>.
    /// </summary>
    private int floorNumber;

    /// <summary>
    /// Backing field for <see cref="Size"/>.
    /// </summary>
    private int size;

    /// <summary>
    /// Backing field for <see cref="Description"/>.
    /// </summary>
    private string description;

    /// <summary>
    /// Backing field for <see cref="Employees"/>.
    /// </summary>
    private IEnumerable<IPerson> employees;

    #endregion Backing Fields

    #region Properties

    /// <inheritdoc/>
    public string Name
    {
      get { return this.name; }
      set { this.SetProperty(ref this.name, value); }
    }

    /// <inheritdoc/>
    public int RoomNumber
    {
      get { return this.roomNumber; }
      set { this.SetProperty(ref this.roomNumber, value); }
    }

    /// <inheritdoc/>
    public int FloorNumber
    {
      get { return this.floorNumber; }
      set { this.SetProperty(ref this.floorNumber, value); }
    }

    /// <inheritdoc/>
    public int Size
    {
      get { return this.size; }
      set { this.SetProperty(ref this.size, value); }
    }

    /// <inheritdoc/>
    public string Description
    {
      get { return this.description; }
      set { this.SetProperty(ref this.description, value); }
    }

    /// <inheritdoc/>
    public IEnumerable<IPerson> Employees
    {
      get { return this.employees; }
      set { this.SetProperty(ref this.employees, value); }
    }

    #endregion Properties
  }
}
