using Dojo.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Dojo.Iterfaces
{
   public  interface IPersonDAO
    {
        public PersonEntity CreatePerson(IDbConnection connection, string FirstName, string SecondName, DateTime DateOfBirth);
    }
}
