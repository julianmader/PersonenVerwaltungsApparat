namespace Gamadu.PVA.Shell
{
  using Prism.Ioc;
  using Prism.Unity;
  using System.Windows;

  /// <summary>
  /// Interaction logic for "App.xaml"
  /// </summary>
  public partial class App : PrismApplication
  {
    /// <summary>
    /// Registers the types for dependency injection.
    /// </summary>
    /// <param name="containerRegistry"></param>
    protected override void RegisterTypes(IContainerRegistry containerRegistry)
    {
    }

    /// <summary>
    /// Creates the Shell window.
    /// </summary>
    /// <returns>The Shell window.</returns>
    protected override Window CreateShell()
    {
      return Container.Resolve<Shell>();
    }
  }
}
