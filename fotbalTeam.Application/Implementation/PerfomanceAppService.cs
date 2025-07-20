using fotbalTeam.Application.Abstraction;
using fotbalTeam.Domain.Entities;
using fotbalTeam.Infrastructure.Database; // Namespace pro ApplicationDbContext
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace fotbalTeam.Application.Implementation
{
    public class PerformanceAppService : IPerformanceAppService
    {
        private readonly FotbalTeamDbContext _context;

        public PerformanceAppService(FotbalTeamDbContext context)
        {
            _context = context;
        }

        // Metoda pro získání všech výkonů
        public IList<Performance> Select()
        {
            return _context.Performances.ToList(); // Načteme všechny výkony z databáze
        }

        // Metoda pro vytvoření nového výkonu
        public void Create(Performance performance)
        {
            _context.Performances.Add(performance); // Přidáme nový výkon do databáze
            _context.SaveChanges(); // Uložíme změny
        }

        // Metoda pro smazání výkonu podle ID
        public bool Delete(int id)
        {
            bool deleted = false;
            var performance = _context.Performances.FirstOrDefault(p => p.Id == id);
            if (performance != null)
            {
                _context.Performances.Remove(performance); // Odstraníme výkon z databáze
                _context.SaveChanges(); // Uložíme změny
                deleted = true;
            }
            return deleted; // Pokud výkon neexistuje, vrátíme false
        }

        // Metoda pro získání výkonu podle ID
        public Performance GetById(int id)
        {
            return _context.Performances.FirstOrDefault(p => p.Id == id); // Najdeme výkon podle ID
        }

        // Metoda pro aktualizaci výkonu
        public bool Update(Performance performance)
        {
            var existingPerfomance = _context.Performances.FirstOrDefault(p => p.Id == performance.Id);
            if (existingPerfomance != null)
            {
                existingPerfomance.MatchId = performance.MatchId;
                existingPerfomance.PlayerId = performance.PlayerId;
                existingPerfomance.Stats = performance.Stats;
                _context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
