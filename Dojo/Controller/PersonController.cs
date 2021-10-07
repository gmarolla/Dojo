using Dojo.Models;
using Dojo.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dojo.Controller
{
    public class PersonController
    {
        private PersonService personService = new PersonService();

        public PersonEntity CreatePerson(string FirstName, string SecondName, DateTime DateOfBirth)
        {
            return personService.CreatePerson(FirstName, SecondName, DateOfBirth);
        }
    }
}
