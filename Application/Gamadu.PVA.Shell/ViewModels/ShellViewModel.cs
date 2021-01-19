﻿namespace Gamadu.PVA.Shell.ViewModels
{
  using Prism.Mvvm;

  public class ShellViewModel : BindableBase
  {
    private string title;

    /// <summary>
    /// Gets or sets the title of the ShellWindow.
    /// </summary>
    public string Title
    {
      get { return title; }
      set { SetProperty(ref title, value); }
    }

    public ShellViewModel()
    {
      this.Title = "Personen Verwaltungs Apparat";
    }
  }
}