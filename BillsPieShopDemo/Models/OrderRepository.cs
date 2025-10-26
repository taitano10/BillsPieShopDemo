namespace BillsPieShopDemo.Models
{
    public class OrderRepository : IOrderRepository
    {
        private readonly BillsPieShopDbContext _billsPieShopDbContext;
        private readonly IShoppingCart _shoppingCart;

        public OrderRepository(BillsPieShopDbContext billsPieShopDbContext, IShoppingCart shoppingCart)
        {
            _billsPieShopDbContext = billsPieShopDbContext;
            _shoppingCart = shoppingCart;
        }

        public void CreateOrder(Order order)
        {
            order.OrderPlaced = DateTime.Now;

            List<ShoppingCartItem>? shoppingCartItems = _shoppingCart.ShoppingCartItems;
            order.OrderTotal = _shoppingCart.GetShoppingCartTotal();

            order.OrderDetails = new List<OrderDetail>();

            foreach (ShoppingCartItem? shoppingCartItem in shoppingCartItems)
            {
                var orderDetail = new OrderDetail
                {
                    Amount = shoppingCartItem.Amount,
                    PieId = shoppingCartItem.Pie.PieId,
                    Price = shoppingCartItem.Pie.Price
                };

                order.OrderDetails.Add(orderDetail);
            }

            _billsPieShopDbContext.Orders.Add(order);

            _billsPieShopDbContext.SaveChanges();
        }
    }
}
