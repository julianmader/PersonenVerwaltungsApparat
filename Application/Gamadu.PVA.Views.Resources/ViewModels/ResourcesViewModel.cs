using Prism.Mvvm;

namespace Gamadu.PVA.Views.Resources.ViewModels
{
  public class ResourcesViewModel : BindableBase
    {
        private string _message;
        public string Message
        {
            get { return this._message; }
            set { this.SetProperty(ref this._message, value); }
        }

        public ResourcesViewModel()
        {
      this.Message = "View A from your Prism Module";
        }
    }
}
