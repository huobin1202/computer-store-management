-- Sample Data for Computer Store Management
USE computer_store_db;

-- Insert Employees
INSERT INTO employees (employee_code, full_name, gender, birth_date, phone, email, address, position, salary, hire_date, status) VALUES
('EMP001', 'Nguyễn Văn Admin', 'Nam', '1990-01-15', '0901234567', 'admin@computerstore.com', 'Hà Nội', 'Giám đốc', 20000000, '2020-01-01', 'Active'),
('EMP002', 'Trần Thị Lan', 'Nữ', '1995-05-20', '0902234567', 'lan.tran@computerstore.com', 'Hà Nội', 'Quản lý', 15000000, '2020-06-01', 'Active'),
('EMP003', 'Lê Văn Hùng', 'Nam', '1998-08-10', '0903234567', 'hung.le@computerstore.com', 'Hà Nội', 'Nhân viên bán hàng', 10000000, '2021-01-15', 'Active'),
('EMP004', 'Phạm Thị Mai', 'Nữ', '1997-03-25', '0904234567', 'mai.pham@computerstore.com', 'Hà Nội', 'Kế toán', 12000000, '2021-03-01', 'Active'),
('EMP005', 'Hoàng Văn Nam', 'Nam', '1996-12-05', '0905234567', 'nam.hoang@computerstore.com', 'Hà Nội', 'Nhân viên bán hàng', 10000000, '2021-06-01', 'Active');

-- Insert Users (Password: admin123 hashed with BCrypt)
-- BCrypt hash for 'admin123': $2a$11$XZ0lq8qF5JhKxXKKxXKKxuN7VU4YX5W5W5W5W5W5W5W5W5W5W5W5.
-- For demo purposes, using a simplified hash. In real app, use BCrypt.Net
INSERT INTO users (username, password_hash, role, employee_id, is_active) VALUES
('admin', '$2a$11$5Z0lq8qF5JhKxXKKxXKKxuN7VU4YX5W5W5W5W5W5W5W5W5W5W5W5.', 'Admin', 1, TRUE),
('manager', '$2a$11$5Z0lq8qF5JhKxXKKxXKKxuN7VU4YX5W5W5W5W5W5W5W5W5W5W5W5.', 'Manager', 2, TRUE),
('sales', '$2a$11$5Z0lq8qF5JhKxXKKxXKKxuN7VU4YX5W5W5W5W5W5W5W5W5W5W5W5.', 'Sales', 3, TRUE),
('accountant', '$2a$11$5Z0lq8qF5JhKxXKKxXKKxuN7VU4YX5W5W5W5W5W5W5W5W5W5W5W5.', 'Accountant', 4, TRUE);

-- Insert Categories
INSERT INTO categories (name, description) VALUES
('Laptop', 'Máy tính xách tay các loại'),
('Desktop', 'Máy tính để bàn'),
('Monitor', 'Màn hình máy tính'),
('Keyboard', 'Bàn phím cơ và thường'),
('Mouse', 'Chuột máy tính'),
('Headphone', 'Tai nghe gaming và văn phòng'),
('Accessories', 'Phụ kiện máy tính');

-- Insert Brands
INSERT INTO brands (name, logo_url) VALUES
('Dell', 'https://logo.com/dell.png'),
('HP', 'https://logo.com/hp.png'),
('Asus', 'https://logo.com/asus.png'),
('Lenovo', 'https://logo.com/lenovo.png'),
('Acer', 'https://logo.com/acer.png'),
('MSI', 'https://logo.com/msi.png'),
('LG', 'https://logo.com/lg.png'),
('Logitech', 'https://logo.com/logitech.png'),
('Razer', 'https://logo.com/razer.png'),
('Corsair', 'https://logo.com/corsair.png');

-- Insert Products
INSERT INTO products (product_code, name, category_id, brand_id, cost_price, sell_price, quantity, min_quantity, warranty_months, specifications, status) VALUES
('LAP001', 'Dell Inspiron 15 3000', 1, 1, 12000000, 15000000, 25, 5, 12, 'Intel Core i5, 8GB RAM, 256GB SSD, 15.6 inch', 'Available'),
('LAP002', 'HP Pavilion 14', 1, 2, 13000000, 16000000, 30, 5, 12, 'Intel Core i5, 8GB RAM, 512GB SSD, 14 inch', 'Available'),
('LAP003', 'Asus VivoBook 15', 1, 3, 11000000, 14000000, 20, 5, 12, 'Intel Core i3, 8GB RAM, 256GB SSD, 15.6 inch', 'Available'),
('LAP004', 'Lenovo ThinkPad X1', 1, 4, 25000000, 30000000, 15, 3, 24, 'Intel Core i7, 16GB RAM, 512GB SSD, 14 inch', 'Available'),
('LAP005', 'Acer Nitro 5 Gaming', 1, 5, 20000000, 25000000, 12, 5, 12, 'Intel Core i5, 16GB RAM, 512GB SSD, GTX 1650, 15.6 inch', 'Available'),
('LAP006', 'MSI GF63 Thin', 1, 6, 18000000, 22000000, 3, 5, 12, 'Intel Core i5, 8GB RAM, 512GB SSD, GTX 1650, 15.6 inch', 'Available'),
('DES001', 'Dell OptiPlex 3080', 2, 1, 10000000, 13000000, 10, 3, 12, 'Intel Core i5, 8GB RAM, 256GB SSD', 'Available'),
('DES002', 'HP ProDesk 400 G7', 2, 2, 11000000, 14000000, 8, 3, 12, 'Intel Core i5, 8GB RAM, 512GB SSD', 'Available'),
('MON001', 'Dell P2422H 24inch', 3, 1, 3000000, 4000000, 40, 10, 36, '24 inch, Full HD, IPS, 60Hz', 'Available'),
('MON002', 'LG 27UP550 27inch 4K', 3, 7, 6000000, 8000000, 25, 5, 36, '27 inch, 4K UHD, IPS, 60Hz', 'Available'),
('KEY001', 'Logitech K380', 4, 8, 500000, 700000, 50, 10, 12, 'Wireless Bluetooth Keyboard', 'Available'),
('KEY002', 'Corsair K70 RGB', 4, 10, 2000000, 2500000, 15, 5, 24, 'Mechanical Gaming Keyboard, Cherry MX', 'Available'),
('MOU001', 'Logitech M331', 5, 8, 200000, 300000, 60, 15, 12, 'Wireless Silent Mouse', 'Available'),
('MOU002', 'Razer DeathAdder V2', 5, 9, 1000000, 1400000, 20, 5, 24, 'Gaming Mouse, 20000 DPI', 'Available'),
('HEA001', 'Logitech H111', 6, 8, 150000, 250000, 35, 10, 12, 'Stereo Headset with Mic', 'Available'),
('HEA002', 'Razer Kraken X', 6, 9, 800000, 1200000, 18, 5, 12, 'Gaming Headset, 7.1 Surround', 'Available');

-- Insert Customers
INSERT INTO customers (customer_code, full_name, phone, email, address, points, membership_level) VALUES
('CUS001', 'Nguyễn Văn A', '0911111111', 'nguyenvana@email.com', 'Hà Nội', 1500, 'Silver'),
('CUS002', 'Trần Thị B', '0922222222', 'tranthib@email.com', 'Hồ Chí Minh', 3500, 'Gold'),
('CUS003', 'Lê Văn C', '0933333333', 'levanc@email.com', 'Đà Nẵng', 500, 'Normal'),
('CUS004', 'Phạm Thị D', '0944444444', 'phamthid@email.com', 'Hải Phòng', 8000, 'Diamond'),
('CUS005', 'Hoàng Văn E', '0955555555', 'hoangvane@email.com', 'Cần Thơ', 200, 'Normal'),
('CUS006', 'Vũ Thị F', '0966666666', 'vuthif@email.com', 'Hà Nội', 2500, 'Silver'),
('CUS007', 'Đỗ Văn G', '0977777777', 'dovang@email.com', 'Hà Nội', 150, 'Normal');

-- Insert Suppliers
INSERT INTO suppliers (supplier_code, company_name, contact_person, phone, email, address) VALUES
('SUP001', 'Công ty TNHH Phân phối Dell Việt Nam', 'Nguyễn Văn X', '0281234567', 'contact@dellvn.com', 'Hà Nội'),
('SUP002', 'Công ty CP Máy tính HP Việt Nam', 'Trần Thị Y', '0282234567', 'info@hpvn.com', 'Hồ Chí Minh'),
('SUP003', 'Nhà phân phối Asus Việt Nam', 'Lê Văn Z', '0283234567', 'sales@asusvn.com', 'Hà Nội'),
('SUP004', 'Công ty Logitech Việt Nam', 'Phạm Thị K', '0284234567', 'contact@logitech.vn', 'Hồ Chí Minh');

-- Insert Orders
INSERT INTO orders (order_code, customer_id, employee_id, order_date, subtotal, discount_percent, discount_amount, total_amount, payment_method, status, notes) VALUES
('ORD001', 1, 3, '2024-01-15 10:30:00', 30000000, 5, 1500000, 28500000, 'Cash', 'Completed', 'Khách hàng thanh toán ngay'),
('ORD002', 2, 3, '2024-01-20 14:45:00', 16000000, 10, 1600000, 14400000, 'BankTransfer', 'Completed', 'Chuyển khoản'),
('ORD003', 3, 5, '2024-02-05 09:15:00', 8000000, 0, 0, 8000000, 'Cash', 'Completed', NULL),
('ORD004', 4, 3, '2024-02-10 16:20:00', 25000000, 5, 1250000, 23750000, 'Card', 'Completed', 'Thanh toán thẻ'),
('ORD005', 1, 5, '2024-02-28 11:00:00', 4000000, 0, 0, 4000000, 'Cash', 'Completed', NULL),
('ORD006', 5, 3, '2024-03-05 13:30:00', 14000000, 0, 0, 14000000, 'Cash', 'Pending', 'Đơn hàng chờ xác nhận'),
('ORD007', 6, 5, '2024-03-10 10:00:00', 2500000, 5, 125000, 2375000, 'Cash', 'Confirmed', 'Đã xác nhận');

-- Insert Order Details
INSERT INTO order_details (order_id, product_id, quantity, unit_price, subtotal) VALUES
(1, 4, 1, 30000000, 30000000),
(2, 2, 1, 16000000, 16000000),
(3, 10, 1, 8000000, 8000000),
(4, 5, 1, 25000000, 25000000),
(5, 9, 1, 4000000, 4000000),
(6, 3, 1, 14000000, 14000000),
(7, 12, 1, 2500000, 2500000);

-- Insert Imports
INSERT INTO imports (import_code, supplier_id, employee_id, import_date, total_amount, notes) VALUES
('IMP001', 1, 2, '2023-12-01 09:00:00', 120000000, 'Nhập hàng Dell tháng 12'),
('IMP002', 2, 2, '2023-12-05 10:30:00', 130000000, 'Nhập hàng HP tháng 12'),
('IMP003', 3, 2, '2024-01-10 14:00:00', 110000000, 'Nhập hàng Asus tháng 1'),
('IMP004', 4, 2, '2024-02-15 11:00:00', 15000000, 'Nhập phụ kiện Logitech');

-- Insert Import Details
INSERT INTO import_details (import_id, product_id, quantity, unit_price, subtotal) VALUES
(1, 1, 10, 12000000, 120000000),
(2, 2, 10, 13000000, 130000000),
(3, 3, 10, 11000000, 110000000),
(4, 11, 30, 500000, 15000000);
