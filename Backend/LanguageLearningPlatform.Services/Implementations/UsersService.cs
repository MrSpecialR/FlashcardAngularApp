namespace LanguageLearningPlatform.Services
{
    using Infrastructure;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.IdentityModel.Tokens;
    using Models;
    using System;
    using System.IdentityModel.Tokens.Jwt;
    using System.Linq;
    using System.Security.Claims;
    using System.Threading.Tasks;

    public class UsersService : IUsersService
    {
        private readonly UserManager<User> userManager;

        public UsersService(UserManager<User> userManager)
        {
            this.userManager = userManager;
        }


        public string Login(string username, string password)
        {
            var user = this.userManager.FindByNameAsync(username).GetAwaiter().GetResult();
            bool isPasswordValid = this.userManager.CheckPasswordAsync(user, password).GetAwaiter().GetResult();
            if (!isPasswordValid)
            {
                return null;
            }

            return this.GenerateToken(user);
        }

        public string GetUserId(ClaimsPrincipal token)
        {
            return this.userManager.GetUserId(token);
        }

        public bool IsAdminByUserId(string userId)
        {
            var user = this.userManager.FindByIdAsync(userId).Result;

            if (user == null)
            {
                return false;
            }

            return this.userManager.IsInRoleAsync(user, "Administrator").Result;
        }

        public async Task<string> Register(string username, string email, string password)
        {
            var user = new User { UserName = username, Email = email };
            try
            {
                var result = await this.userManager.CreateAsync(user, password);
                if (result.Succeeded)
                {
                    return this.GenerateToken(user);
                }

                return null;
            }
            catch (Exception _)
            {
                // Means that unique constraint is violated (too much code to make sure it's given exception as SqlException doesn't work directly)
                return null;
            }
            
        }

        public bool IsAdmin(string token)
        {
            try
            {
                return new JwtSecurityTokenHandler().ReadJwtToken(token).Claims
                    .SingleOrDefault(c => c.Type == ClaimTypes.Role).Value.Contains("Administrator");
            }
            catch (Exception)
            {
                return false;
            }

        }

        private string GenerateToken(User user)
        {
            if (user is null)
            {
                return null;
            }

            var roles = this.userManager.GetRolesAsync(user).Result;
            var key = new SymmetricSecurityKey(Configuration.Key);
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Role, string.Join(", ", roles)),

            };

            var token = new JwtSecurityToken(
                issuer: "localhost",
                audience: "localhost",
                expires: DateTime.Now + TimeSpan.FromDays(7),
                claims: claims,
                signingCredentials: new SigningCredentials(key, "HS256")
                );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}