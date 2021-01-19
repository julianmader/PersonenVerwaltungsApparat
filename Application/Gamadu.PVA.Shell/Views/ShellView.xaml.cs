namespace Gamadu.PVA.Shell.Views
{
  using System;
  using System.Windows;

  /// <summary>
  /// Interaktionlogic for ShellView.xaml
  /// </summary>
  public partial class ShellView : Window
  {
    public ShellView()
    {
      InitializeComponent();
    }

    /// <summary>
    /// Minimizes the window.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void On_Button_WindowMinimize_Click(object sender, RoutedEventArgs e)
    {
      SystemCommands.MinimizeWindow(this);
    }

    /// <summary>
    /// Maximizes the window.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void On_Button_WindowMaximize_Click(object sender, RoutedEventArgs e)
    {
      if (this.WindowState == WindowState.Normal)
      {
        this.BorderThickness = new Thickness(5);
        SystemCommands.MaximizeWindow(this);
      }
      else
      {
        this.BorderThickness = new Thickness(0);
        SystemCommands.RestoreWindow(this);
      }
    }

    /// <summary>
    /// Closes the window. Shuts down the app.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void On_Button_WindowClose_Click(object sender, RoutedEventArgs e)
    {
      Application.Current.Shutdown();
    }

    /// <summary>
    /// Adapts the window border thickness if the window state changes.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void On_Window_StateChanged(object sender, EventArgs e)
    {
      if (this.WindowState == WindowState.Normal)
      {
        this.BorderThickness = new Thickness(0);
      }
      else
      {
        this.BorderThickness = new Thickness(5);
      }
    }
  }
}
