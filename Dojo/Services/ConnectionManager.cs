using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Dojo.Services
{
    public interface IConnectionManager
    {
        public IDbConnection CreateConnection();

    }
    public class ConnectionManager : IConnectionManager
    {
        private IDbConnection _connection;
       public IDbConnection CreateConnection()
        {
            if(_connection == null)
            {
                _connection = new SqlConnection(Connection.connectionString);
            }

            return _connection;
        }




    }
}
