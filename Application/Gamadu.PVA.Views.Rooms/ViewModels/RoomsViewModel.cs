using Prism.Mvvm;

namespace Gamadu.PVA.Views.Rooms.ViewModels
{
  public class RoomsViewModel : BindableBase
  {
    private string _message;
    public string Message
    {
      get { return _message; }
      set { SetProperty(ref _message, value); }
    }

    public RoomsViewModel()
    {
      Message = "View A from your Prism Module";
    }
  }
}
