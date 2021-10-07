using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dojo.Models
{
    public class PersonEntity
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime DateOfBirth { get; set; }

        public PersonEntity(int ID, string Name, string Surname, DateTime DateOfBirth)
        {
            this.ID = ID;
            this.Name = Name;
            this.Surname = Surname;
            this.DateOfBirth = DateOfBirth;

        }
    }
}
