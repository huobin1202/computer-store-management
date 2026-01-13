using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ComputerStoreManagement.Data;
using ComputerStoreManagement.Services;
using Microsoft.EntityFrameworkCore;

namespace ComputerStoreManagement.ViewModels
{
    public class DashboardViewModel : BaseViewModel
    {
        private readonly AppDbContext _context;
        private readonly IAuthService _authService;
        private decimal _todayRevenue;
        private int _todayOrders;
        private int _lowStockProducts;
        private string _currentUserName = string.Empty;

        public DashboardViewModel(AppDbContext context, IAuthService authService)
        {
            _context = context;
            _authService = authService;
            LoadDashboardData();
        }

        public decimal TodayRevenue
        {
            get => _todayRevenue;
            set => SetProperty(ref _todayRevenue, value);
        }

        public int TodayOrders
        {
            get => _todayOrders;
            set => SetProperty(ref _todayOrders, value);
        }

        public int LowStockProducts
        {
            get => _lowStockProducts;
            set => SetProperty(ref _lowStockProducts, value);
        }

        public string CurrentUserName
        {
            get => _currentUserName;
            set => SetProperty(ref _currentUserName, value);
        }

        private async void LoadDashboardData()
        {
            try
            {
                var today = DateTime.Today;
                
                // Get today's revenue
                var todayOrdersQuery = await _context.Orders
                    .Where(o => o.OrderDate.Date == today && o.Status == "Completed")
                    .ToListAsync();
                
                TodayRevenue = todayOrdersQuery.Sum(o => o.TotalAmount);
                TodayOrders = todayOrdersQuery.Count;

                // Get low stock products
                LowStockProducts = await _context.Products
                    .CountAsync(p => p.Quantity <= p.MinQuantity && p.Status == "Available");

                // Get current user name
                if (_authService.CurrentUser?.Employee != null)
                {
                    CurrentUserName = _authService.CurrentUser.Employee.FullName;
                }
                else
                {
                    CurrentUserName = _authService.CurrentUser?.Username ?? "User";
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error loading dashboard: {ex.Message}");
            }
        }
    }
}
