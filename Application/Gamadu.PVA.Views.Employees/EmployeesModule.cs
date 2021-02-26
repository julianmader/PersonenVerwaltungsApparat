using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

namespace Gamadu.PVA.Views.Employees
{
  public class EmployeesModule : IModule
  {
    public IRegionManager RegionManager { get; set; }

    public void OnInitialized(IContainerProvider containerProvider)
    {
      this.RegionManager = containerProvider.Resolve<IRegionManager>();

      this.RegionManager.RegisterViewWithRegion("EmployeesRegion", typeof(Views.EmployeesView));
    }

    public void RegisterTypes(IContainerRegistry containerRegistry)
    {

    }
  }
}