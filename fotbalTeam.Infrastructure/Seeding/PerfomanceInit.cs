using fotbalTeam.Domain.Entities;
using System.Collections.Generic;

namespace fotbalTeam.Infrastructure.Seeding
{
    internal class PerformanceInit
    {
        public IList<Performance> GetPerformances()
        {
            IList<Performance> performances = new List<Performance>();

            performances.Add(new Performance
            {
                Id = 1,
                PlayerId = 1,
                MatchId = 1,
                Stats = "2 goals, 1 assist"
            });

            performances.Add(new Performance
            {
                Id = 2,
                PlayerId = 2,
                MatchId = 2,
                Stats = "1 goal, 3 assists"
            });

            performances.Add(new Performance
            {
                Id = 3,
                PlayerId = 3,
                MatchId = 3,
                Stats = "Clean sheet, 1 tackle"
            });

            return performances;
        }
    }
}