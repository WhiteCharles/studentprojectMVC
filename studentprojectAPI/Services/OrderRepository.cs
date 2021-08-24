using studentprojectAPI.DbContexts;
using studentprojectAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace studentprojectAPI.Services
{
    public class OrderRepository : IOrderRepository
    {
        private readonly AppDbContext _appDbContext;
        private readonly ShoppingCart _shoppingCart;

        public OrderRepository(AppDbContext appDbContext, ShoppingCart shoppingCart)
        {
            _appDbContext = appDbContext;
            _shoppingCart = shoppingCart;
        }
        public void CreateOrder(Order order)
        {
            order.OrderPlaced = DateTime.Now;
            _appDbContext.Orders.Add(order);

            var shoppingCartItems = _shoppingCart.ShoppingCartItems; // added
            order.OrderTotal = _shoppingCart.GetShoppingCartTotal(); // added

            order.OrderDetails = new List<OrderDetail>();

            foreach (var shoppingCartItem in shoppingCartItems)
            {
                var orderDetail = new OrderDetail()
                {
                    Amount = shoppingCartItem.Amount,
                    RecordId = shoppingCartItem.Record.RecordId,
                    // OrderId = order.OrderId,
                    Price = shoppingCartItem.Record.Price
                };
                order.OrderDetails.Add(orderDetail);
                // _appDbContext.OrderDetails.Add(orderDetail); //inactive
            }
            _appDbContext.Orders.Add(order); // added

            _appDbContext.SaveChanges();
        }

    }
}
