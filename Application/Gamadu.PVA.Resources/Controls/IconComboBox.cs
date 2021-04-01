namespace Gamadu.PVA.Resources.Controls
{
  using MaterialDesignThemes.Wpf;
  using System.Windows;
  using System.Windows.Controls;

  public class IconComboBox : ComboBox
  {
    static IconComboBox()
    {
      DefaultStyleKeyProperty.OverrideMetadata(typeof(IconComboBox), new FrameworkPropertyMetadata(typeof(IconComboBox)));
    }

    public PackIconKind Icon
    {
      get => (PackIconKind)this.GetValue(IconProperty);
      set => this.SetValue(IconProperty, value);
    }

    // Using a DependencyProperty as the backing store for Icon.  This enables animation, styling, binding, etc...
    public static readonly DependencyProperty IconProperty =
        DependencyProperty.Register("Icon", typeof(PackIconKind), typeof(IconComboBox), new PropertyMetadata(default(PackIconKind)));
  }
}
