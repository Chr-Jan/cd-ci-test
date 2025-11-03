using Microsoft.AspNetCore.Mvc;
using ValidateTheNameModelBinding.Models;
using ValidateTheNameModelBinding.Util;
using System;

namespace ValidateTheNameWebApplication.Controllers
{
    public class NameController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            // Startview med tomt resultat
            return View("Index", new { nameIsValid = false, showNameEvaluation = false });
        }

        [HttpPost]
        public IActionResult ValidateName(PersonDTO personDto)
        {
            // Tjek om ModelState (NotNull osv.) er gyldigt
            if (!ModelState.IsValid)
            {
                return View("Index", new { nameIsValid = false, showNameEvaluation = true });
            }

            try
            {
                // Konverter DTO-strenge til domæneprimitiver
                var first = new Firstname(personDto.Firstname);
                var last = new Lastname(personDto.Lastname);

                // Opret Person med domæneprimitiver
                var personWithInvariance = new Person(first, last);

                // Gem personen i repository (eller database)
                PersonRepository personRepository = new PersonRepository();
                personRepository.AddPerson(personWithInvariance);

                // Returner resultat med gyldigt navn
                return View("Index", new { nameIsValid = true, showNameEvaluation = true });
            }
            catch (Exception ex)
            {
                // Hvis validering fejler, vis fejl
                ModelState.AddModelError(string.Empty, ex.Message);
                return View("Index", new { nameIsValid = false, showNameEvaluation = true });
            }
        }
    }
}
