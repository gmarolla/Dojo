using Dojo.DAO;
using Dojo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dojo.Services
{
    public class PersonService
    {
        PersonDAO personDao = new PersonDAO();
        public PersonEntity CreatePerson(string FirstName, string SecondName, DateTime DateOfBirth)
        {
            return personDao.CreatePerson(FirstName,SecondName,DateOfBirth);
        }
    }
}
