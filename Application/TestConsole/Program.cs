namespace TestConsole
{
  using Gamadu.PVA.Business.DataAccess;
  using Gamadu.PVA.Business.DataAccess.MySQL;
  using Gamadu.PVA.Business.Models;

  class Program
  {
    static void Main(string[] args)
    {
      IAllDataAccess dataAccess = new MySQLDataAccess("localhost", "db_pva", "root", string.Empty);
      IEmployee employee = new Employee()
      {
        Matchcode = "Test3",
        Forename = "Sven"
      };

      System.Console.WriteLine(dataAccess.SaveEmployee(employee)); 

      System.Console.ReadLine();
    }
  }
}
