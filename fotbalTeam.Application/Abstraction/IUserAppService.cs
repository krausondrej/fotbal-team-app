using fotbalTeam.Domain.Entities;
using fotbalTeam.Infrastructure.Identity;
using System.Collections.Generic;

namespace fotbalTeam.Application.Abstraction
{
    public interface IUserAppService
    {
        IList<User> GetAllUsers();
        User GetUserById(int id);
        bool UpdateUser(User user);
        bool DeleteUser(int id);
    }
}
