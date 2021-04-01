namespace Gamadu.PVA.Views.Resources.ViewModels
{
  using Prism.Mvvm;

  public class ResourcesViewModel : BindableBase
  {
    private string _message;
    public string Message
    {
      get => this._message;
      set => this.SetProperty(ref this._message, value);
    }

    public ResourcesViewModel()
    {
      this.Message = "View A from your Prism Module";
    }
  }
}
