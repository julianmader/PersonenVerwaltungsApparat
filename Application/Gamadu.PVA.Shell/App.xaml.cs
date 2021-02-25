namespace Gamadu.PVA.Shell
{
  using Gamadu.PVA.Shell.Views;
  using Prism.Ioc;
  using Prism.Modularity;
  using Prism.Unity;
  using System.Windows;

  /// <summary>
  /// Interaction logic for "App.xaml"
  /// </summary>
  public partial class App : PrismApplication
  {
    /// <inheritdoc/>
    protected override void RegisterTypes(IContainerRegistry containerRegistry)
    {
    }

    /// <inheritdoc/>
    protected override IModuleCatalog CreateModuleCatalog()
    {
      return new DirectoryModuleCatalog() { ModulePath = @".\" };
    }

    /// <inheritdoc/>
    protected override Window CreateShell()
    {
      return this.Container.Resolve<ShellView>();
    }
  }
}
