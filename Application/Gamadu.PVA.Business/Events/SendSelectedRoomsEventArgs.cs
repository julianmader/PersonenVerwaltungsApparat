using System.Collections.Generic;

namespace Gamadu.PVA.Core.Events
{
  public class SendSelectedRoomsEventArgs
  {
    public IEnumerable<int> SelectedRoomsIDs { get; set; }

    public string Receiver { get; set; }

    public string Sender { get; set; }
  }
}