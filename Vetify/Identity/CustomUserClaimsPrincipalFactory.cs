using EL.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System.Security.Claims;

namespace Vetify.Identity
{
    public class CustomUserClaimsPrincipalFactory
    : UserClaimsPrincipalFactory<Kullanici, IdentityRole<int>>
    {
        public CustomUserClaimsPrincipalFactory(
            UserManager<Kullanici> userManager,
            RoleManager<IdentityRole<int>> roleManager,
            IOptions<IdentityOptions> options)
            : base(userManager, roleManager, options)
        {
        }

        protected override async Task<ClaimsIdentity> GenerateClaimsAsync(Kullanici user)
        {
            var identity = await base.GenerateClaimsAsync(user);

            identity.AddClaim(new Claim("AdSoyad", user.AdSoyad ?? ""));
            identity.AddClaim(new Claim("Email", user.Email ?? ""));

            return identity;
        }
    }

}