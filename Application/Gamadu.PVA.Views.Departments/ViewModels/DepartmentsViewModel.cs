using Prism.Mvvm;

namespace Gamadu.PVA.Views.Departments.ViewModels
{
  public class DepartmentsViewModel : BindableBase
  {
    private string _message;
    public string Message
    {
      get { return this._message; }
      set { this.SetProperty(ref this._message, value); }
    }

    public DepartmentsViewModel()
    {
      this.Message = "View A from your Prism Module";
    }
  }
}
