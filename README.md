# Computer Store Management

Ứng dụng desktop **Quản lý Cửa hàng Máy tính** xây dựng bằng **C# WPF** và **MySQL**.

## 🛠️ Công nghệ sử dụng

| Thành phần | Công nghệ |
|------------|-----------|
| **UI Framework** | C# WPF (.NET 8) |
| **Architecture** | MVVM Pattern |
| **Database** | MySQL |
| **ORM** | Entity Framework Core |
| **UI Components** | MaterialDesignInXAML |
| **Charts** | LiveCharts2 |
| **Reports** | ClosedXML (Excel), iText7 (PDF) |
| **Password Hashing** | BCrypt.Net |

## 📋 Yêu cầu hệ thống

- **.NET 8.0 SDK** hoặc mới hơn
- **MySQL Server** 8.0 hoặc mới hơn
- **Windows 10/11** (hoặc hệ điều hành hỗ trợ WPF)
- **Visual Studio 2022** hoặc **JetBrains Rider** (khuyến nghị)

## 🚀 Cài đặt và Chạy ứng dụng

### Bước 1: Clone Repository

```bash
git clone https://github.com/huobin1202/computer-store-management.git
cd computer-store-management
```

### Bước 2: Cài đặt MySQL Server

1. Tải và cài đặt MySQL Server từ: https://dev.mysql.com/downloads/mysql/
2. Khởi động MySQL Server
3. Tạo database bằng cách chạy script SQL:

```bash
mysql -u root -p < Database/schema.sql
```

### Bước 3: Nhập dữ liệu mẫu (tùy chọn)

```bash
mysql -u root -p < Database/sample_data.sql
```

### Bước 4: Cấu hình Connection String

Mở file `ComputerStoreManagement/appsettings.json` và cập nhật connection string:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=computer_store_db;User=root;Password=YOUR_MYSQL_PASSWORD_HERE;CharSet=utf8mb4;"
  }
}
```

**Lưu ý**: Thay `YOUR_MYSQL_PASSWORD_HERE` bằng mật khẩu MySQL của bạn. Không để password trống vì lý do bảo mật.

### Bước 5: Restore NuGet Packages

```bash
dotnet restore
```

### Bước 6: Build Solution

```bash
dotnet build
```

### Bước 7: Chạy ứng dụng

```bash
cd ComputerStoreManagement
dotnet run
```

## 🔑 Tài khoản đăng nhập mặc định

Sau khi nhập dữ liệu mẫu, bạn có thể đăng nhập với các tài khoản sau:

| Username | Password | Role | Mô tả |
|----------|----------|------|-------|
| admin | admin123 | Admin | Toàn quyền |
| manager | admin123 | Manager | Quản lý |
| sales | admin123 | Sales | Nhân viên bán hàng |
| accountant | admin123 | Accountant | Kế toán |

**Lưu ý**: Đổi mật khẩu ngay sau lần đăng nhập đầu tiên để đảm bảo bảo mật!

## 📁 Cấu trúc Project

```
ComputerStoreManagement/
├── ComputerStoreManagement.sln          # Solution file
├── ComputerStoreManagement/             # Main WPF Application
│   ├── App.xaml                         # Application entry point
│   ├── MainWindow.xaml                  # Main window with navigation
│   ├── appsettings.json                 # Configuration file
│   ├── Views/                           # XAML Views
│   │   ├── LoginView.xaml
│   │   ├── DashboardView.xaml
│   │   ├── ProductsView.xaml
│   │   ├── CustomersView.xaml
│   │   ├── OrdersView.xaml
│   │   ├── EmployeesView.xaml
│   │   ├── SuppliersView.xaml
│   │   ├── ImportsView.xaml
│   │   └── ReportsView.xaml
│   ├── ViewModels/                      # MVVM ViewModels
│   │   ├── BaseViewModel.cs
│   │   ├── LoginViewModel.cs
│   │   ├── DashboardViewModel.cs
│   │   └── ProductViewModel.cs
│   ├── Models/                          # Data Models
│   │   ├── User.cs
│   │   ├── Employee.cs
│   │   ├── Customer.cs
│   │   ├── Product.cs
│   │   ├── Order.cs
│   │   ├── Import.cs
│   │   └── ...
│   ├── Services/                        # Business Logic
│   │   ├── IAuthService.cs
│   │   ├── AuthService.cs
│   │   └── ...
│   ├── Data/                            # Data Access Layer
│   │   ├── AppDbContext.cs
│   │   └── Repositories/
│   ├── Helpers/                         # Utilities
│   │   ├── RelayCommand.cs
│   │   ├── PasswordHelper.cs
│   │   ├── ExportHelper.cs
│   │   └── ValidationHelper.cs
│   ├── Resources/                       # Styles & Resources
│   │   ├── Styles.xaml
│   │   └── Colors.xaml
│   └── Converters/                      # Value Converters
│       ├── BoolToVisibilityConverter.cs
│       ├── CurrencyConverter.cs
│       └── InverseBooleanConverter.cs
├── Database/
│   ├── schema.sql                       # MySQL Database Schema
│   └── sample_data.sql                  # Sample data
└── README.md                            # This file
```

## 📦 Các chức năng chính

### ✅ Đã triển khai

1. **Đăng nhập & Phân quyền**
   - Form đăng nhập với username/password
   - Mã hóa password bằng BCrypt
   - Phân quyền theo 4 vai trò: Admin, Manager, Sales, Accountant

2. **Dashboard**
   - Hiển thị doanh thu hôm nay
   - Số đơn hàng hôm nay
   - Số sản phẩm sắp hết hàng

3. **Quản lý Sản phẩm**
   - Xem danh sách sản phẩm
   - Tìm kiếm sản phẩm theo tên, mã
   - Hiển thị thông tin danh mục, thương hiệu

4. **Giao diện Material Design**
   - Sử dụng MaterialDesignInXAML
   - Navigation menu bên trái
   - Header với thông tin user

### 🚧 Đang phát triển

- CRUD đầy đủ cho tất cả các module
- Quản lý đơn hàng với workflow hoàn chỉnh
- Quản lý nhập hàng
- Báo cáo & Thống kê với biểu đồ
- Export Excel/PDF
- Validation đầy đủ

## 🎯 Roadmap

- [ ] Hoàn thiện CRUD operations cho tất cả entities
- [ ] Thêm validation và error handling
- [ ] Implement báo cáo và biểu đồ
- [ ] Thêm chức năng export Excel/PDF
- [ ] Thêm chức năng in hóa đơn
- [ ] Thêm theme Dark/Light mode
- [ ] Thêm unit tests
- [ ] Thêm logging

## 🐛 Báo lỗi

Nếu bạn gặp bất kỳ lỗi nào, vui lòng tạo issue tại: https://github.com/huobin1202/computer-store-management/issues

## 📝 License

This project is licensed under the MIT License.

## 👥 Tác giả

- **Huobin1202** - [GitHub](https://github.com/huobin1202)

## 🙏 Acknowledgments

- MaterialDesignInXAML cho UI components
- Entity Framework Core cho ORM
- BCrypt.Net cho password hashing
- ClosedXML và iText7 cho export functionality
