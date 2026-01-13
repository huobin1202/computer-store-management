using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ComputerStoreManagement.Models
{
    [Table("imports")]
    public class Import
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [Column("import_code")]
        [MaxLength(20)]
        public string ImportCode { get; set; } = string.Empty;

        [Column("supplier_id")]
        public int? SupplierId { get; set; }

        [Column("employee_id")]
        public int? EmployeeId { get; set; }

        [Column("import_date")]
        public DateTime ImportDate { get; set; } = DateTime.Now;

        [Column("total_amount")]
        public decimal TotalAmount { get; set; }

        [Column("notes")]
        [MaxLength(500)]
        public string? Notes { get; set; }

        // Navigation properties
        [ForeignKey("SupplierId")]
        public virtual Supplier? Supplier { get; set; }

        [ForeignKey("EmployeeId")]
        public virtual Employee? Employee { get; set; }

        public virtual ICollection<ImportDetail> ImportDetails { get; set; } = new List<ImportDetail>();
    }
}
