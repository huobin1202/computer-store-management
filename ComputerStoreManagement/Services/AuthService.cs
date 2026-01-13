using System.Threading.Tasks;
using ComputerStoreManagement.Data;
using ComputerStoreManagement.Helpers;
using ComputerStoreManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace ComputerStoreManagement.Services
{
    public class AuthService : IAuthService
    {
        private readonly AppDbContext _context;
        private User? _currentUser;

        public AuthService(AppDbContext context)
        {
            _context = context;
        }

        public User? CurrentUser => _currentUser;

        public async Task<User?> LoginAsync(string username, string password)
        {
            var user = await _context.Users
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
            var existingUser = await _context.Users
                .FirstOrDefaultAsync(u => u.Username == user.Username);

            if (existingUser != null)
                return false;

            user.PasswordHash = PasswordHelper.HashPassword(password);
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> ChangePasswordAsync(int userId, string oldPassword, string newPassword)
        {
            var user = await _context.Users.FindAsync(userId);
            if (user == null)
                return false;

            if (!PasswordHelper.VerifyPassword(oldPassword, user.PasswordHash))
                return false;

            user.PasswordHash = PasswordHelper.HashPassword(newPassword);
            await _context.SaveChangesAsync();

            return true;
        }

        public void Logout()
        {
            _currentUser = null;
        }
    }
}
