using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using fotbalTeam.Application.Abstraction;
using fotbalTeam.Domain.Entities;
using fotbalTeam.Infrastructure.Identity.Enums;

namespace fotbalTeam.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = nameof(Roles.Admin) + ", " + nameof(Roles.Manager))]
    public class PerformanceController : Controller
    {
        IPerformanceAppService _performanceAppService;
        public PerformanceController(IPerformanceAppService performanceAppService)
        {
            _performanceAppService = performanceAppService;
        }

        public IActionResult Select()
        {
            IList<Performance> performances = _performanceAppService.Select();
            return View(performances);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Performance performance)
        {
            ModelState.Remove("Performances");
            if (ModelState.IsValid)
            {
                _performanceAppService.Create(performance);
                return RedirectToAction(nameof(PerformanceController.Select));
            }
            return View(performance);
        }

        public IActionResult Delete(int id)
        {
            bool deleted = _performanceAppService.Delete(id);
            if (deleted)
            {
                return RedirectToAction(nameof(PerformanceController.Select));
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var performance = _performanceAppService.GetById(id);
            if (performance == null)
            {
                return NotFound();
            }
            return View(performance);
        }

        [HttpPost]
        public IActionResult Edit(Performance performance)
        {
            ModelState.Remove("Performances");
            if (ModelState.IsValid)
            {
                bool updated = _performanceAppService.Update(performance);
                if (updated)
                {
                    return RedirectToAction(nameof(Select));
                }
                else
                {
                    return View(performance);
                }
            }
            return View(performance);
        }
    }
}
