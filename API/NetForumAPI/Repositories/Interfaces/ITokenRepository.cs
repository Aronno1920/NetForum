using Microsoft.AspNetCore.Identity;

namespace NetForumAPI.Repositories.Interfaces
{
    public interface ITokenRepository
    {
        string CreateJwtToken(IdentityUser user, List<string> roles);
    }
}
