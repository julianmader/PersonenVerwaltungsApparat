namespace Gamadu.PVA.Business.Interfaces
{
  public interface IIdentifiable
  {
    /// <summary>
    /// Gets or sets the value for the ID.
    /// </summary>
    int ID { get; set; }

    /// <summary>
    /// Gets or sets the value for the Matchcode.
    /// </summary>
    string Matchcode { get; set; }
  }
}
