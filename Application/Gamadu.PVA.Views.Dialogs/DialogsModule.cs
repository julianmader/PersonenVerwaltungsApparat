using Gamadu.PVA.Views.Dialogs.Views;
using Prism.Ioc;
using Prism.Modularity;
using System.Windows.Controls;

namespace Gamadu.PVA.Views.Dialogs
{
  [Module(ModuleName = "DialogsModule")]
  public class DialogsModule : IModule
    {
    public void OnInitialized(IContainerProvider containerProvider)
    {
    }

    public void RegisterTypes(IContainerRegistry containerRegistry)
    {
      containerRegistry.Register<UserControl, SelectRoomsView>("SelectRoomsView");
    }
  }
}