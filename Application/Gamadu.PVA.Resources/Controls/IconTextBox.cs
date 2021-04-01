namespace Gamadu.PVA.Resources.Controls
{
  using MaterialDesignThemes.Wpf;
  using System.Windows;
  using System.Windows.Controls;

  public class IconTextBox : TextBox
  {
    static IconTextBox()
    {
      DefaultStyleKeyProperty.OverrideMetadata(typeof(IconTextBox), new FrameworkPropertyMetadata(typeof(IconTextBox)));
    }

    public PackIconKind Icon
    {
      get => (PackIconKind)this.GetValue(IconProperty);
      set => this.SetValue(IconProperty, value);
    }

    // Using a DependencyProperty as the backing store for Icon.  This enables animation, styling, binding, etc...
    public static readonly DependencyProperty IconProperty =
        DependencyProperty.Register("Icon", typeof(PackIconKind), typeof(IconTextBox), new PropertyMetadata(default(PackIconKind)));
  }
}
