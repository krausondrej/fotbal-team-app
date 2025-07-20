using fotbalTeam.Application.Abstraction;
using fotbalTeam.Domain.Entities;
using fotbalTeam.Infrastructure.Database;


namespace fotbalTeam.Application.Implementation
{
    public class CarouselAppService : ICarouselAppService
    {
        FotbalTeamDbContext _mylearningDbContext;
        public CarouselAppService(FotbalTeamDbContext fotbalteamDbContext)
        {
            _mylearningDbContext = fotbalteamDbContext;
        }
        public IList<Carousel> Select()
        {
            return _mylearningDbContext.Carousels.ToList();
        }
    }
}
