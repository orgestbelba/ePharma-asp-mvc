using ePharma_asp_mvc.Data.Services;
using ePharma_asp_mvc.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ePharma_asp_mvc.Controllers
{
    public class OrderController : Controller
    {

        private readonly IProductsService _productsService;
        private readonly IShoppingCartsService _shoppingCartsService;
        private readonly IOrdersService _ordersService;
        private readonly UserManager<ApplicationUser> _userManager;
        [Obsolete]
        private readonly IHostingEnvironment Environment;

        [Obsolete]
        public OrderController(IProductsService productsService, IShoppingCartsService shoppingCartsService, IOrdersService ordersService, UserManager<ApplicationUser> userManager, IHostingEnvironment _environment)
        {
            _productsService = productsService;
            _shoppingCartsService = shoppingCartsService;
            Environment = _environment;
            _ordersService = ordersService;
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


        public async Task<IActionResult> CheckOut()
        {

            var currentUser = await _userManager.GetUserAsync(User);
            var data = await _shoppingCartsService.GetAllItemsAsync(currentUser.Id);

            if (data == null || data.Count() == 0) // If there are no items in Cart, do not procceed to CheckOut
            {
                return RedirectToAction(nameof(ShoppingCart));
            }

            // Procceed to CheckOut all of the items in the Shopping Cart
            var shoppingCartItems = data.ToList();

            return View(shoppingCartItems);

        }

        [HttpPost]
        [Obsolete]
        public async Task<IActionResult> CheckOut(IFormFile prescriptionPhoto)
        {
            if (!ModelState.IsValid)
                return View();

            try
            {
                string prescriptionPhotoPath = "";

                if (prescriptionPhoto != null && prescriptionPhoto.Length > 0) // Check if there is any prescriptionPhoto uploaded and then process it.
                {
                    // Uploading the photo
                    string path = Path.Combine(this.Environment.WebRootPath, "images");
                    string fileName = Path.GetFileName(prescriptionPhoto.FileName);

                    using (FileStream stream = new(Path.Combine(path, fileName), FileMode.Create))
                    {
                        prescriptionPhoto.CopyTo(stream);
                    }

                    prescriptionPhotoPath = Path.Combine("~/images/", fileName);
                }

                var currentUser = await _userManager.GetUserAsync(User);

                var data = await _shoppingCartsService.GetAllItemsAsync(currentUser.Id);

                var shoppingCartItems = data.ToList();

                await _ordersService.CreateOrder(currentUser.Id, shoppingCartItems, prescriptionPhotoPath);

                // Clear the shoppingCart after the order is created.
                await _shoppingCartsService.ClearShoppingCartItems(currentUser.Id); 

                return View("ThankYou");
            }
            catch (Exception ex)
            {
                // Handle any exceptions that might occur during the insertion process
                ModelState.AddModelError("", "An error occurred while processing your request. Please try again later.");
                return View();
            }

        }

    }
}