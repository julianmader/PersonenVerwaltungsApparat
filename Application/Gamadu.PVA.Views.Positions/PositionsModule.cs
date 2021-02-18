using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

namespace Gamadu.PVA.Views.Positions
{
  public class PositionsModule : IModule
  {
    public IRegionManager RegionManager { get; set; }

    public void OnInitialized(IContainerProvider containerProvider)
    {
      this.RegionManager = containerProvider.Resolve<IRegionManager>();

      this.RegionManager.RegisterViewWithRegion("PositionsRegion", typeof(Views.PositionsView));
    }

    public void RegisterTypes(IContainerRegistry containerRegistry)
    {

    }
  }
}