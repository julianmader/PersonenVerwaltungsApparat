using Prism.Mvvm;

namespace Gamadu.PVA.Views.Positions.ViewModels
{
  public class PositionsViewModel : BindableBase
  {
    private string _message;
    public string Message
    {
      get { return this._message; }
      set { this.SetProperty(ref this._message, value); }
    }

    public PositionsViewModel()
    {
      this.Message = "View A from your Prism Module";
    }
  }
}
