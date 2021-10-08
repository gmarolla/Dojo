
using Dojo.Services;
using System.Data;

namespace Dojo.Controller
{
    public class PersonListController
    {
        private PersonListService personListService = new PersonListService();

        public DataTable RetrieveListOfPersons()
        {
            return personListService.RetrieveListOfPersons();
        }
    }
}
