namespace Gamadu.PVA.Resources.Controls
{
  using MaterialDesignThemes.Wpf;
  using System.Windows;
  using System.Windows.Controls;

  public class IconExpander : Expander
  {
    static IconExpander()
    {
      DefaultStyleKeyProperty.OverrideMetadata(typeof(IconExpander), new FrameworkPropertyMetadata(typeof(IconExpander)));
    }

    public PackIconKind Icon
    {
      get { return (PackIconKind)this.GetValue(IconProperty); }
      set { this.SetValue(IconProperty, value); }
    }

    // Using a DependencyProperty as the backing store for Icon.  This enables animation, styling, binding, etc...
    public static readonly DependencyProperty IconProperty =
        DependencyProperty.Register("Icon", typeof(PackIconKind), typeof(IconExpander), new PropertyMetadata(default(PackIconKind)));
  }
}
