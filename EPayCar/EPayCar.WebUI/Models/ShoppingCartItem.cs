namespace EPayCar.WebUI.Models
{
    public class ShoppingCartItem
    {
        public int ID { get; set; }
        public string CarName { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public decimal Total => Price * Quantity;

        internal void ClearCart()
        {
            throw new NotImplementedException();
        }
    }
}
