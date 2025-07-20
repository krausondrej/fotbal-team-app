using fotbalTeam.Application.ViewModels;

namespace fotbalTeam.Application.Abstraction
{
    public interface IHomeService
    {
        CarouselMatchViewModel GetIndexViewModel();

    }
}