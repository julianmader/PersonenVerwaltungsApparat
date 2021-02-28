namespace Gamadu.PVA.Business.Models
{
  using Prism.Mvvm;
  using System;

  public abstract class IdentifiableBase : BindableBase, IEquatable<IIdentifiable>, IComparable<IIdentifiable>, IIdentifiable, IMatchable
  {
    /// <summary>
    /// Backing field for <see cref="ID"/>.
    /// </summary>
    private int id;

    /// <inheritdoc/>
    public int ID
    {
      get { return this.id; }
      set { this.SetProperty(ref this.id, value); }
    }

    /// <summary>
    /// Backing field for <see cref="Matchcode"/>.
    /// </summary>
    private string matchcode;

    /// <inheritdoc/>
    public string Matchcode
    {
      get { return this.matchcode; }
      set { this.SetProperty(ref this.matchcode, value); }
    }

    /// <inheritdoc/>
    public int CompareTo(IIdentifiable other)
    {
      if (this.ID < other.ID)
      {
        return -1;
      }

      return 1;
    }

    /// <inheritdoc/>
    public bool Equals(IIdentifiable other)
    {
      return this.ID == other.ID;
    }
  }
}
