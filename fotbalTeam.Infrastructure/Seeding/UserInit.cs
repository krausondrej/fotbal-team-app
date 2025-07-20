using Microsoft.AspNetCore.Identity;
using fotbalTeam.Infrastructure.Identity;
using System;

namespace fotbalTeam.Infrastructure.Seeding
{
    internal class UserInit
    {
        private readonly PasswordHasher<User> _passwordHasher;

        public UserInit()
        {
            _passwordHasher = new PasswordHasher<User>();  // Inicializujte PasswordHasher
        }

        public User GetAdmin()
        {
            User admin = new User()
            {
                Id = 1,
                FirstName = "Adminek",
                LastName = "Adminovy",
                UserName = "admin",
                NormalizedUserName = "ADMIN",
                Email = "admin@admin.cz",
                NormalizedEmail = "ADMIN@ADMIN.CZ",
                EmailConfirmed = true,
                PasswordHash = _passwordHasher.HashPassword(null, "admin"),  // Zašifrovanie hesla "admin"
                SecurityStamp = Guid.NewGuid().ToString(),  // Generujte nový security stamp
                ConcurrencyStamp = Guid.NewGuid().ToString(),
                PhoneNumber = null,
                PhoneNumberConfirmed = false,
                TwoFactorEnabled = false,
                LockoutEnd = null,
                LockoutEnabled = true,
                AccessFailedCount = 0
            };
            return admin;
        }

        public User GetLecturer()
        {
            User manager = new User()
            {
                Id = 2,
                FirstName = "manager",
                LastName = "Managerovy",
                UserName = "manager",
                NormalizedUserName = "MANAGER",
                Email = "manager@manager.cz",
                NormalizedEmail = "MANAGER@MANAGER.CZ",
                EmailConfirmed = true,
                PasswordHash = _passwordHasher.HashPassword(null, "manager"),  // Zašifrovanie hesla "lecturer"
                SecurityStamp = Guid.NewGuid().ToString(),  // Generujte nový security stamp
                ConcurrencyStamp = Guid.NewGuid().ToString(),
                PhoneNumber = null,
                PhoneNumberConfirmed = false,
                TwoFactorEnabled = false,
                LockoutEnd = null,
                LockoutEnabled = true,
                AccessFailedCount = 0
            };
            return manager;
        }
    }
}
