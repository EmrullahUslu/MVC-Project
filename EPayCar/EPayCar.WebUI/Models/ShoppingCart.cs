namespace EPayCar.WebUI.Models
{
    public class ShoppingCart
    {
        public List<ShoppingCartItem> CartItems { get; set; }
        public decimal TotalAmount { get; set; }
    }
}
