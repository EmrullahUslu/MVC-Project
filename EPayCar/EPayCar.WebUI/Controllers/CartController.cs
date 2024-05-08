using EPayCar.Model.Entities;
using EPayCar.WebUI.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Linq.Expressions;
namespace EPayCar.WebUI.Controllers
{
    public class CartController : Controller
    {
        public IActionResult Index()
        {
            decimal total = 0;
            foreach (var item in GetCartItems())
            {
                total += item.Price * item.Quantity;
            }

            var cart = new ShoppingCart()
            {
                CartItems = GetCartItems(),
                TotalAmount = total
            };
            return View(cart);
        }
        public IActionResult AddToCart(Carscs car, int quantity = 1)
        {
            var cartItems = GetCartItems();
            AddCarsToCart(cartItems, car, quantity);
            SaveCartItems(cartItems);

            return RedirectToAction("Index");
        }
        private void AddCarsToCart(List<ShoppingCartItem> cartItems, Carscs car, int Quantity)
        {
            var record = cartItems.FirstOrDefault(x => x.ID == car.ID);

            if (record != null)
            {
                record.Quantity += Quantity;
            }
            else
            {
                cartItems.Add(new ShoppingCartItem { ID = car.ID, CarName = car.CareName, Price = Convert.ToDecimal(car.Price), Quantity = Quantity });
            }
        }

        public IActionResult RemoveToCart(int id, int quantity = 1)
        {
            var cartItems = GetCartItems();
            RemoveCarsToCart(cartItems, id, quantity);
            SaveCartItems(cartItems);

            return RedirectToAction("Index");
        }

        private void RemoveCarsToCart(List<ShoppingCartItem> cartItems, int CarId, int quantity)
        {
            var existCartItems = cartItems.FirstOrDefault(x => x.ID == CarId);
            if (existCartItems != null)
            {
                if (existCartItems.Quantity > quantity)
                {
                    existCartItems.Quantity -= quantity;
                }
                else
                {
                    cartItems.Remove(existCartItems);
                }
            }
        }

        public IActionResult ClearCart()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }

        public void SaveCartItems(List<ShoppingCartItem> cartItems)
        {
            var cartItemsJson = JsonConvert.SerializeObject(cartItems);
            HttpContext.Session.SetString("CartItems", cartItemsJson);
        }


        public List<ShoppingCartItem> GetCartItems()
        {
            var cartItems = HttpContext.Session.GetString("CartItems");

            if (cartItems == null)
            {
                return new List<ShoppingCartItem>();
            }
            return JsonConvert.DeserializeObject<List<ShoppingCartItem>>(cartItems);
        }
        public IActionResult PaySend()
        {
            decimal total = 0;
            foreach (var item in GetCartItems())
            {
                total += item.Price * item.Quantity;

            }
            ViewBag.Total = total;
            return View();
        }
    }
}
