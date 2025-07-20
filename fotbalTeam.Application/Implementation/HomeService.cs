using fotbalTeam.Application.Abstraction;
using fotbalTeam.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fotbalTeam.Application.Implementation
{
    public class HomeService : IHomeService
    {
        IMatchAppService _matchAppService;
        ICarouselAppService _carouselAppService;
        public HomeService(IMatchAppService matchAppService,
            ICarouselAppService carouselAppService)
        {
            _matchAppService = matchAppService;
            _carouselAppService = carouselAppService;
        }
        public CarouselMatchViewModel GetIndexViewModel()
        {
            CarouselMatchViewModel viewModel = new CarouselMatchViewModel();
            viewModel.Matches = _matchAppService.Select();
            viewModel.Carousels = _carouselAppService.Select();
            return viewModel;
        }
    }
}