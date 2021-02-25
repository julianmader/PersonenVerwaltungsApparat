using Prism.Mvvm;

namespace Gamadu.PVA.Views.Rooms.ViewModels
{
  public class RoomsViewModel : BindableBase
  {
    private string _message;
    public string Message
    {
      get { return this._message; }
      set { this.SetProperty(ref this._message, value); }
    }

    public RoomsViewModel()
    {
      this.Message = "View A from your Prism Module";
    }
  }
}
