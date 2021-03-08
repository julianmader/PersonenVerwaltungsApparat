using Gamadu.PVA.Business.Models;
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
      containerRegistry.Register<ICheckableRoom, CheckableRoom>();
    }
  }
}
