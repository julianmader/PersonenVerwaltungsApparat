using Prism.Mvvm;

namespace Gamadu.PVA.Views.Personal.ViewModels
{
  public class PersonalViewModel : BindableBase
  {
    private string _message;
    public string Message
    {
      get { return this._message; }
      set { this.SetProperty(ref this._message, value); }
    }

    public PersonalViewModel()
    {
      this.Message = "PersonalView from your Prism Module";
    }
  }
}
