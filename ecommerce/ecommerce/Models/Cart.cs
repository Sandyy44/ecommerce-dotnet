using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ecommerce.Models
{
    [PrimaryKey(nameof(UserID), nameof(ProductID))]
    public class Cart
    {
        [ForeignKey("User")]
        [Column(Order = 1)]
        public virtual int UserID { get; set; }
        [ForeignKey("Product")]
        [Column(Order = 2)]
        public virtual int ProductID { get; set; }
        [Display(Name ="Add To Cart Date")]
        public virtual User User { get; set; }
        public virtual Product Product { get; set; }
        public DateTime AddToCartDate { get; set; } = DateTime.Now;

    }
}
