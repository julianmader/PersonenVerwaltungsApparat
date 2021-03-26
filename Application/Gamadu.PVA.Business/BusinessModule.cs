using FluentValidation;
using Gamadu.PVA.Business.Models;
using Gamadu.PVA.Business.Validators;
using Prism.Ioc;
using Prism.Modularity;

namespace Gamadu.PVA.Business
{
  [Module(ModuleName = "BusinessModule")]
  public class BusinessModule : IModule
  {
    public void OnInitialized(IContainerProvider containerProvider)
    {
    }

    public void RegisterTypes(IContainerRegistry containerRegistry)
    {
      containerRegistry.Register<IEmployee, Employee>();
      containerRegistry.Register<ICheckableEmployee, CheckableEmployee>();
      containerRegistry.Register<ICheckableRoom, CheckableRoom>();
      containerRegistry.Register<IDepartment, Department>();
      containerRegistry.Register<IPosition, Position>();
      containerRegistry.Register<IContract, Contract>();

      containerRegistry.Register<IRoom, Room>();
      containerRegistry.Register<IValidator<Employee>, EmployeeValidator>();
    }
  }
}
