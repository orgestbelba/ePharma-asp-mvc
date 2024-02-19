using ePharma_asp_mvc.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ePharma_asp_mvc.Data.Services
{
    public interface IOrdersService
    {
        Task<IEnumerable<OrderItem>> GetAllOrderItemsAsync(int orderId);
        Task<IEnumerable<Order>> GetAllOrdersAsync(string userId);
        Task CreateOrder(string userId, List<ShoppingCartItem> shoppingCartItems, string prescriptionPhotoPath);

    }
}
