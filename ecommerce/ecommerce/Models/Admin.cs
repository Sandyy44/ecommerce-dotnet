using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ecommerce.Models
{
    public class Admin
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int AdminID { get; set; }
        [Required]
        [Display(Name ="Email")]
        public string AdminEmail { get; set; }
        [Required]
        [Display(Name ="Password")]
        public string AdminPassword { get; set; }
    }
}
