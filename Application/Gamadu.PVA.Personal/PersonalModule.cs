using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

namespace Gamadu.PVA.Personal
{
  public class PersonalModule : IModule
  {
    public IRegionManager RegionManager { get; set; }

    public void OnInitialized(IContainerProvider containerProvider)
    {
      this.RegionManager = containerProvider.Resolve<IRegionManager>();

      this.RegionManager.RegisterViewWithRegion("PersonalModuleView", typeof(Views.PersonalView));
    }

    public void RegisterTypes(IContainerRegistry containerRegistry)
    {

    }
  }
}