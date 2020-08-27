using FP.AspNetTraining.PersonsWebApp.Business;
using FP.AspNetTraining.PersonsWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Instrumentation;
using System.Web.Mvc;

namespace FP.AspNetTraining.PersonsWebApp.Controllers
{
    public class PersonController : Controller
    {
        PersonRepository personRepository = new PersonRepository(@"c:\temp\persons.xml");

        // GET: Person
        public ActionResult Index()
        {
            InitViewBag();
            var entities = personRepository.GetPersons();
            Person[] model = entities.Select(x => MapEntityToModel(x)).ToArray();
            return View(model);
        }

        public ActionResult Create()
        {
            InitViewBag();
            var model = new Person
            {
                Id = Guid.NewGuid()
            };
            return View("Edit", model);
        }

        public ActionResult Edit(Guid id)
        {
            InitViewBag();
            var entity = personRepository.GetPersons().FirstOrDefault(x => x.Id == id);
            var model = MapEntityToModel(entity);
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(Person person)
        {
            var entity = new PersonEntity
            {
                Id = person.Id,
                FirstName = person.FirstName,
                Name = person.Name,
                Birthday = person.Birthday,
                Location = person.Location
            };
            personRepository.SavePerson(entity);
            return RedirectToAction("Index");
        }

        private void InitViewBag()
        {
            var locations = new List<SelectListItem>()
            {
                new SelectListItem{Text = "", Value = ""},
                new SelectListItem{Text = "Hamburg", Value = "HH"},
                new SelectListItem{Text = "Nordrhein-Westfalen", Value = "NRW"},
                new SelectListItem{Text = "Bayern", Value = "BY"},
                new SelectListItem{Text = "Rheinland-Pfalz", Value = "RLP"}
            };
            ViewBag.Locations = locations;

        }

        private Person MapEntityToModel(PersonEntity entity)
        {
            return new Person
            {
                Birthday = entity.Birthday,
                FirstName = entity.FirstName,
                Name = entity.Name,
                Id = entity.Id,
                Location = entity.Location
            };
        }
    }
}