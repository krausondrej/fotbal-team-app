using fotbalTeam.Domain.Entities.Interfaces;

namespace fotbalTeam.Domain.Entities
{
    public class Entity<TKey> : IEntity<TKey>
    {
        public TKey Id { get; set; }
    }
}