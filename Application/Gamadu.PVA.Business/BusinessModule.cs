namespace Gamadu.PVA.Core
{
  using FluentValidation;
  using Gamadu.PVA.Core.Models;
  using Gamadu.PVA.Core.Validators;
  using Prism.Ioc;
  using Prism.Modularity;

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

      containerRegistry.Register<IValidator<IEmployee>, EmployeeValidator>();
      containerRegistry.Register<IValidator<IContract>, ContractValidator>();
      containerRegistry.Register<IValidator<IDepartment>, DepartmentValidator>();
      containerRegistry.Register<IValidator<IPosition>, PositionValidator>();
      containerRegistry.Register<IValidator<IRoom>, RoomValidator>();
    }
  }
}