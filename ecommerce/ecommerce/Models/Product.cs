using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ecommerce.Models
{
    public class Product
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int ProductID { get; set; }
        [Required]
        [Display(Name ="Product Name")]
        public string ProductName { get; set; }
        public string? Description { get; set; }
        [Required]
        public int Price { get; set; }
        [Display(Name ="Product Image")]
        public string? ProductImage { get; set; }
        [ForeignKey("User")]
        public virtual int UserID { get; set; }
        public virtual List<User>? Users { get; set; }


    }
}
