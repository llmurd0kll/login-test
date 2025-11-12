using System.Threading.Tasks;
using LoginTest.Models;

namespace LoginTest.Services
    {
    public interface ISoapAuthService
        {
        Task<AuthResult> LoginAsync(string login, string password);
        Task<AuthResult> RegisterAsync(string email, string password);
        }
    }
