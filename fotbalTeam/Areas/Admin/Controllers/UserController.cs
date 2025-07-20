using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using fotbalTeam.Application.Abstraction;
using fotbalTeam.Domain.Entities;
using fotbalTeam.Infrastructure.Identity;

namespace fotbalTeam.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class UserController : Controller
    {
        private readonly IUserAppService _userAppService;

        public UserController(IUserAppService userAppService)
        {
            _userAppService = userAppService;
        }

        public IActionResult Select()
        {
            var users = _userAppService.GetAllUsers();
            return View(users);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var user = _userAppService.GetUserById(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        [HttpPost]
        public IActionResult Edit(User user)
        {
            ModelState.Remove("Password");
            ModelState.Remove("Role");

            if (ModelState.IsValid)
            {
                var updated = _userAppService.UpdateUser(user);
                if (updated)
                {
                    return RedirectToAction(nameof(Select));
                }
                else
                {
                    return View(user);
                }
            }
            return View(user);
        }

        public IActionResult Delete(int id)
        {
            bool deleted = _userAppService.DeleteUser(id);
            if (deleted)
            {
                return RedirectToAction(nameof(Select));
            }
            else
            {
                return NotFound();
            }
        }
    }
}
