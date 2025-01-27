﻿namespace Gamadu.PVA.Core.DataAccess
{
  using Gamadu.PVA.Core.Models;

  public static class Extensions
  {
    public static int SaveOrUpdateEmployee(this IBusinessObjectDataAccess dataAccess, IEmployee employee) => employee.ID == null ? dataAccess.SaveEmployee(employee) : dataAccess.UpdateEmployee(employee);

    public static int SaveOrUpdateDepartment(this IBusinessObjectDataAccess dataAccess, IDepartment department) => department.ID == null ? dataAccess.SaveDepartment(department) : dataAccess.UpdateDepartment(department);

    public static int SaveOrUpdatePosition(this IBusinessObjectDataAccess dataAccess, IPosition position) => position.ID == null ? dataAccess.SavePosition(position) : dataAccess.UpdatePosition(position);

    public static int SaveOrUpdateContract(this IBusinessObjectDataAccess dataAccess, IContract contract) => contract.ID == null ? dataAccess.SaveContract(contract) : dataAccess.UpdateContract(contract);

    public static int SaveOrUpdateRoom(this IBusinessObjectDataAccess dataAccess, IRoom room) => room.ID == null ? dataAccess.SaveRoom(room) : dataAccess.UpdateRoom(room);
  }
}