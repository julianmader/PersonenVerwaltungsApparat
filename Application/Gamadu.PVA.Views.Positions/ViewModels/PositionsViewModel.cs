using Prism.Mvvm;

namespace Gamadu.PVA.Views.Positions.ViewModels
{
  public class PositionsViewModel : BindableBase
  {
    private string _message;
    public string Message
    {
      get { return _message; }
      set { SetProperty(ref _message, value); }
    }

    public PositionsViewModel()
    {
      Message = "View A from your Prism Module";
    }
  }
}
