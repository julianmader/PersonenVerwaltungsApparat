namespace TestConsole
{
  using Gamadu.PVA.Core.DataAccess;
  using Gamadu.PVA.Core.DataAccess.MySQL;
  using Gamadu.PVA.Core.Models;
  using System.Collections.Generic;

  internal class Program
  {
    private static void Main(string[] args)
    {
      IAllDataAccess dataAccess = new MySQLDataAccess("localhost", "db_pva", "root", string.Empty);

      SaveEmployee(dataAccess);
      //DeleteEmployee(dataAccess);

      //GetEmployee(dataAccess);
      GetAllEmployees(dataAccess);

      DeleteAllEmployees(dataAccess);

      System.Console.ReadLine();
    }

    private static void SaveEmployee(IAllDataAccess dataAccess)
    {
      IEmployee employee = new Employee()
      {
        Matchcode = "Test1",
        Gender = Gamadu.PVA.Core.Enums.Gender.Male
      };

      System.Console.WriteLine(dataAccess.SaveEmployee(employee));
    }

    private static void UpdateEmployee(IAllDataAccess dataAccess)
    {
      IEmployee employee = new Employee()
      {
        Matchcode = "Test3",
        Forename = "Sven"
      };

      System.Console.WriteLine(dataAccess.UpdateEmployee(employee));
    }

    private static void DeleteEmployee(IAllDataAccess dataAccess)
    {
      System.Console.WriteLine(dataAccess.DeleteEmployee(10));
    }

    private static void DeleteAllEmployees(IAllDataAccess dataAccess)
    {
      System.Console.WriteLine(dataAccess.DeleteEmployees());
    }

    private static void GetAllEmployees(IAllDataAccess dataAccess)
    {
      IEnumerable<IEmployee> employees = dataAccess.GetEmployees();

      foreach (IEmployee employee in employees)
      {
        System.Console.WriteLine(employee.ID);
        System.Console.WriteLine(employee.Matchcode);
      }
    }

    private static void GetEmployee(IAllDataAccess dataAccess)
    {
      IEmployee employee = dataAccess.GetEmployee(1);

      System.Console.WriteLine(employee.Matchcode);
    }
  }
}