using fotbalTeam.Domain.Entities;
using System.Collections.Generic;

namespace fotbalTeam.Application.Abstraction
{
    public interface IPlayerAppService
    {
        IList<Player> Select(); // Vrátí seznam všech hráčů
        void Create(Player player); // Vytvoří nového hráče
        bool Delete(int id); // Odstraní hráče dle ID
        bool Update(Player player); // Aktualizuje existujícího hráče
    }
}

