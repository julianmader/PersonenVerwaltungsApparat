namespace Gamadu.PVA.Core.Models.Bases
{
  using Prism.Mvvm;
  using System;

  public abstract class ModelBase : BindableBase, IEquatable<IIdentifiable>, IComparable<IIdentifiable>, IIdentifiable, IMatchable
  {
    /// <summary>
    /// Backing field for <see cref="ID"/>.
    /// </summary>
    private int? id;

    /// <inheritdoc/>
    public int? ID
    {
      get => this.id;
      set => this.SetProperty(ref this.id, value);
    }

    /// <summary>
    /// Backing field for <see cref="Matchcode"/>.
    /// </summary>
    private string matchcode;

    /// <inheritdoc/>
    public string Matchcode
    {
      get => this.matchcode;
      set => this.SetProperty(ref this.matchcode, value);
    }

    /// <inheritdoc/>
    public int CompareTo(IIdentifiable other) => this.ID < other.ID ? -1 : 1;

    /// <inheritdoc/>
    public bool Equals(IIdentifiable other) => this.ID == other.ID;
  }
}