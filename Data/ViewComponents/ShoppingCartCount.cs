using ePharma_asp_mvc.Data.Services;
using ePharma_asp_mvc.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ePharma_asp_mvc.Data.ViewComponents
{
    
    public class ShoppingCartCount : ViewComponent
    {
        private readonly IShoppingCartsService _shoppingCartsService;
        private readonly UserManager<ApplicationUser> _userManager;
        public ShoppingCartCount(IShoppingCartsService shoppingCartsService, UserManager<ApplicationUser> userManager)
        {
            _shoppingCartsService = shoppingCartsService;
            _userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var currentUser = await _userManager.GetUserAsync(HttpContext.User);

            if(currentUser == null)
            {
                return View(0);
            }

            var items = await _shoppingCartsService.GetAllItemsAsync(currentUser.Id);

            return View(items.Count());
        }

    }
}
