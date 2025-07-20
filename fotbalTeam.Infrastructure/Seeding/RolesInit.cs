using fotbalTeam.Infrastructure.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fotbalTeam.Infrastructure.Seeding
{
    internal class RolesInit
    {
        public List<Role> GetRolesALS()
        {
            List<Role> roles = new List<Role>();
            Role roleAdmin = new Role()
            {
                Id = 1,
                Name = "Admin",
                NormalizedName = "ADMIN",
                ConcurrencyStamp = "9cf14c2c-19e7-40d6-b744-8917505c3106"
            };
            Role roleManager = new Role()
            {
                Id = 2,
                Name = "Manager",
                NormalizedName = "MANAGER",
                ConcurrencyStamp = "be0efcde-9d0a-461d-8eb6-444b043d6660"
            };
            Role rolePlayer = new Role()
            {
                Id = 3,
                Name = "Player",
                NormalizedName = "PLAYER",
                ConcurrencyStamp = "29dafca7-cd20-4cd9-a3dd-4779d7bac3ee"
            };
            roles.Add(roleAdmin);
            roles.Add(roleManager);
            roles.Add(rolePlayer);
            return roles;
        }
    }
}
