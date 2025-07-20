using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using fotbalTeam.Application.Abstraction;
using fotbalTeam.Domain.Entities;
using fotbalTeam.Infrastructure.Identity.Enums;

namespace fotbalTeam.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = nameof(Roles.Admin) + ", " + nameof(Roles.Manager))]
    public class MatchController : Controller
    {
        IMatchAppService _matchAppService;
        public MatchController(IMatchAppService matchAppService)
        {
            _matchAppService = matchAppService;
        }

        public IActionResult Select()
        {
            IList<Match> matches = _matchAppService.Select();
            return View(matches);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Match match)
        {
            ModelState.Remove("Matches");
            if (ModelState.IsValid)
            {
                _matchAppService.Create(match);
                return RedirectToAction(nameof(MatchController.Select));
            }
            return View(match);
        }
        public IActionResult Delete(int id)
        {
            bool deleted = _matchAppService.Delete(id);
            if (deleted)
            {
                return RedirectToAction(nameof(MatchController.Select));
            }
            else
                return NotFound();
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var match = _matchAppService.Select().FirstOrDefault(c => c.Id == id);
            if (match == null)
            {
                return NotFound();
            }

            return View(match);
        }

        [HttpPost]
        public IActionResult Edit(Match match)
        {
            ModelState.Remove("Matches");
            if (ModelState.IsValid)
            {
                bool updated = _matchAppService.Update(match);
                if (updated)
                {
                    return RedirectToAction(nameof(Select));
                }
                else
                {
                    return View(match);
                }
            }
            return View(match);
        }
    }
}
