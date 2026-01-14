using System.Threading.Tasks;
using ComputerStoreManagement.Data;
using ComputerStoreManagement.Helpers;
using ComputerStoreManagement.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ComputerStoreManagement.Services
{
    public class AuthService : IAuthService
    {
        private readonly IServiceProvider _serviceProvider;
        private User? _currentUser;

        public AuthService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public User? CurrentUser => _currentUser;

        public async Task<User?> LoginAsync(string username, string password)
        {
            using var scope = _serviceProvider.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
            
            var user = await context.Users
                .Include(u => u.Employee)
                .FirstOrDefaultAsync(u => u.Username == username && u.IsActive);

            if (user == null)
                return null;

            if (!PasswordHelper.VerifyPassword(password, user.PasswordHash))
                return null;

            _currentUser = user;
            return user;
        }

        public async Task<bool> RegisterAsync(User user, string password)
        {
            using var scope = _serviceProvider.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
            
            var existingUser = await context.Users
                .FirstOrDefaultAsync(u => u.Username == user.Username);

            if (existingUser != null)
                return false;

            user.PasswordHash = PasswordHelper.HashPassword(password);
            context.Users.Add(user);
            await context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> ChangePasswordAsync(int userId, string oldPassword, string newPassword)
        {
            using var scope = _serviceProvider.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
            
            var user = await context.Users.FindAsync(userId);
            if (user == null)
                return false;

            if (!PasswordHelper.VerifyPassword(oldPassword, user.PasswordHash))
                return false;

            user.PasswordHash = PasswordHelper.HashPassword(newPassword);
            await context.SaveChangesAsync();

            return true;
        }

        public void Logout()
        {
            _currentUser = null;
        }
    }
}
