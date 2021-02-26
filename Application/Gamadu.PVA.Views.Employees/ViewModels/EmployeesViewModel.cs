using Prism.Mvvm;

namespace Gamadu.PVA.Views.Employees.ViewModels
{
  public class EmployeesViewModel : BindableBase
  {
    private string _message;
    public string Message
    {
      get { return this._message; }
      set { this.SetProperty(ref this._message, value); }
    }

    public EmployeesViewModel()
    {
      this.Message = "EmployeesView from your Prism Module";
    }
  }
}
