namespace Gamadu.PVA.Views.Resources
{
  using Prism.Ioc;
  using Prism.Modularity;
  using Prism.Regions;

  public class ResourcesModule : IModule
  {
    public IRegionManager RegionManager { get; set; }

    public void OnInitialized(IContainerProvider containerProvider)
    {
      this.RegionManager = containerProvider.Resolve<IRegionManager>();

      this.RegionManager.RegisterViewWithRegion("ResourcesRegion", typeof(Views.ResourcesView));
    }

    public void RegisterTypes(IContainerRegistry containerRegistry)
    {
    }
  }
}