using Prism.Mvvm;

namespace Gamadu.PVA.Departments.ViewModels
{
  public class DepartmentsViewModel : BindableBase
  {
    private string _message;
    public string Message
    {
      get { return _message; }
      set { SetProperty(ref _message, value); }
    }

    public DepartmentsViewModel()
    {
      Message = "View A from your Prism Module";
    }
  }
}
