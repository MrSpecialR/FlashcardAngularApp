namespace LanguageLearningPlatform.Services
{
    using System.Security.Claims;
    using System.Threading.Tasks;

    public interface IUsersService
    {
        string Login(string username, string password);
        Task<string> Register(string username, string email, string passsword);

        bool IsAdmin(string token);

        string GetUserId(ClaimsPrincipal token);
        bool IsAdminByUserId(string userId);
    }
}