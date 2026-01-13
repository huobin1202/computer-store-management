using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ComputerStoreManagement.Models
{
    [Table("products")]
    public class Product
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [Column("product_code")]
        [MaxLength(20)]
        public string ProductCode { get; set; } = string.Empty;

        [Required]
        [Column("name")]
        [MaxLength(200)]
        public string Name { get; set; } = string.Empty;

        [Column("category_id")]
        public int? CategoryId { get; set; }

        [Column("brand_id")]
        public int? BrandId { get; set; }

        [Required]
        [Column("cost_price")]
        public decimal CostPrice { get; set; }

        [Required]
        [Column("sell_price")]
        public decimal SellPrice { get; set; }

        [Column("quantity")]
        public int Quantity { get; set; } = 0;

        [Column("min_quantity")]
        public int MinQuantity { get; set; } = 5;

        [Column("warranty_months")]
        public int WarrantyMonths { get; set; } = 12;

        [Column("specifications")]
        public string? Specifications { get; set; }

        [Column("image_url")]
        [MaxLength(255)]
        public string? ImageUrl { get; set; }

        [Column("status")]
        [MaxLength(20)]
        public string Status { get; set; } = "Available";

        [Column("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        // Navigation properties
        [ForeignKey("CategoryId")]
        public virtual Category? Category { get; set; }

        [ForeignKey("BrandId")]
        public virtual Brand? Brand { get; set; }

        public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
        public virtual ICollection<ImportDetail> ImportDetails { get; set; } = new List<ImportDetail>();
    }
}
