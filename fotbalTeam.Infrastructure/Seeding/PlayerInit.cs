using fotbalTeam.Domain.Entities;
using System.Collections.Generic;

namespace fotbalTeam.Infrastructure.Seeding
{
    internal class PlayerInit
    {
        public IList<Player> GetPlayers()
        {
            IList<Player> players = new List<Player>();

            players.Add(new Player
            {
                Id = 1,
                FirstName = "John",
                LastName = "Doe",
                DateOfBirth = new DateTime(1995, 5, 20),
                Position = "Forward",
                JerseyNumber = 9
            });

            players.Add(new Player
            {
                Id = 2,
                FirstName = "Jane",
                LastName = "Smith",
                DateOfBirth = new DateTime(1993, 8, 15),
                Position = "Midfielder",
                JerseyNumber = 10
            });

            players.Add(new Player
            {
                Id = 3,
                FirstName = "Tom",
                LastName = "Brown",
                DateOfBirth = new DateTime(1997, 3, 22),
                Position = "Defender",
                JerseyNumber = 5
            });

            return players;
        }
    }
}