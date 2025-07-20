using fotbalTeam.Domain.Entities;
using System.Collections.Generic;

namespace fotbalTeam.Application.Abstraction
{
    public interface IMatchAppService
    {
        IList<Match> Select(); // Get all matches
        void Create(Match match); // Create a new match
        bool Delete(int id); // Delete a match by ID
        Match GetById(int id); // Get match by ID
        bool Update(Match match);
    }
}