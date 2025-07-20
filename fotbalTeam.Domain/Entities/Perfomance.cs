using fotbalTeam.Domain.Entities.Interfaces;
using System.ComponentModel.DataAnnotations.Schema;

namespace fotbalTeam.Domain.Entities
{
    [Table(nameof(Performance))]
    public class Performance : IEntity<int>
    {
        public int Id { get; set; }
        public int PlayerId { get; set; }
        public Player Player { get; set; } = null!;
        public int MatchId { get; set; }
        public Match Match { get; set; } = null!;
        public string? Stats { get; set; }
    }
}