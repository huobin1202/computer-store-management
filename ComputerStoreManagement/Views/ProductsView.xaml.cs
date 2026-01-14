using System.Windows.Controls;
using ComputerStoreManagement.Data;
using ComputerStoreManagement.ViewModels;

namespace ComputerStoreManagement.Views
{
    public partial class ProductsView : Page
    {
        public ProductsView()
        {
            InitializeComponent();
            
            var context = App.ServiceProvider.GetService(typeof(AppDbContext)) as AppDbContext;
            if (context != null)
            {
                DataContext = new ProductViewModel(context);
            }
        }
    }
}
