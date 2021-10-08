using Dojo.Models;
using Dojo.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Dojo.DAO
{
    public class PersonDAO
    {
        private IConnectionManager connectionManager;
        public PersonDAO()
        {
            connectionManager = new ConnectionManager();
        }

        public PersonDAO(IConnectionManager connectionManager)
        {
            this.connectionManager = connectionManager;
        }

        public PersonEntity CreatePerson(string FirstName, string SecondName, DateTime DateOfBirth)
        {
            string InsertCommand = "INSERT INTO PERSON (NAME,SURNAME,DATEOFBIRTH) values (@name,@surname,@dateOfBirth); " +
                "SELECT current_value FROM sys.sequences WHERE name = 'person_counter' ; ";

            PersonEntity newPerson = null;
            
            using (IDbConnection connection = connectionManager.CreateConnection())
            {
                IDbCommand command = connection.CreateCommand();
                command.CommandText = InsertCommand;
                IDbDataParameter parameter = command.CreateParameter();
                parameter.ParameterName = "name";
                parameter.Value = FirstName;
                command.Parameters.Add(parameter);

                IDbDataParameter parameterSurname = command.CreateParameter();
                parameterSurname.ParameterName = "surname";
                parameterSurname.Value = SecondName;
                command.Parameters.Add(parameterSurname);

                IDbDataParameter parameterDate = command.CreateParameter();
                parameterDate.ParameterName = "dateOfBirth";
                parameterDate.Value = DateOfBirth;
                parameterDate.DbType = DbType.DateTime;
                command.Parameters.Add(parameterDate);

                try
                {
                    connection.Open();
                    int id = (int)command.ExecuteScalar();
                    newPerson = new PersonEntity(id, FirstName, SecondName, DateOfBirth);
                }
                catch (Exception ex)
                {
                    throw new Exception("Cannot create person", ex);
                }
                finally
                {
                    if (connection.State != ConnectionState.Closed)
                    {
                        connection.Close();
                    }
                }
            }

            return newPerson;
        }
    }
}
