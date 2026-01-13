using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ComputerStoreManagement.Models
{
    [Table("orders")]
    public class Order
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [Column("order_code")]
        [MaxLength(20)]
        public string OrderCode { get; set; } = string.Empty;

        [Column("customer_id")]
        public int? CustomerId { get; set; }

        [Column("employee_id")]
        public int? EmployeeId { get; set; }

        [Column("order_date")]
        public DateTime OrderDate { get; set; } = DateTime.Now;

        [Column("subtotal")]
        public decimal Subtotal { get; set; }

        [Column("discount_percent")]
        public decimal DiscountPercent { get; set; } = 0;

        [Column("discount_amount")]
        public decimal DiscountAmount { get; set; } = 0;

        [Column("total_amount")]
        public decimal TotalAmount { get; set; }

        [Column("payment_method")]
        [MaxLength(20)]
        public string PaymentMethod { get; set; } = "Cash";

        [Column("status")]
        [MaxLength(20)]
        public string Status { get; set; } = "Pending";

        [Column("notes")]
        [MaxLength(500)]
        public string? Notes { get; set; }

        // Navigation properties
        [ForeignKey("CustomerId")]
        public virtual Customer? Customer { get; set; }

        [ForeignKey("EmployeeId")]
        public virtual Employee? Employee { get; set; }

        public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
    }
}
