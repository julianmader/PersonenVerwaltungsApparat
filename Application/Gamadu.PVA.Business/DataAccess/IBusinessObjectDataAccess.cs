namespace Gamadu.PVA.Core.DataAccess
{
  /// <summary>
  /// Interface for the data access for all business objects.
  /// </summary>
  public interface IBusinessObjectDataAccess : IEmployeeDataAccess, IContractDataAccess, IDepartmentDataAccess, IPositionDataAccess, IRoomDataAccess
  {
  }
}