using ePharma_asp_mvc.Data.Services;
using ePharma_asp_mvc.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ePharma_asp_mvc.Controllers
{
    public class OrderController : Controller
    {

        private readonly IProductsService _productsService;
        private readonly IShoppingCartsService _shoppingCartsService;
        private readonly UserManager<ApplicationUser> _userManager;

        public OrderController(IProductsService productsService, IShoppingCartsService shoppingCartsService, UserManager<ApplicationUser> userManager)
        {
            _productsService = productsService;
            _shoppingCartsService = shoppingCartsService;
            _userManager = userManager;
        }

        public async Task<IActionResult> ShoppingCart()
        {
            if (User.Identity.IsAuthenticated)
            {
                var currentUser = await _userManager.GetUserAsync(User);

                var data = await _shoppingCartsService.GetAllItemsAsync(currentUser.Id);

                var shoppingCartItems = data.ToList();

                if (data == null)
                {
                    return View();
                }
                return View(shoppingCartItems);
            }

            return View();
        }

        public async Task<IActionResult> AddToShoppingCart(int id)
        {

            if (User.Identity.IsAuthenticated)
            {
                var item = await _productsService.GetByID(id);

                var currentUser = await _userManager.GetUserAsync(User);

                if (item != null)
                {
                    await _shoppingCartsService.AddItemToShoppingCart(item, currentUser.Id);
                }
            }
            else
            {
                return View("LogInFirst");
            }

            return RedirectToAction(nameof(ShoppingCart));

        }

        public async Task<RedirectToActionResult> RemoveFromShoppingCart(int id)
        {

            await _shoppingCartsService.RemoveItemFromShoppingCart(id);

            return RedirectToAction(nameof(ShoppingCart));

        }

        public async Task<RedirectToActionResult> DecreaseQuantity(int id)
        {

            await _shoppingCartsService.DecreaseItemQuantity(id);

            return RedirectToAction(nameof(ShoppingCart));

        }

        public async Task<RedirectToActionResult> IncreaseQuantity(int id)
        {

            await _shoppingCartsService.IncreaseItemQuantity(id);

            return RedirectToAction(nameof(ShoppingCart));

        }

    }
}