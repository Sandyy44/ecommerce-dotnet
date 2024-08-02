using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using ecommerce.Models;
using ecommerce.ViewModel;

namespace ecommerce.Controllers
{
    public class EcommerceController : Controller
    {
        public EcommerceContext ecommerce = new EcommerceContext();
        public EcommerceViewModel viewModel = new EcommerceViewModel();
        public IActionResult Welcome()
        {
            viewModel = new EcommerceViewModel();
            return View("Welcome");
        }
        public IActionResult AdminLogin()
        {
            
            return View("AdminLogin",viewModel);
        }
        public IActionResult UserLogin()
        {
            return View("UserLogin",viewModel);
        }
        public IActionResult EditProducts()
        {
            List<Product> products = ecommerce.Products.ToList();
            viewModel.Products = products;
            return View("EditProducts",viewModel);
        }
        
        public IActionResult UpdateProduct(int id)
        {
            Product p = ecommerce.Products.FirstOrDefault(x => x.ProductID == id);
            viewModel.Product = p;

            return View("UpdateProduct",viewModel);
        }
        public IActionResult AdminHome()
        {
            List<Product> products = ecommerce.Products.ToList();
            viewModel.Products = products;
            return View("AdminHome",viewModel);
        }
        public IActionResult UserHome(int id)
        {
            User us = ecommerce.Users.FirstOrDefault(x => x.UserID == id);
            viewModel.Message = "";
            List<Product> products = ecommerce.Products.ToList();
            viewModel.Products = products;
            viewModel.User = us;
            return View("UserHome", viewModel);
        }
        public IActionResult UpdateProfile(int id)
        {
            User user = ecommerce.Users.FirstOrDefault(x => x.UserID == id);
            viewModel.User = user;
            Address address = ecommerce.Address.FirstOrDefault(x => x.UserID == id);
            viewModel.Address = address;
            return View("UpdateProfile",viewModel);
        }
        public IActionResult DoneUpdatingProfile(EcommerceViewModel vm)
        {
            User user = ecommerce.Users.FirstOrDefault(x => x.UserID == vm.User.UserID);
            Address address = ecommerce.Address.FirstOrDefault(x => x.UserID == vm.User.UserID);
            user.PhoneNumber = vm.User.PhoneNumber;
            user.Username = vm.User.Username;
            user.BirthDate = vm.User.BirthDate;
            user.ProfilePicture = vm.User.ProfilePicture;
            address.Street = vm.Address.Street;
            address.City = vm.Address.City;
            address.Country= vm.Address.Country;
            ecommerce.SaveChanges();
            user = ecommerce.Users.FirstOrDefault(x => x.UserID == vm.User.UserID);
            viewModel.User = user;
            List<Cart> carts = ecommerce.Carts.Where(x => x.UserID == vm.User.UserID).ToList();
            List<Product> products = new List<Product>();
            address = ecommerce.Address.FirstOrDefault(x => x.UserID == vm.User.UserID);
            viewModel.Address = address;
            foreach (Cart c in carts)
            {
                Product product = ecommerce.Products.FirstOrDefault(x => x.ProductID == c.ProductID);

                products.Add(product);
            }
            viewModel.Products = products;
            return View("Profile", viewModel);
        }
        public IActionResult Profile(int id)
        {
            User user = ecommerce.Users.FirstOrDefault(x=>x.UserID==id);
            viewModel.User = user;
            List<Cart> carts = ecommerce.Carts.Where(x=>x.UserID== id).ToList();
            List<Product> products = new List<Product>();
            Address address = ecommerce.Address.FirstOrDefault(x=>x.UserID == id);
            viewModel.Address = address;
            foreach (Cart c in carts)
            {
                Product product = ecommerce.Products.FirstOrDefault(x=>x.ProductID==c.ProductID);

                products.Add(product);
            }
                viewModel.Products=products;
                return View("Profile",viewModel);
        }
        public IActionResult AddProduct()
        {
            return View("AddProduct");
        }
        public IActionResult CheckAdmin(Admin admin)
        {
            Admin ad = ecommerce.Admins.FirstOrDefault(x => x.AdminEmail == admin.AdminEmail);

            if (ad != null && ad.AdminPassword == admin.AdminPassword)
            {
                return RedirectToAction("AdminHome");
            }
            else
            {
                viewModel.Message = "Please Enter A Valid Email Address Or Password.";
                return View("AdminLogin",viewModel);
            }
        }
        public IActionResult CheckUser(User user)
        {
            User us = ecommerce.Users.FirstOrDefault(x => x.UserEmail == user.UserEmail);
            viewModel.Message = "";

            if (us != null && us.UserPassword == user.UserPassword)
            {
                List<Product> products = ecommerce.Products.ToList();
                viewModel.Products = products;
                viewModel.User=us;
                return View("UserHome", viewModel);
            }
            else
            {
                viewModel.Message = "Please Enter A Valid Email Address Or Password.";
                return View("UserLogin", viewModel);
            }
        }

         public IActionResult DeleteProduct(int id)
         {

            Product p = ecommerce.Products.FirstOrDefault(x => x.ProductID == id);
            if (p != null)
            {
                ecommerce.Products.Remove(p);
                ecommerce.SaveChanges();
                return RedirectToAction("EditProducts");

            }
            else
            {
                return View("error");

            }
         }

         public IActionResult AddNewProduct(Product product)
         {
                 ecommerce.Products.Add(product);
                 ecommerce.SaveChanges();
            return RedirectToAction("EditProducts");


        }
        public IActionResult DoneUpdatingProduct(Product product)
        {
            Product? p = ecommerce.Products.FirstOrDefault(x => x.ProductID == product.ProductID);
            p.ProductName= product.ProductName;
            p.Price= product.Price;
            p.Description= product.Description;
            p.ProductImage= product.ProductImage;

            ecommerce.SaveChanges();
            return RedirectToAction("EditProducts");

        }

        public IActionResult ShowProduct(int pid, int uid)
        {

            Product p = ecommerce.Products.FirstOrDefault(x => x.ProductID == pid);
             viewModel.Product = p;
            User us = ecommerce.Users.FirstOrDefault(x => x.UserID == uid);
            viewModel.User = us;

            return View("ShowProduct", viewModel);
        }
        public IActionResult ProductDetails(int id)
        {

            Product p = ecommerce.Products.FirstOrDefault(x => x.ProductID ==id);
            viewModel.Product = p;
            
            return View("ProductDetails", viewModel);
        }
        public IActionResult AddToCart(int pid,int uid)
		{

			Product p = ecommerce.Products.FirstOrDefault(x => x.ProductID == pid);
            Cart cart = new Cart();
            cart.ProductID = pid;
            cart.UserID = uid;
            ecommerce.Carts.Add(cart);
            ecommerce.SaveChanges();
            User us = ecommerce.Users.FirstOrDefault(x => x.UserID == uid);
            viewModel.Message = "";
            List<Product> products = ecommerce.Products.ToList();
            viewModel.Products = products;
            viewModel.User = us;
            return View("UserHome", viewModel);
        }
        public IActionResult RemoveFromCart(int pid, int uid)
        {
            Cart cart = ecommerce.Carts.FirstOrDefault(x => x.ProductID == pid && x.UserID == uid);
            ecommerce.Remove(cart);
            ecommerce.SaveChanges();
            User user = ecommerce.Users.FirstOrDefault(x => x.UserID == uid);
            viewModel.User = user;
            List<Cart> carts = ecommerce.Carts.Where(x => x.UserID == uid).ToList();
            List<Product> products = new List<Product>();
            Address address = ecommerce.Address.FirstOrDefault(x => x.UserID == uid);
            viewModel.Address = address;
            foreach (Cart c in carts)
            {
                Product product = ecommerce.Products.FirstOrDefault(x => x.ProductID == c.ProductID);

                products.Add(product);
            }
            viewModel.Products = products;
            return View("Profile", viewModel);
        }


    }
}

