namespace Gamadu.PVA.Views.Dialogs
{
  using Gamadu.PVA.Views.Dialogs.Views;
  using Prism.Ioc;
  using Prism.Modularity;

  [Module(ModuleName = "DialogsModule")]
  public class DialogsModule : IModule
  {
    public void OnInitialized(IContainerProvider containerProvider)
    {
    }

    public void RegisterTypes(IContainerRegistry containerRegistry)
    {
      containerRegistry.RegisterDialog<SelectRoomsView>("SelectRoomsDialog");
      containerRegistry.RegisterDialog<SelectEmployeesView>("SelectEmployeesDialog");
    }
  }
}