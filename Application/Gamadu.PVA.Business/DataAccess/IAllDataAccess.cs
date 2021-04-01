namespace Gamadu.PVA.Core.DataAccess
{
  /// <summary>
  /// Interface for the data access for all objects.
  /// </summary>
  public interface IAllDataAccess : IEmployeeDataAccess, IContractDataAccess, IDepartmentDataAccess, IPositionDataAccess, IRoomDataAccess
  {
  }
}