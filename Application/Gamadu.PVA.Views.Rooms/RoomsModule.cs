﻿using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

namespace Gamadu.PVA.Views.Rooms
{
  public class RoomsModule : IModule
  {
    public IRegionManager RegionManager { get; set; }

    public void OnInitialized(IContainerProvider containerProvider)
    {
      this.RegionManager = containerProvider.Resolve<IRegionManager>();

      this.RegionManager.RegisterViewWithRegion("RoomsRegion", typeof(Views.RoomsView));
    }

    public void RegisterTypes(IContainerRegistry containerRegistry)
    {

    }
  }
}