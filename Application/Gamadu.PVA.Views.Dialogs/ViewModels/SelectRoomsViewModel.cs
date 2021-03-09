using Gamadu.PVA.Business.DataAccess;
using Gamadu.PVA.Business.Events;
using Gamadu.PVA.Business.Models;
using MaterialDesignThemes.Wpf;
using Prism.Commands;
using Prism.Events;
using Prism.Ioc;
using Prism.Mvvm;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Gamadu.PVA.Views.Dialogs.ViewModels
{
  public class SelectRoomsViewModel : BindableBase
  {
    #region Properties

    protected IContainerProvider ContainerProvider { get; set; }

    protected IRoomDataAccess DataAccess { get; set; }

    protected IEventAggregator EventAggregator { get; set; }

    protected string EventReceiver { get; set; }

    /// <summary>
    /// Backing field for <see cref="AvailableRooms"/>.
    /// </summary>
    private IEnumerable<IRoom> availableRooms;

    /// <summary>
    /// Gets or sets the value for the AvailableRooms.
    /// </summary>
    public IEnumerable<IRoom> AvailableRooms
    {
      get { return this.availableRooms; }
      set { this.SetProperty(ref this.availableRooms, value); }
    }

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
      this.ContainerProvider = container;

      this.SetDataAccess("MySQL");

      this.InitializeCommands();

      this.SetEventAggregator();

      this.PublishRequestSelectedRoomsEvent();
    }

    #region Methods

    #region External Event Handling

    /// <summary>
    /// Sets the event aggregator and configures the event handling.
    /// </summary>
    protected void SetEventAggregator()
    {
      this.EventAggregator = this.ContainerProvider.Resolve<IEventAggregator>();

      this.EventAggregator.GetEvent<SendSelectedRoomsEvent>().Subscribe(this.SelectedRoomsEventHandler);
    }

    /// <summary>
    /// Handles the selected rooms event.
    /// </summary>
    /// <param name="args"></param>
    protected void SelectedRoomsEventHandler(SendSelectedRoomsEventArgs args)
    {
      if (args.Receiver == null || !args.Receiver.Equals("SelectRoomsViewModel")) return;

      this.EventReceiver = args.Sender;
      this.SetCheckableRooms(args.SelectedRoomsIDs);
    }

    /// <summary>
    /// Publishes the request for the selected rooms.
    /// </summary>
    protected void PublishRequestSelectedRoomsEvent()
    {
      this.EventAggregator.GetEvent<RequestSelectedRoomsEvent>().Publish(new RequestSelectedRoomsEventArgs { Receiver = "EmployeesViewModel", Sender = "SelectRoomsViewModel" });
    }

    /// <summary>
    /// Publishes the selected rooms event.
    /// </summary>
    protected void PublishSelectedRoomsEvent()
    {
      SendSelectedRoomsEventArgs args = new SendSelectedRoomsEventArgs() { Receiver = this.EventReceiver};

      if (this.CheckableRooms == null)
      {
        args.SelectedRoomsIDs = new List<int>();
      }
      else
      {
        args.SelectedRoomsIDs = this.CheckableRooms.Where(cr => cr.IsChecked)?.Select(cr => (int)cr.ID).ToList();
      }

      this.EventAggregator.GetEvent<SendSelectedRoomsEvent>().Publish(args);
    }

    #endregion External Event Handling

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
    /// Gets all available rooms from the database.
    /// </summary>
    protected void RefreshAvailableRooms()
    {
      this.AvailableRooms = this.DataAccess.GetRooms();
    }

    /// <summary>
    /// Sets the checkable rooms collection, based on the available rooms.
    /// </summary>
    /// <param name="selectedIDs">The selected rooms' ids</param>
    protected void SetCheckableRooms(IEnumerable<int> selectedIDs)
    {
      this.RefreshAvailableRooms();

      if (this.AvailableRooms?.Any() == false) return;

      List<ICheckableRoom> temp = new List<ICheckableRoom>();

      foreach (IRoom room in this.AvailableRooms)
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
      if ((bool)accept)
        this.PublishSelectedRoomsEvent();

      DialogHost.Close("RootDialog");
    }

    #endregion CloseCommand

    #endregion Commands
  }
}