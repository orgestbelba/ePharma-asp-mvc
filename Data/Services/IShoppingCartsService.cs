using ePharma_asp_mvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ePharma_asp_mvc.Data.Services
{
    public interface IShoppingCartsService
    {
        Task<IEnumerable<ShoppingCartItem>> GetAllItemsAsync(string userId);
        Task AddItemToShoppingCart(Product product, string userId);
        Task RemoveItemFromShoppingCart(int id);
        Task IncreaseItemQuantity(int id);
        Task DecreaseItemQuantity(int id);
        Task ClearShoppingCartItems(string userId);
    }
}
