using Microsoft.EntityFrameworkCore;

namespace ecommerce.Models
{
    public class EcommerceContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Address> Address { get; set; }
        public DbSet<Admin> Admins { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-MU5JGBB\\SQLEXPRESS;Database=ecommerceDb;Trusted_Connection=True;TrustServerCertificate=true;");
        }
    }
}
