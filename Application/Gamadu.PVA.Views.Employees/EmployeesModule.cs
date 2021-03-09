using Gamadu.PVA.Views.Employees.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

namespace Gamadu.PVA.Views.Employees
{
  [Module(ModuleName = "EmployeesModule")]
  [ModuleDependency("MySQLModule")]
  [ModuleDependency("DialogsModule")]
  public class EmployeesModule : IModule
  {
    public IRegionManager RegionManager { get; set; }

    public void OnInitialized(IContainerProvider containerProvider)
    {
      this.RegionManager = containerProvider.Resolve<IRegionManager>();

      this.RegionManager.RegisterViewWithRegion("EmployeesRegion", typeof(EmployeesView));
    }

    public void RegisterTypes(IContainerRegistry containerRegistry)
    {

    }
  }
}