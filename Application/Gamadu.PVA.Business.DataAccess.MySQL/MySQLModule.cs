namespace Gamadu.PVA.Core.DataAccess.MySQL
{
  using Prism.Ioc;
  using Prism.Modularity;

  [Module(ModuleName = "MySQLModule")]
  public class MySQLModule : IModule
  {
    public void OnInitialized(IContainerProvider containerProvider)
    {
    }

    public void RegisterTypes(IContainerRegistry containerRegistry) => containerRegistry.Register<IAllDataAccess, MySQLDataAccess>("MySQL");
  }
}