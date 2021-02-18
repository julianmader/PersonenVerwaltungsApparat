﻿using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

namespace Gamadu.PVA.Views.Departments
{
  public class DepartmentsModule : IModule
  {
    public IRegionManager RegionManager { get; set; }

    public void OnInitialized(IContainerProvider containerProvider)
    {
      this.RegionManager = containerProvider.Resolve<IRegionManager>();

      this.RegionManager.RegisterViewWithRegion("DepartmentsRegion", typeof(Views.DepartmentsView));
    }

    public void RegisterTypes(IContainerRegistry containerRegistry)
    {

    }
  }
}