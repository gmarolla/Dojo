using Dojo.Controller;
using Dojo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Dojo.Pages
{
    public class IndexModel : PageModel
    {
        public PersonEntity person;
        public PersonController controller;
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
            controller = new PersonController();
        }

        public void OnGet()
        {
        }

        public void OnPost()
        {
            controller.CreatePerson(Request.Form["person.Name"], Request.Form["person.Surname"], DateTime.Parse(Request.Form["person.DateOfBirth"].ToString()));
        }



    }
}
