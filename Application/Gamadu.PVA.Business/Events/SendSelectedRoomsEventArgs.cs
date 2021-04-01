namespace Gamadu.PVA.Core.Events
{
  using System.Collections.Generic;

  public class SendSelectedRoomsEventArgs
  {
    public IEnumerable<int> SelectedRoomsIDs { get; set; }

    public string Receiver { get; set; }

    public string Sender { get; set; }
  }
}