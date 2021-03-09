using System.Collections.Generic;

namespace Gamadu.PVA.Business.Events
{
  public class SendSelectedRoomsEventArgs
  {
    public IEnumerable<int> SelectedRoomsIDs { get; set; }

    public string Receiver { get; set; }

    public string Sender { get; set; }
  }
}
