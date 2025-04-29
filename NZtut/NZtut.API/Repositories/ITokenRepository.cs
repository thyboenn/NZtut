using Microsoft.AspNetCore.Identity;

namespace NZtut.API.Repositories
{
    public interface ITokenRepository
    {
        string CreateJWTToken(IdentityUser user, List<string> roles);
    }
}
