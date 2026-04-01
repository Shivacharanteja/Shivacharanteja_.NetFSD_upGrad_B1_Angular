using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace EntityFrameworkAssignment1.Entities
{
    public class Account
    {
        [Key]
        public int AccountId { get; set; }

        [Required]
        public string ?AccountType { get; set; }
        [Required]
        public decimal ?Customer { get; set; }
        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Balance {  get; set; }

        public string Branch { get; set; }

        public DateTime CreateDate { get; set; }
    }
}
