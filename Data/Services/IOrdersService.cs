using ePharma_asp_mvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ePharma_asp_mvc.Data.Services
{
    public interface IOrdersService
    {
        Task<IEnumerable<OrderItem>> GetAllOrderItemsAsync();
        Task CreateOrder(string userId, List<ShoppingCartItem> shoppingCartItems, string prescriptionPhotoPath);

    }
}
