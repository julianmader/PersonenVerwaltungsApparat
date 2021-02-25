using Prism.Mvvm;

namespace Gamadu.PVA.Views.Contracts.ViewModels
{
  public class ContractsViewModel : BindableBase
    {
        private string _message;
        public string Message
        {
            get { return this._message; }
            set { this.SetProperty(ref this._message, value); }
        }

        public ContractsViewModel()
        {
      this.Message = "View A from your Prism Module";
        }
    }
}
