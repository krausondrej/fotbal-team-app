using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fotbalTeam.Domain.Entities
{
    [Table(nameof(Carousel))]
    public class Carousel : Entity<int>
    {
        public string ImageSrc { get; set; }
        public string ImageAlt { get; set; }
    }
}