using Dojo.Models;
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
        public PersonEntity CreatePerson(string FirstName, string SecondName, DateTime DateOfBirth)
        {
            string InsertCommand = "INSERT INTO PERSON (NAME,SURNAME,DATEOFBIRTH) values (@name,@surname,@dateOfBirth); " +
                "SELECT current_value FROM sys.sequences WHERE name = 'person_counter' ; ";

            PersonEntity newPerson = null;

            using (SqlConnection connection = new SqlConnection(Connection.connectionString))
            {
                SqlCommand command = new SqlCommand(InsertCommand, connection);
                command.Parameters.AddWithValue("name", FirstName);
                command.Parameters.AddWithValue("surname", SecondName);
                command.Parameters.Add("dateOfBirth", SqlDbType.DateTime).Value = DateOfBirth;
                try
                {
                    connection.Open();
                    int id = (int)command.ExecuteScalar();
                    newPerson = new PersonEntity(id, FirstName, SecondName, DateOfBirth);
                }
                catch(Exception ex)
                {
                    throw new Exception("Cannot create person",ex);
                }
                finally
                {
                    if(connection.State != ConnectionState.Closed)
                    {
                        connection.Close();
                    }
                }
            }

            return newPerson;
        }
    }
}
