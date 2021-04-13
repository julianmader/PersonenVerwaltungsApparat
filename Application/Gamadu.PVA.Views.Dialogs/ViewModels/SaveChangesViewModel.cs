namespace Gamadu.PVA.Views.Dialogs.ViewModels
{
  using Prism.Commands;
  using Prism.Mvvm;
  using Prism.Services.Dialogs;
  using System;

  public class SaveChangesViewModel : BindableBase, IDialogAware
  {
    #region Properties

    public event Action<IDialogResult> RequestClose;

    public string Title { get; }

    #endregion Properties

    public SaveChangesViewModel()
    {
      this.Title = "Save changes";

      this.InitializeCommands();
    }

    #region Methods

    /// <summary>
    /// Initializes the commands.
    /// </summary>
    private void InitializeCommands() => this.CloseCommand = new DelegateCommand<bool?>(this.OnCloseCommand);

    #endregion Methods

    #region Commands

    public DelegateCommand<bool?> CloseCommand { get; private set; }

    private void OnCloseCommand(bool? accept)
    {
      ButtonResult buttonResult = ButtonResult.None;

      if ((bool)accept) buttonResult = ButtonResult.OK;
      if (!(bool)accept) buttonResult = ButtonResult.Cancel;

      IDialogResult dialogResult = new DialogResult(buttonResult);

      this.RaiseRequestClose(dialogResult);
    }

    public void RaiseRequestClose(IDialogResult dialogResult) => RequestClose?.Invoke(dialogResult);

    public bool CanCloseDialog() => true;

    public void OnDialogClosed()
    {
    }

    public void OnDialogOpened(IDialogParameters parameters)
    {
    }

    #endregion Commands
  }
}