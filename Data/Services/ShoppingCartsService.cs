using ePharma_asp_mvc.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ePharma_asp_mvc.Data.Services
{
    public class ShoppingCartsService : IShoppingCartsService
    {

        private readonly AppDbContext _context;

        public ShoppingCartsService(AppDbContext context)
        {
            _context = context;

        }

        public async Task AddItemToShoppingCart(Product product, string userId)
        {
            //Check if a ShoppingCart is created for the current User.
            var data = _context.ShoppingCarts.FirstOrDefault(n => n.UserId == userId);

            if (data == null)
            {
                //Create one if there isn't one.
                _context.ShoppingCarts.Add(new ShoppingCart { UserId = userId });
                await _context.SaveChangesAsync();
            }

            //Check if the item already exists in shopping cart
            var shoppingCartId = _context.ShoppingCarts.FirstOrDefault(n => n.UserId == userId).Id;
            var shoppingCartItem = _context.ShoppingCartItems.FirstOrDefault(n => n.ShoppingCartId == shoppingCartId && n.ProductId == product.Id);

            if (shoppingCartItem == null)
            {
                shoppingCartItem = new ShoppingCartItem
                {
                    Product = product,
                    ShoppingCartId = shoppingCartId,
                    Quantity = 1,
                };

                _context.ShoppingCartItems.Add(shoppingCartItem);
            }
            else
            {
                shoppingCartItem.Quantity++;
            }

            await _context.SaveChangesAsync();

        }

        public async Task DecreaseItemQuantity(int id)
        {

            var shoppingCartItem = await _context.ShoppingCartItems.FirstOrDefaultAsync(n => n.Id == id);

            if (shoppingCartItem.Quantity > 1)
            {
                shoppingCartItem.Quantity--;
            }

            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<ShoppingCartItem>> GetAllItemsAsync(string userId)
        {

            var shoppingCart = _context.ShoppingCarts.FirstOrDefault(n => n.UserId == userId);

            if (shoppingCart == null)
            {
                // Return an empty list or handle the case where the shopping cart is not found.
                return Enumerable.Empty<ShoppingCartItem>();
            }

            var data = await _context.ShoppingCartItems
                .Where(n => n.ShoppingCartId == shoppingCart.Id)
                .Include(p => p.Product).ToListAsync();

            return data;

        }

        public async Task IncreaseItemQuantity(int id)
        {
            var shoppingCartItem = await _context.ShoppingCartItems.FirstOrDefaultAsync(n => n.Id == id);

            shoppingCartItem.Quantity++;

            await _context.SaveChangesAsync();
        }

        public async Task RemoveItemFromShoppingCart(int id)
        {
            var shoppingCartItem = await _context.ShoppingCartItems.FirstOrDefaultAsync(n => n.Id == id);

            _context.ShoppingCartItems.Remove(shoppingCartItem);

            await _context.SaveChangesAsync();

        }

        public async Task ClearShoppingCartItems(string userId)
        {
            var shoppingCartId = _context.ShoppingCarts.FirstOrDefault(n => n.UserId == userId).Id;

            var shoppingCartItems = await _context.ShoppingCartItems
                .Where(item => item.ShoppingCartId == shoppingCartId)
                .ToListAsync();

            foreach (var shoppingCartItem in shoppingCartItems)
            {
                _context.ShoppingCartItems.Remove(shoppingCartItem);
            }

            await _context.SaveChangesAsync();
        }
    }
}
