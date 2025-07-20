using fotbalTeam.Domain.Entities;
using System.Collections.Generic;

namespace fotbalTeam.Infrastructure.Seeding
{
    public class CarouselInit
    {
        public IList<Carousel> GetCarousels()
        {
            IList<Carousel> carousels = new List<Carousel>();
            carousels.Add(new Carousel()
            {
                Id = 1,
                ImageSrc = "/img/carousel/pic1.jpeg?v=2",
                ImageAlt = "First slide"
            });
            carousels.Add(new Carousel()
            {
                Id = 2,
                ImageSrc = "/img/carousel/pic2.jpeg?v=2",
                ImageAlt = "Second slide"
            });
            carousels.Add(new Carousel()
            {
                Id = 3,
                ImageSrc = "/img/carousel/pic3.jpeg?v=2",
                ImageAlt = "Third slide"
            });
            return carousels;
        }
    }
}
