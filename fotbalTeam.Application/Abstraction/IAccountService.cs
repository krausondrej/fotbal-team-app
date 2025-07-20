using fotbalTeam.Application.ViewModels;
using fotbalTeam.Infrastructure.Identity.Enums;

namespace fotbalTeam.Application.Abstraction
{
    public interface IAccountService
    {
        Task<bool> Login(LoginViewModel vm);
        Task Logout();
        Task<string[]> Register(RegisterViewModel vm, params Roles[] roles);
    }
}
