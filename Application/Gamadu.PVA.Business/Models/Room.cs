﻿namespace Gamadu.PVA.Core.Models
{
  using Gamadu.PVA.Core.Models.Bases;
  using System.Collections.Generic;

  public class Room : ValidateableModelBase<IRoom>, IRoom
  {
    #region Backing Fields

    /// <summary>
    /// Backing field for <see cref="Name"/>.
    /// </summary>
    private string name;

    /// <summary>
    /// Backing field for <see cref="RoomNumber"/>.
    /// </summary>
    private int? roomNumber;

    /// <summary>
    /// Backing field for <see cref="FloorNumber"/>.
    /// </summary>
    private int? floorNumber;

    /// <summary>
    /// Backing field for <see cref="Size"/>.
    /// </summary>
    private int? size;

    /// <summary>
    /// Backing field for <see cref="Description"/>.
    /// </summary>
    private string description;

    /// <summary>
    /// Backing field for <see cref="Employees"/>.
    /// </summary>
    private IEnumerable<int> employees;

    #endregion Backing Fields

    #region Properties

    /// <inheritdoc/>
    public string Name
    {
      get => this.name;
      set => this.SetProperty(ref this.name, value);
    }

    /// <inheritdoc/>
    public int? RoomNumber
    {
      get => this.roomNumber;
      set => this.SetProperty(ref this.roomNumber, value);
    }

    /// <inheritdoc/>
    public int? FloorNumber
    {
      get => this.floorNumber;
      set => this.SetProperty(ref this.floorNumber, value);
    }

    /// <inheritdoc/>
    public int? Size
    {
      get => this.size;
      set => this.SetProperty(ref this.size, value);
    }

    /// <inheritdoc/>
    public string Description
    {
      get => this.description;
      set => this.SetProperty(ref this.description, value);
    }

    /// <inheritdoc/>
    public IEnumerable<int> Employees
    {
      get => this.employees;
      set => this.SetProperty(ref this.employees, value);
    }

    #endregion Properties

    #region Methods

    public override string ToString() => $"{this.Matchcode} - {this.Name}";

    public override void Validate() => this.Validate(this);

    #endregion Methods
  }
}