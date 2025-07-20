using fotbalTeam.Domain.Entities;

namespace fotbalTeam.Application.Abstraction
{
    public interface ICarouselAppService
    {
        IList<Carousel> Select();
    }
}
