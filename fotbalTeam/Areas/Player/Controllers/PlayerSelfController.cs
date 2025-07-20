using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using fotbalTeam.Application.Abstraction;
using fotbalTeam.Domain.Entities;
using fotbalTeam.Infrastructure.Identity.Enums;
using System.Collections.Generic;

namespace fotbalTeam.Areas.Player.Controllers
{
    [Area("Player")]
    [Authorize(Roles = nameof(Roles.Admin) + ", " + nameof(Roles.Manager) + ", " + nameof(Roles.Player))]
    public class SelectViewModel
    {
        public IList<Match> Matches { get; set; }
        public IList<Performance> Performances { get; set; }
        public IList<Domain.Entities.Player> Players { get; set; }
        public IList<Training> Trainings { get; set; }
    }

    public class PlayerSelfController : Controller
    {
        private readonly IMatchAppService _matchAppService;
        private readonly IPerformanceAppService _performanceAppService;
        private readonly IPlayerAppService _playerAppService;
        private readonly ITrainingAppService _trainingAppService;

        // Injecting services through the constructor
        public PlayerSelfController(IMatchAppService matchAppService,
            IPerformanceAppService performanceAppService,
            IPlayerAppService playerAppService,
            ITrainingAppService trainingAppService)
        {
            _matchAppService = matchAppService;
            _performanceAppService = performanceAppService;
            _playerAppService = playerAppService;
            _trainingAppService = trainingAppService;
        }

        // Action for the Select view
        public IActionResult Select()
        {
            // Get all data from services
            IList<Match> matches = _matchAppService.Select();
            IList<Performance> performances = _performanceAppService.Select();
            IList<Domain.Entities.Player> players = _playerAppService.Select();
            IList<Training> trainings = _trainingAppService.Select();

            // Create the ViewModel
            var model = new SelectViewModel
            {
                Matches = matches,
                Performances = performances,
                Players = players,
                Trainings = trainings
            };

            // Return the Select view with the model
            return View("~/Areas/Player/Views/PlayerSchedule/Select.cshtml", model);
        }
    }
}