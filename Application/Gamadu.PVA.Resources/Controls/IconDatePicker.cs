namespace Gamadu.PVA.Resources.Controls
{
  using MaterialDesignThemes.Wpf;
  using System.Windows;
  using System.Windows.Controls;

  public class IconDatePicker : DatePicker
  {
    static IconDatePicker()
    {
      DefaultStyleKeyProperty.OverrideMetadata(typeof(IconDatePicker), new FrameworkPropertyMetadata(typeof(IconDatePicker)));
    }

    public PackIconKind Icon
    {
      get { return (PackIconKind)GetValue(IconProperty); }
      set { SetValue(IconProperty, value); }
    }

    // Using a DependencyProperty as the backing store for Icon.  This enables animation, styling, binding, etc...
    public static readonly DependencyProperty IconProperty =
        DependencyProperty.Register("Icon", typeof(PackIconKind), typeof(IconDatePicker), new PropertyMetadata(default(PackIconKind)));
  }
}
