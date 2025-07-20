using fotbalTeam.Domain.Entities.Interfaces;
using System.ComponentModel.DataAnnotations.Schema;

namespace fotbalTeam.Domain.Entities
{
    [Table(nameof(Match))]
    public class Match : IEntity<int>
    {
        public int Id { get; set; }
        public string? Opponent { get; set; }
        public DateTime Date { get; set; }
        public string? Location { get; set; }
    }
}