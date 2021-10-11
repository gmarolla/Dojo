using NUnit.Framework;
using Moq;
using System;
using Dojo.DAO;
using Dojo.Models;
using System.Data;
using System.Data.SqlClient;
using Dojo.Services;

namespace Dojo_NunitTest
{
    public class PersonDAOTest
    {
        PersonDAO personDAO;
        Mock<IDbConnection> mockDbConnection;
        [SetUp]
        public void Setup()
        {
            Mock<IDbDataParameter> mockIDbParameter = new Mock<IDbDataParameter>();
            IDbDataParameter DbParameter = mockIDbParameter.Object;
            Mock<IDbCommand> mockDbCommand = new Mock<IDbCommand>();
            IDbCommand DbCommand = mockDbCommand.Object;
            Mock<IDataParameterCollection> mockDataParameterCollection = new Mock<IDataParameterCollection>();
            mockDbCommand.Setup(x => x.Parameters).Returns(mockDataParameterCollection.Object);
            mockDbCommand.Setup(x => x.CreateParameter()).Returns(DbParameter);
            mockDbCommand.Setup(x => x.ExecuteScalar()).Returns(1);

            mockDbConnection = new Mock<IDbConnection>();
            IDbConnection DbConnection = mockDbConnection.Object;
            mockDbConnection.Setup(x => x.CreateCommand()).Returns(DbCommand);


            Mock<IConnectionManager> mockConnectionManager = new Mock<IConnectionManager>();
            IConnectionManager ConnectionManager = mockConnectionManager.Object;

            mockConnectionManager.Setup(x => x.CreateConnection()).Returns(DbConnection);


            personDAO = new PersonDAO(ConnectionManager);
        }

        [Test]
        public void CreatePerson_InsertCorrectPerson()
        {
            //given
            string FirstName = "Giuseppe";
            string LastName = "Marolla";
            DateTime DateOfBirth = new DateTime(1989, 07, 14);
            PersonEntity personExpected = new PersonEntity(1, FirstName, LastName, DateOfBirth);
            //when
            PersonEntity personActual = personDAO.CreatePerson(FirstName, LastName, DateOfBirth);
            //then
            Assert.AreEqual(personExpected.ID, personActual.ID);
            Assert.AreEqual(personExpected.Name, personActual.Name);
            Assert.AreEqual(personExpected.Surname, personActual.Surname);
            Assert.AreEqual(personExpected.DateOfBirth, personActual.DateOfBirth);
            mockDbConnection.Verify(x => x.Open(), Times.Exactly(1));

        }
        [Test]
        public void CreatePerson_Colseconnextion()
        {
            //given
            string FirstName = "Giuseppe";
            string LastName = "Marolla";
            DateTime DateOfBirth = new DateTime(1989, 07, 14);

            mockDbConnection.Setup(x => x.State).Returns(ConnectionState.Open);
            //when
            PersonEntity personActual = personDAO.CreatePerson(FirstName, LastName, DateOfBirth);
            //then
            mockDbConnection.Verify(x => x.Close(), Times.Exactly(1));
        }
    }
}