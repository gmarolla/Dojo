using Dojo.DAO;
using Dojo.Models;
using Moq;
using NUnit.Framework;
using System;
using System.Data.SqlClient;

namespace Dojo_NunitTest
{
    public class PersonDAOTest
    {
        private PersonDAO personDAO;
        private Mock<SqlConnection> sqlConnection;
        private Mock<SqlCommand> sqlCommand;
        [SetUp]
        public void Setup()
        {
            sqlConnection = new Mock<SqlConnection>();
            sqlConnection.Setup(x => x.Open());

            sqlCommand = new Mock<SqlCommand>();
            sqlCommand.Setup(x => x.ExecuteScalar()).Returns(1);
        }

        [Test]
        public void Test1()
        {
            // GIVEN
            DateTime today = DateTime.Today;
            //WHEN
            PersonEntity newPersonActual = personDAO.CreatePerson("lala", "lolo", today);
            PersonEntity newPersonExpected = new PersonEntity(1, "lala", "lolo", today);
            //THEN
            Assert.AreEqual(newPersonExpected,newPersonActual);
        }
    }
}
