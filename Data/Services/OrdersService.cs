using ePharma_asp_mvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ePharma_asp_mvc.Data.Services
{
    public class OrdersService : IOrdersService
    {
        private readonly AppDbContext _context;

        public OrdersService(AppDbContext context)
        {
            _context = context;

        }
        public async Task CreateOrder(string userId, List<ShoppingCartItem> shoppingCartItems, string prescriptionPhotoPath)
        {
            var order = new Order
            {
                UserId = userId,
                TimeOrdered = DateTime.Now,
                Status = "Pending Confirmation", //Initial status of an order.
                OrderItems = new List<OrderItem>(),
            };

            double total = 0;

            foreach(var item in shoppingCartItems) //Inserting all the current ShoppingCart items to the order.
            {
                var orderItem = new OrderItem
                {
                    ProductId = item.ProductId,
                    Quantity = item.Quantity,
                };

                total += (item.Product.Price * item.Quantity);
                order.OrderItems.Add(orderItem);

            }

            order.PrescriptionPhoto = prescriptionPhotoPath;
            order.TotalPrice = total;

            _context.Orders.Add(order);

            await _context.SaveChangesAsync();

        }

        public Task<IEnumerable<OrderItem>> GetAllOrderItemsAsync()
        {
            throw new NotImplementedException();
        }
    }
}
