using System.Windows;
using System.Windows.Controls;
using ComputerStoreManagement.Services;
using ComputerStoreManagement.ViewModels;

namespace ComputerStoreManagement.Views
{
    public partial class LoginView : Window
    {
        public LoginView(IAuthService authService)
        {
            InitializeComponent();
            DataContext = new LoginViewModel(authService);
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (DataContext is LoginViewModel viewModel && sender is PasswordBox passwordBox)
            {
                viewModel.Password = passwordBox.Password;
            }
        }
    }
}
