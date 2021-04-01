namespace Gamadu.PVA.Shell
{
  using Gamadu.PVA.Shell.Views;
  using Prism.Ioc;
  using Prism.Modularity;
  using Prism.Mvvm;
  using Prism.Unity;
  using System;
  using System.Globalization;
  using System.Reflection;
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
    protected override IModuleCatalog CreateModuleCatalog() => new DirectoryModuleCatalog() { ModulePath = @".\" };

    /// <inheritdoc/>
    protected override Window CreateShell() => this.Container.Resolve<ShellView>();

    protected override void ConfigureViewModelLocator()
    {
      base.ConfigureViewModelLocator();

      ViewModelLocationProvider.SetDefaultViewTypeToViewModelTypeResolver((viewType) =>
      {
        var viewName = viewType.FullName;

        if (viewName.Contains("Gamadu.PVA.Views."))
        {
          viewName = viewName.Replace("Gamadu.PVA.Views.", string.Empty);
          viewName = viewName.Replace(".Views.", ".ViewModels.");

          viewName = $"Gamadu.PVA.Views.{viewName}";
        }
        else
        {
          viewName = viewName.Replace(".Views.", ".ViewModels.");
        }

        var viewAssemblyName = viewType.GetTypeInfo().Assembly.FullName;
        var suffix = viewName.EndsWith("View") ? "Model" : "ViewModel";
        var viewModelName = String.Format(CultureInfo.InvariantCulture, "{0}{1}, {2}", viewName, suffix, viewAssemblyName);
        return Type.GetType(viewModelName);

      });
    }
  }
}
