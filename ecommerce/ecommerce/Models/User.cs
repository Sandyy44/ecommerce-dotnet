using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ecommerce.Models
{
    public class User
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int UserID { get; set; }
        [Required]
        [MinLength(2,ErrorMessage ="Username must be more than 1 charachter.")]
        [MaxLength(20, ErrorMessage ="Username can't be over 20 character.")]
        public string Username { get; set; }
        [Required]
        [Display(Name = "Email")]
        public string UserEmail { get; set; }
        [Required]
        [MinLength(5,ErrorMessage ="Password must be more than 5 characters.")]
        [Display(Name ="Password")]
        public string UserPassword { get; set; }
        [Display(Name ="Birth Date")]
        public DateTime BirthDate { get; set; }
        [MinLength(11,ErrorMessage ="Phone Number must be 11 Numbers")]
        [MaxLength(11)]
        [Display(Name ="Phone Number")]
        public string PhoneNumber { get; set; }
        [Display(Name ="Profile Picture")]
        public string? ProfilePicture { get; set; }
        
        public List<Product>? Products { get; set; }
    }
}
