using Microsoft.AspNetCore.Identity;

namespace fotbalTeam.Infrastructure.Identity
{
    public class Role : IdentityRole<int>
    {
        public Role(string role) : base(role)
        {
        }
        public Role() : base()
        {
        }
    }
}
