using System.Windows.Controls;
using ComputerStoreManagement.Data;
using ComputerStoreManagement.Services;
using ComputerStoreManagement.ViewModels;

namespace ComputerStoreManagement.Views
{
    public partial class DashboardView : Page
    {
        public DashboardView()
        {
            InitializeComponent();
            
            var context = App.ServiceProvider.GetService(typeof(AppDbContext)) as AppDbContext;
            var authService = App.ServiceProvider.GetService(typeof(IAuthService)) as IAuthService;
            
            if (context != null && authService != null)
            {
                DataContext = new DashboardViewModel(context, authService);
            }
        }
    }
}
