using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using GW.AspNetTraining.TrainingsWebApp.Business;
using GW.AspNetTraining.TrainingsWebApp.Models;

namespace GW.AspNetTraining.TrainingsWebApp.Controllers
{
    public class TrainingController : Controller
    {
        ITrainingRepository _trainingRepository;
        public TrainingController(ITrainingRepository trainingRepository)
        {
            _trainingRepository = trainingRepository;
        }

        //TrainingRepository _trainingRepository = new TrainingRepository(@"c:\temp\trainings.xml");

        // GET: Training
        public ActionResult Index()
        {
            var models = _trainingRepository.GetTrainings().Select(MapEntityToModel).ToList();
            InitViewBag();
            return View(models);
        }

        public ActionResult Create()
        {
            var training = new Training
            {
                Id = Guid.NewGuid()
            };
            InitViewBag();
            return View("Edit", training);
        }

        public ActionResult Edit(Guid id)
        {
            var enitity = _trainingRepository.GetTrainings().FirstOrDefault(x => x.Id == id);
            if (enitity == null)
            {
                return RedirectToAction("Index");
            }
            var training = MapEntityToModel(enitity);
            InitViewBag();
            return View(training);
        }

        [HttpPost]
        public ActionResult Edit(Training training)
        {
            if (ModelState.IsValid)
            {
                var entity = MapModelToEntity(training);
                _trainingRepository.SaveTraining(entity);
                return RedirectToAction("Index");
            }
            InitViewBag();
            return View(training);
        }

        public ActionResult Delete(Guid id)
        {
            _trainingRepository.DeleteTraining(id);
            return RedirectToAction("Index");
        }

        private void InitViewBag()
        {
            var locations = new List<SelectListItem>();
            locations.Add(new SelectListItem { Text = "", Value = "" });
            locations.AddRange(_trainingRepository.GetLocations().Select(x=> new SelectListItem
            {
                Value = x.Id, Text = x.Description
            }));

            ViewBag.Locations = locations;
        }

        private Training MapEntityToModel(TrainingEntity entity)
        {
            return new Training
            {
                Approval = entity.Approval,
                Description = entity.Description,
                Duration = entity.Duration,
                Id = entity.Id,
                Level = entity.Level,
                Location = entity.Location,
                Title = entity.Title
            };
        }

        private TrainingEntity MapModelToEntity(Training training)
        {
            return new TrainingEntity
            {
                Approval = training.Approval,
                Description = training.Description,
                Duration = training.Duration,
                Id = training.Id,
                Level = training.Level,
                Location = training.Location,
                Title = training.Title
            };
        }
    }
}