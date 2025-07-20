using Microsoft.EntityFrameworkCore;
using fotbalTeam.Application.Abstraction;
using fotbalTeam.Domain.Entities;
using fotbalTeam.Infrastructure.Database;
using System;
using System.Collections.Generic;
using System.Linq;

namespace fotbalTeam.Application.Implementation
{
    public class MatchAppService : IMatchAppService
    {
        private readonly FotbalTeamDbContext _context;

        public MatchAppService(FotbalTeamDbContext context)
        {
            _context = context;
        }

        // Get all matches
        public IList<Match> Select()
        {
            return _context.Matches.ToList();
        }

        // Create a new match
        public void Create(Match match)
        {
            _context.Matches.Add(match);
            _context.SaveChanges();
        }

        // Delete a match by ID
        public bool Delete(int id)
        {
            bool deleted = false;
            var match = _context.Matches.FirstOrDefault(m => m.Id == id);
            if (match != null)
            {
                _context.Matches.Remove(match);
                _context.SaveChanges();
                deleted = true;
            }
            return deleted;
        }

        // Get a match by ID
        public Match GetById(int id)
        {
            return _context.Matches.FirstOrDefault(m => m.Id == id);
        }

        // Get matches by opponent
        public IList<Match> GetMatchesByOpponent(string opponent)
        {
            return _context.Matches.Where(m => m.Opponent == opponent).ToList();
        }

        // Update a match
        public bool Update(Match match)
        {
            var existingMatch = _context.Matches.FirstOrDefault(m => m.Id == match.Id);
            if (existingMatch != null)
            {
                existingMatch.Opponent = match.Opponent;
                existingMatch.Date = match.Date;
                existingMatch.Location = match.Location;
                _context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
