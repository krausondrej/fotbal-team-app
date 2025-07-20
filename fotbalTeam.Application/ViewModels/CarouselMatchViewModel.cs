using fotbalTeam.Domain.Entities;


namespace fotbalTeam.Application.ViewModels
{
    public class CarouselMatchViewModel
    {
        public IList<Carousel>? Carousels { get; set; }
        public IList<Match>? Matches { get; set; }
    }
}
