using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ComputerStoreManagement.Models
{
    [Table("suppliers")]
    public class Supplier
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [Column("supplier_code")]
        [MaxLength(20)]
        public string SupplierCode { get; set; } = string.Empty;

        [Required]
        [Column("company_name")]
        [MaxLength(200)]
        public string CompanyName { get; set; } = string.Empty;

        [Column("contact_person")]
        [MaxLength(100)]
        public string? ContactPerson { get; set; }

        [Column("phone")]
        [MaxLength(15)]
        public string? Phone { get; set; }

        [Column("email")]
        [MaxLength(100)]
        public string? Email { get; set; }

        [Column("address")]
        [MaxLength(255)]
        public string? Address { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        // Navigation properties
        public virtual ICollection<Import> Imports { get; set; } = new List<Import>();
    }
}
