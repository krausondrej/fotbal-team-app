using fotbalTeam.Domain.Entities;
using System.Collections.Generic;

namespace fotbalTeam.Infrastructure.Seeding
{
    internal class MatchInit
    {
        public IList<Match> GetMatches()
        {
            IList<Match> matches = new List<Match>();

            matches.Add(new Match
            {
                Id = 1,
                Opponent = "Team A",
                Date = new DateTime(2025, 2, 5),
                Location = "Home"
            });

            matches.Add(new Match
            {
                Id = 2,
                Opponent = "Team B",
                Date = new DateTime(2025, 2, 12),
                Location = "Away"
            });

            matches.Add(new Match
            {
                Id = 3,
                Opponent = "Team C",
                Date = new DateTime(2025, 2, 19),
                Location = "Home"
            });

            return matches;
        }
    }
}