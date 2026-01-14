using System.Threading.Tasks;
using ComputerStoreManagement.Models;

namespace ComputerStoreManagement.Services
{
    public interface IAuthService
    {
        Task<User?> LoginAsync(string username, string password);
        Task<bool> RegisterAsync(User user, string password);
        Task<bool> ChangePasswordAsync(int userId, string oldPassword, string newPassword);
        User? CurrentUser { get; }
        void Logout();
    }
}
