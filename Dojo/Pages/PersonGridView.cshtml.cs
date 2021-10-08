using Dojo.Controller;
using Dojo.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System.Data;

namespace Dojo.Pages
{
    public class PersonGridViewModel : PageModel
    {
        public PersonEntity person;
        public PersonListController controller;
        private readonly ILogger<PersonGridViewModel> _logger;

        public PersonGridViewModel(ILogger<PersonGridViewModel> logger)
        {
            _logger = logger;
            controller = new PersonListController();
        }

        public void OnGet()
        {
            controller.RetrieveListOfPersons();
        }
        public DataTable ReadDataTable()
        {
            return controller.RetrieveListOfPersons();

        }
        public void OnPost()
        {
            controller.RetrieveListOfPersons();
        }
    }
}
