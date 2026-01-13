using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ComputerStoreManagement.Models
{
    [Table("employees")]
    public class Employee
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [Column("employee_code")]
        [MaxLength(20)]
        public string EmployeeCode { get; set; } = string.Empty;

        [Required]
        [Column("full_name")]
        [MaxLength(100)]
        public string FullName { get; set; } = string.Empty;

        [Column("gender")]
        [MaxLength(10)]
        public string? Gender { get; set; }

        [Column("birth_date")]
        public DateTime? BirthDate { get; set; }

        [Column("phone")]
        [MaxLength(15)]
        public string? Phone { get; set; }

        [Column("email")]
        [MaxLength(100)]
        public string? Email { get; set; }

        [Column("address")]
        [MaxLength(255)]
        public string? Address { get; set; }

        [Column("position")]
        [MaxLength(50)]
        public string? Position { get; set; }

        [Column("salary")]
        public decimal? Salary { get; set; }

        [Column("hire_date")]
        public DateTime? HireDate { get; set; }

        [Column("status")]
        [MaxLength(20)]
        public string Status { get; set; } = "Active";

        [Column("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        // Navigation properties
        public virtual ICollection<User> Users { get; set; } = new List<User>();
        public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
        public virtual ICollection<Import> Imports { get; set; } = new List<Import>();
    }
}
