using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

namespace Gamadu.PVA.Contracts
{
  public class ContractsModule : IModule
  {
    public IRegionManager RegionManager { get; set; }

    public void OnInitialized(IContainerProvider containerProvider)
    {
      this.RegionManager = containerProvider.Resolve<IRegionManager>();

      this.RegionManager.RegisterViewWithRegion("ContractsRegion", typeof(Views.ContractsView));
    }

    public void RegisterTypes(IContainerRegistry containerRegistry)
    {

    }
  }
}