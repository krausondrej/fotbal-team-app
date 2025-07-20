using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using fotbalTeam.Application.Abstraction;
using fotbalTeam.Domain.Entities;
using fotbalTeam.Infrastructure.Identity.Enums;

namespace fotbalTeam.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = nameof(Roles.Admin) + ", " + nameof(Roles.Manager))]
    public class TrainingController : Controller
    {
        ITrainingAppService _trainingAppService;
        public TrainingController(ITrainingAppService trainingAppService)
        {
            _trainingAppService = trainingAppService;
        }

        public IActionResult Select()
        {
            IList<Training> trainings = _trainingAppService.Select();
            return View(trainings);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var training = new Training
            {
                Date = DateTime.Now,
                Description = string.Empty
            };
    
            return View(training);
        }

        [HttpPost]
        public IActionResult Create(Training training)
        {
            ModelState.Remove("Trainings");
            if (ModelState.IsValid)
            {
                _trainingAppService.Create(training);
                return RedirectToAction(nameof(TrainingController.Select));
            }
            return View(training);
        }

        public IActionResult Delete(int id)
        {
            bool deleted = _trainingAppService.Delete(id);
            if (deleted)
            {
                return RedirectToAction(nameof(Select));
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var training = _trainingAppService.Select().FirstOrDefault(t => t.Id == id);
            if (training == null)
            {
                return NotFound();
            }

            return View(training);
        }

        [HttpPost]
        public IActionResult Edit(Training training)
        {
            if (ModelState.IsValid)
            {
                bool updated = _trainingAppService.Update(training);
                if (updated)
                {
                    return RedirectToAction(nameof(Select));
                }
                else
                {
                    return View(training);
                }
            }
            return View(training);
        }
    }
}
