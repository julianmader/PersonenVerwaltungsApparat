namespace Gamadu.PVA.Core.Models
{
  public class CheckableEmployee : Employee, ICheckableEmployee
  {
    /// <summary>
    /// Backing field for <see cref="IsChecked"/>.
    /// </summary>
    private bool isChecked;

    /// <inheritdoc/>
    public bool IsChecked
    {
      get { return this.isChecked; }
      set { this.SetProperty(ref this.isChecked, value); }
    }
  }
}