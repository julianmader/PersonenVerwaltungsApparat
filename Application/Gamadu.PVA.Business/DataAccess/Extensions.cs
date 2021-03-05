namespace Gamadu.PVA.Business.DataAccess
{
  using Gamadu.PVA.Business.Models;

  public static class Extensions
  {
    public static int SaveOrUpdateEmployee(this IAllDataAccess dataAccess, IEmployee employee)
    {
      if (employee.ID == null)
      {
        return dataAccess.SaveEmployee(employee);
      }

      return dataAccess.UpdateEmployee(employee);
    }
  }
}
