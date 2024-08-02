using ecommerce.Models;

namespace ecommerce.ViewModel
{
    public class EcommerceViewModel
    { 
        public List<User>? Users { get; set; }
        public User? User { get; set; }
        public List<Product>? Products { get; set; }
        public Product? Product { get; set; }
        public Cart? Cart { get; set; }
        public List<Cart>? Carts { get; set; }
        public Admin? Admin { get; set; }
        public List<Admin>? Admins { get; set; }
        public Address? Address { get; set; }
        public List<Address>? Addresses { get; set; }
        public string Message { get; set; } = "";
        public int UserId {  get; set; }



    }
}
