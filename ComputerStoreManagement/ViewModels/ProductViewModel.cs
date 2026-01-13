using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using ComputerStoreManagement.Data;
using ComputerStoreManagement.Helpers;
using ComputerStoreManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace ComputerStoreManagement.ViewModels
{
    public class ProductViewModel : BaseViewModel
    {
        private readonly AppDbContext _context;
        private ObservableCollection<Product> _products;
        private Product? _selectedProduct;
        private string _searchText = string.Empty;

        public ProductViewModel(AppDbContext context)
        {
            _context = context;
            _products = new ObservableCollection<Product>();
            LoadProductsCommand = new RelayCommand(_ => LoadProducts());
            LoadProducts();
        }

        public ObservableCollection<Product> Products
        {
            get => _products;
            set => SetProperty(ref _products, value);
        }

        public Product? SelectedProduct
        {
            get => _selectedProduct;
            set => SetProperty(ref _selectedProduct, value);
        }

        public string SearchText
        {
            get => _searchText;
            set
            {
                if (SetProperty(ref _searchText, value))
                {
                    LoadProducts();
                }
            }
        }

        public ICommand LoadProductsCommand { get; }

        private async void LoadProducts()
        {
            try
            {
                var query = _context.Products
                    .Include(p => p.Category)
                    .Include(p => p.Brand)
                    .AsQueryable();

                if (!string.IsNullOrWhiteSpace(SearchText))
                {
                    query = query.Where(p => 
                        p.Name.Contains(SearchText) || 
                        p.ProductCode.Contains(SearchText));
                }

                var products = await query.ToListAsync();
                Products.Clear();
                foreach (var product in products)
                {
                    Products.Add(product);
                }
            }
            catch (System.Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error loading products: {ex.Message}");
            }
        }
    }
}
