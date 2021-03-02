namespace TestConsole
{
  using Gamadu.PVA.Business.DataAccess;
  using Gamadu.PVA.Business.DataAccess.MySQL;
  using Gamadu.PVA.Business.Models;
  using System.Collections.Generic;

  class Program
  {
    static void Main(string[] args)
    {
      IAllDataAccess dataAccess = new MySQLDataAccess("localhost", "db_pva", "root", string.Empty);

      SaveEmployee(dataAccess);
      //DeleteEmployee(dataAccess);

      //GetEmployee(dataAccess);
      GetAllEmployees(dataAccess);

      DeleteAllEmployees(dataAccess);

      System.Console.ReadLine();
    }

    static void SaveEmployee(IAllDataAccess dataAccess)
    {
      IEmployee employee = new Employee()
      {
        Matchcode = "Test1",
        Gender = Gamadu.PVA.Business.Enums.Gender.Male
      };

      System.Console.WriteLine(dataAccess.SaveEmployee(employee));
    }

    static void UpdateEmployee(IAllDataAccess dataAccess)
    {
      IEmployee employee = new Employee()
      {
        Matchcode = "Test3",
        Forename = "Sven"
      };

      System.Console.WriteLine(dataAccess.UpdateEmployee(employee));
    }

    static void DeleteEmployee(IAllDataAccess dataAccess)
    {
      System.Console.WriteLine(dataAccess.DeleteEmployee(10));
    }

    static void DeleteAllEmployees(IAllDataAccess dataAccess)
    {
      System.Console.WriteLine(dataAccess.DeleteEmployees());
    }

    static void GetAllEmployees(IAllDataAccess dataAccess)
    {
      IEnumerable<IEmployee> employees = dataAccess.GetEmployees();

      foreach (IEmployee employee in employees)
      {
        System.Console.WriteLine(employee.ID);
        System.Console.WriteLine(employee.Matchcode);
      }
    }

    static void GetEmployee(IAllDataAccess dataAccess)
    {
      IEmployee employee = dataAccess.GetEmployee(1);

      System.Console.WriteLine(employee.Matchcode);
    }
  }
}
