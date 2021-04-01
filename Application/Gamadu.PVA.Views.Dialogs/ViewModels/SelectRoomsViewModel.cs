using Gamadu.PVA.Core.DataAccess;
using Gamadu.PVA.Core.Models;
using Prism.Commands;
using Prism.Ioc;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Gamadu.PVA.Views.Dialogs.ViewModels
{
  public class SelectRoomsViewModel : BindableBase, IDialogAware
  {
    #region Properties

    public event Action<IDialogResult> RequestClose;

    protected IContainerProvider ContainerProvider { get; set; }

    protected IRoomDataAccess DataAccess { get; set; }

    public string Title { get; }

    /// <summary>
    /// Backing field for <see cref="CheckableRooms"/>.
    /// </summary>
    private ObservableCollection<ICheckableRoom> checkableRooms;

    /// <summary>
    /// Gets or sets the value for the AvailableRooms.
    /// </summary>
    public ObservableCollection<ICheckableRoom> CheckableRooms
    {
      get { return this.checkableRooms; }
      set { this.SetProperty(ref this.checkableRooms, value); }
    }

    #endregion Properties

    public SelectRoomsViewModel(IContainerProvider container)
    {
      this.Title = "Select Rooms";

      this.ContainerProvider = container;

      this.SetDataAccess("MySQL");

      this.InitializeCommands();
    }

    #region Methods

    /// <summary>
    /// Sets the data access.
    /// </summary>
    /// <param name="identification">The identification string of the instance.</param>
    protected void SetDataAccess(string identification = "")
    {
      this.DataAccess = this.ContainerProvider.Resolve<IAllDataAccess>(identification);
    }

    /// <summary>
    /// Initializes the commands.
    /// </summary>
    private void InitializeCommands()
    {
      this.CloseCommand = new DelegateCommand<bool?>(this.OnCloseCommand);
    }

    /// <summary>
    /// Sets the checkable rooms collection, based on the available rooms.
    /// </summary>
    /// <param name="selectedIDs">The selected rooms' ids</param>
    protected void SetCheckableRooms(IEnumerable<int> selectedIDs)
    {
      IEnumerable<IRoom> availableRooms = this.DataAccess.GetRooms();

      if (availableRooms?.Any() == false) return;

      List<ICheckableRoom> temp = new List<ICheckableRoom>();

      foreach (IRoom room in availableRooms)
      {
        ICheckableRoom checkableRoom = this.ContainerProvider.Resolve<ICheckableRoom>();

        if (selectedIDs != null)
          checkableRoom.IsChecked = selectedIDs.Contains((int)room.ID);
        else
          checkableRoom.IsChecked = false;
        checkableRoom.ID = room.ID;
        checkableRoom.Matchcode = room.Matchcode;
        checkableRoom.Name = room.Name;
        checkableRoom.RoomNumber = room.RoomNumber;
        checkableRoom.Size = room.Size;
        checkableRoom.FloorNumber = room.FloorNumber;
        checkableRoom.Description = room.Description;

        temp.Add(checkableRoom);
      }

      this.CheckableRooms = new ObservableCollection<ICheckableRoom>(temp);
    }

    #endregion Methods

    #region Commands

    #region CloseCommand

    public DelegateCommand<bool?> CloseCommand { get; private set; }

    private void OnCloseCommand(bool? accept)
    {
      ButtonResult buttonResult = ButtonResult.None;

      if ((bool)accept) buttonResult = ButtonResult.OK;
      if (!(bool)accept) buttonResult = ButtonResult.Cancel;

      IEnumerable<int> selectedIDs = this.CheckableRooms?.Where(cr => cr.IsChecked).Select(cr => (int)cr.ID).ToList();

      IDialogParameters dialogParameters = new DialogParameters();
      dialogParameters.Add("selectedIDs", selectedIDs);

      IDialogResult dialogResult = new DialogResult(buttonResult, dialogParameters);

      this.RaiseRequestClose(dialogResult);
    }

    public void RaiseRequestClose(IDialogResult dialogResult)
    {
      RequestClose?.Invoke(dialogResult);
    }

    public bool CanCloseDialog()
    {
      return true;
    }

    public void OnDialogClosed()
    {
    }

    public void OnDialogOpened(IDialogParameters parameters)
    {
      IEnumerable<int> selectedIDs = parameters.GetValue<IEnumerable<int>>("selectedIDs");

      this.SetCheckableRooms(selectedIDs);
    }

    #endregion CloseCommand

    #endregion Commands
  }
}