using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using fotbalTeam.Application.Abstraction;
using fotbalTeam.Domain.Entities;
using fotbalTeam.Infrastructure.Identity.Enums;

namespace fotbalTeam.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = nameof(Roles.Admin) + ", " + nameof(Roles.Manager))]
    public class PlayerController : Controller
    {
        IPlayerAppService _playerAppService;
        public PlayerController(IPlayerAppService playerAppService)
        {
            _playerAppService = playerAppService;
        }

        public IActionResult Select()
        {
            IList<Domain.Entities.Player> players = _playerAppService.Select();
            return View(players);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Domain.Entities.Player player)
        {
            if (ModelState.IsValid)
            {
                _playerAppService.Create(player);
                return RedirectToAction(nameof(Select));
            }
            return View(player);
        }

        public IActionResult Delete(int id)
        {
            bool deleted = _playerAppService.Delete(id);
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
            var player = _playerAppService.Select().FirstOrDefault(p => p.Id == id);
            if (player == null)
            {
                return NotFound();
            }

            return View(player);
        }

        [HttpPost]
        public IActionResult Edit(Domain.Entities.Player player)
        {
            if (ModelState.IsValid)
            {
                bool updated = _playerAppService.Update(player);
                if (updated)
                {
                    return RedirectToAction(nameof(Select));
                }
                else
                {
                    return View(player);
                }
            }
            return View(player);
        }
    }
}
