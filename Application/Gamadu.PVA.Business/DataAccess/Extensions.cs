namespace Gamadu.PVA.Core.DataAccess
{
  using Gamadu.PVA.Core.Models;

  public static class Extensions
  {
    public static int SaveOrUpdateEmployee(this IAllDataAccess dataAccess, IEmployee employee)
    {
      return employee.ID == null ? dataAccess.SaveEmployee(employee) : dataAccess.UpdateEmployee(employee);
    }

    public static int SaveOrUpdateDepartment(this IAllDataAccess dataAccess, IDepartment department)
    {
      return department.ID == null ? dataAccess.SaveDepartment(department) : dataAccess.UpdateDepartment(department);
    }

    public static int SaveOrUpdatePosition(this IAllDataAccess dataAccess, IPosition position)
    {
      return position.ID == null ? dataAccess.SavePosition(position) : dataAccess.UpdatePosition(position);
    }

    public static int SaveOrUpdateContract(this IAllDataAccess dataAccess, IContract contract)
    {
      return contract.ID == null ? dataAccess.SaveContract(contract) : dataAccess.UpdateContract(contract);
    }

    public static int SaveOrUpdateRoom(this IAllDataAccess dataAccess, IRoom room)
    {
      return room.ID == null ? dataAccess.SaveRoom(room) : dataAccess.UpdateRoom(room);
    }
  }
}