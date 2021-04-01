namespace Gamadu.PVA.Resources.Controls
{
  using MaterialDesignThemes.Wpf;
  using System.Windows;
  using System.Windows.Controls;

  public class IconCheckDatePicker : DatePicker
  {
    static IconCheckDatePicker()
    {
      DefaultStyleKeyProperty.OverrideMetadata(typeof(IconCheckDatePicker), new FrameworkPropertyMetadata(typeof(IconCheckDatePicker)));
    }

    public PackIconKind Icon
    {
      get => (PackIconKind)this.GetValue(IconProperty);
      set => this.SetValue(IconProperty, value);
    }

    public bool IsChecked
    {
      get => (bool)this.GetValue(IsCheckedProperty);
      set => this.SetValue(IsCheckedProperty, value);
    }

    public string CheckBoxText
    {
      get => (string)this.GetValue(CheckBoxTextProperty);
      set => this.SetValue(CheckBoxTextProperty, value);
    }

    // Using a DependencyProperty as the backing store for CheckBoxText.  This enables animation, styling, binding, etc...
    public static readonly DependencyProperty CheckBoxTextProperty =
        DependencyProperty.Register("CheckBoxText", typeof(string), typeof(IconCheckDatePicker), new PropertyMetadata(null, CheckBoxTextChangedCallback));

    private static void CheckBoxTextChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
      IconCheckDatePicker input = (IconCheckDatePicker)d;
      input.SetValue(CheckBoxTextProperty, e.NewValue);
    }

    // Using a DependencyProperty as the backing store for IsChecked.  This enables animation, styling, binding, etc...
    public static readonly DependencyProperty IsCheckedProperty =
        DependencyProperty.Register("IsChecked", typeof(bool), typeof(IconCheckDatePicker), new PropertyMetadata(true, IsCheckedChangedCallback));

    private static void IsCheckedChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
      IconCheckDatePicker input = (IconCheckDatePicker)d;
      input.SetValue(IsCheckedProperty, e.NewValue);
    }

    // Using a DependencyProperty as the backing store for Icon.  This enables animation, styling, binding, etc...
    public static readonly DependencyProperty IconProperty =
        DependencyProperty.Register("Icon", typeof(PackIconKind), typeof(IconCheckDatePicker), new PropertyMetadata(default(PackIconKind)));
  }
}
