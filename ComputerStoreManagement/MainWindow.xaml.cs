using System.Windows;
using System.Windows.Controls;
using ComputerStoreManagement.Services;
using ComputerStoreManagement.Views;

namespace ComputerStoreManagement;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private readonly IAuthService _authService;

    public MainWindow()
    {
        InitializeComponent();
        
        // Get AuthService from DI container
        _authService = App.ServiceProvider.GetService(typeof(IAuthService)) as IAuthService 
            ?? throw new InvalidOperationException("AuthService not found");
        
        // Display current user name
        if (_authService.CurrentUser?.Employee != null)
        {
            UserNameText.Text = _authService.CurrentUser.Employee.FullName;
        }
        else
        {
            UserNameText.Text = _authService.CurrentUser?.Username ?? "User";
        }

        // Navigate to Dashboard by default
        NavigateTo("Dashboard");
    }

    private void NavigationButton_Click(object sender, RoutedEventArgs e)
    {
        if (sender is Button button && button.Tag is string tag)
        {
            NavigateTo(tag);
        }
    }

    private void NavigateTo(string viewName)
    {
        try
        {
            switch (viewName)
            {
                case "Dashboard":
                    MainFrame.Navigate(new DashboardView());
                    break;
                case "Products":
                    MainFrame.Navigate(new ProductsView());
                    break;
                case "Customers":
                    MainFrame.Navigate(new CustomersView());
                    break;
                case "Orders":
                    MainFrame.Navigate(new OrdersView());
                    break;
                case "Employees":
                    MainFrame.Navigate(new EmployeesView());
                    break;
                case "Suppliers":
                    MainFrame.Navigate(new SuppliersView());
                    break;
                case "Imports":
                    MainFrame.Navigate(new ImportsView());
                    break;
                case "Reports":
                    MainFrame.Navigate(new ReportsView());
                    break;
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Lỗi khi điều hướng: {ex.Message}", "Lỗi", 
                MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }

    private void LogoutButton_Click(object sender, RoutedEventArgs e)
    {
        var result = MessageBox.Show("Bạn có chắc chắn muốn đăng xuất?", "Xác nhận",
            MessageBoxButton.YesNo, MessageBoxImage.Question);
        
        if (result == MessageBoxResult.Yes)
        {
            _authService.Logout();
            
            // Show login window
            var loginWindow = (LoginView)App.ServiceProvider.GetService(typeof(LoginView))!;
            loginWindow.Show();
            
            // Close main window
            this.Close();
        }
    }
}