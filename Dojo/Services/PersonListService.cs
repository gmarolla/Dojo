using Dojo.DAO;
using System.Data;

namespace Dojo.Services
{

    public class PersonListService
    {
        PersonDAO personDao = new PersonDAO();
        public DataTable RetrieveListOfPersons()
        {
            return personDao.GetDataTable();
        }
    }
}
