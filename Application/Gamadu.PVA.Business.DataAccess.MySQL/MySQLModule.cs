using Prism.Ioc;
using Prism.Modularity;

namespace Gamadu.PVA.Core.DataAccess.MySQL
{
  [Module(ModuleName = "MySQLModule")]
  public class MySQLModule : IModule
  {
    public void OnInitialized(IContainerProvider containerProvider)
    {
    }

    public void RegisterTypes(IContainerRegistry containerRegistry)
    {
      containerRegistry.Register<IAllDataAccess, MySQLDataAccess>("MySQL");
    }
  }
}