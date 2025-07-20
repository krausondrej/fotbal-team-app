using fotbalTeam.Domain.Entities.Interfaces;
using System.ComponentModel.DataAnnotations.Schema;

namespace fotbalTeam.Domain.Entities
{
    [Table(nameof(Training))]
    public class Training : IEntity<int>
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string? Description { get; set; }
    }
}