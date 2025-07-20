using fotbalTeam.Application.Abstraction;
using fotbalTeam.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using fotbalTeam.Infrastructure.Database;
using System.Collections.Generic;
using System.Linq;

namespace fotbalTeam.Application.Implementation
{
    public class PlayerAppService : IPlayerAppService
    {
        private readonly FotbalTeamDbContext _context;

        public PlayerAppService(FotbalTeamDbContext context)
        {
            _context = context;
        }

        public IList<Player> Select()
        {
            // Vrátí všechny hráče
            return _context.Players.ToList();
        }

        public void Create(Player player)
        {
            // Přidá nového hráče do databáze
            _context.Players.Add(player);
            _context.SaveChanges();
        }

        public bool Delete(int id)
        {
            // Najde hráče podle ID a smaže ho
            var player = _context.Players.FirstOrDefault(p => p.Id == id);
            if (player != null)
            {
                _context.Players.Remove(player);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public bool Update(Player player)
        {
            // Najde hráče podle ID a aktualizuje jeho vlastnosti
            var existingPlayer = _context.Players.FirstOrDefault(p => p.Id == player.Id);
            if (existingPlayer != null)
            {
                existingPlayer.FirstName = player.FirstName;
                existingPlayer.LastName = player.LastName;
                existingPlayer.DateOfBirth = player.DateOfBirth;
                existingPlayer.Position = player.Position;
                existingPlayer.JerseyNumber = player.JerseyNumber;

                _context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}