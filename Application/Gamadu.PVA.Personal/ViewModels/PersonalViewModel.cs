using Prism.Mvvm;

namespace Gamadu.PVA.Views.Personal.ViewModels
{
  public class PersonalViewModel : BindableBase
  {
    private string _message;
    public string Message
    {
      get { return _message; }
      set { SetProperty(ref _message, value); }
    }

    public PersonalViewModel()
    {
      Message = "PersonalView from your Prism Module";
    }
  }
}
