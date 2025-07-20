using fotbalTeam.Domain.Entities.Interfaces;
using System.ComponentModel.DataAnnotations.Schema;

namespace fotbalTeam.Domain.Entities
{
    [Table(nameof(Player))]
    public class Player : IEntity<int>
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string? Position { get; set; }
        public int JerseyNumber { get; set; }
    }
}