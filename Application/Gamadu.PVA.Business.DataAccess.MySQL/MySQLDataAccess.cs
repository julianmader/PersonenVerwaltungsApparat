namespace Gamadu.PVA.Business.DataAccess.MySQL
{
  using Dapper;
  using Gamadu.PVA.Business.Models;
  using MySql.Data.MySqlClient;
  using System;
  using System.Collections.Generic;
  using System.Data;

  public partial class MySQLDataAccess : IAllDataAccess
  {
    /// <summary>
    /// The connection string.
    /// </summary>
    private string connectionString;

    /// <summary>
    /// Initializes a new MySQL data access instance.
    /// </summary>
    /// <param name="server">The server hostname.</param>
    /// <param name="database">The database name.</param>
    /// <param name="user">The user ID.</param>
    /// <param name="password">The user password.</param>
    public MySQLDataAccess(string server, string database, string user, string password)
    {
      this.DefineConnection(server, database, user, password);
    }

    /// <summary>
    /// Initializes a new MySQL data access instance.
    /// </summary>
    public MySQLDataAccess()
    {

    }

    /// <summary>
    /// Defines the connection credentials.
    /// </summary>
    /// <param name="server">The server hostname.</param>
    /// <param name="database">The database name.</param>
    /// <param name="user">The user ID.</param>
    /// <param name="password">The user password.</param>
    public void DefineConnection(string server, string database, string user, string password)
    {
      MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder()
      {
        Server = server,
        Database = database,
        UserID = user,
        Password = password,
        ConnectionTimeout = 10
      };

      this.connectionString = builder.ConnectionString;
    }

    /// <summary>
    /// Creates the <see cref="IDbConnection"/> object.
    /// </summary>
    private IDbConnection GetDbConnection()
    {
      return new MySqlConnection(this.connectionString);
    }
  }
}
