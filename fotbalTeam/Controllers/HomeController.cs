using Microsoft.AspNetCore.Mvc;
using fotbalTeam.Application.Abstraction;
using fotbalTeam.Application.ViewModels;
using fotbalTeam.Models;
using System.Diagnostics;

namespace fotbalTeam.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHomeService _homeService;

        public HomeController(ILogger<HomeController> logger, IHomeService homeService)
        {
            _logger = logger;
            _homeService = homeService;
        }
        public IActionResult Index()
        {
            CarouselMatchViewModel viewModel = _homeService.GetIndexViewModel();

            return View(viewModel);
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}