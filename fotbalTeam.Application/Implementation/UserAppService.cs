using fotbalTeam.Application.Abstraction;
using fotbalTeam.Domain.Entities;
using fotbalTeam.Infrastructure.Database;
using fotbalTeam.Infrastructure.Identity;
using System.Linq;

namespace fotbalTeam.Application.Implementation
{
    public class UserAppService : IUserAppService
    {
        private readonly FotbalTeamDbContext _dbContext;

        public UserAppService(FotbalTeamDbContext context)
        {
            _dbContext = context;
        }

        public IList<User> GetAllUsers()
        {
            return _dbContext.Users.ToList();
        }

        public User GetUserById(int id)
        {
            return _dbContext.Users.FirstOrDefault(u => u.Id == id);
        }

        public bool UpdateUser(User user)
        {
            var existingUser = _dbContext.Users.FirstOrDefault(u => u.Id == user.Id);
            if (existingUser == null)
            {
                return false; // Užívateľ neexistuje
            }

            // Priradenie zmien
            existingUser.UserName = user.UserName;
            existingUser.Email = user.Email;
            existingUser.FirstName = user.FirstName;
            existingUser.LastName = user.LastName;
            existingUser.PhoneNumber = user.PhoneNumber;

            // Zabezpečiť, že EF detekuje zmeny
            _dbContext.Users.Update(existingUser); // Aktualizujeme používateľa

            _dbContext.SaveChanges(); // Uložíme zmeny
            return true;
        }

        public bool DeleteUser(int id)
        {
            var user = _dbContext.Users.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                return false;
            }

            _dbContext.Users.Remove(user);
            _dbContext.SaveChanges();

            return true;
        }
    }
}
