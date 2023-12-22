using ePharma_asp_mvc.Data;
using ePharma_asp_mvc.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ePharma_asp_mvc.Data.ViewModels;
using ePharma_asp_mvc.Static;

namespace ePharma_asp_mvc.Controllers
{
    public class ApplicationUserController : Controller
    {
        // injecting the AppDbContext to the controller
        private readonly AppDbContext _context;

        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;


        public ApplicationUserController(AppDbContext context
            , UserManager<ApplicationUser> userManager
            , SignInManager<ApplicationUser> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<IActionResult> Index()
        {
            var data = await _context.Users.ToListAsync();
            return View();
        }

        public IActionResult LogIn()
        {
            var data = new LogInViewModel();
            return View(data);
        }

        [HttpPost]
        public async Task<IActionResult> LogIn(LogInViewModel LogInData)
        {
            if (!ModelState.IsValid)
            {
                return View(LogInData);
            }

            var user = await _userManager.FindByEmailAsync(LogInData.EmailAddress);
            if (user != null)
            {
                var validationCheck = await _userManager.CheckPasswordAsync(user, LogInData.Password);
                if (validationCheck)
                {
                    var result = await _signInManager.PasswordSignInAsync(user, LogInData.Password, false, false);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                TempData["Error"] = "Please check you credentials again!";
                return View(LogInData);
            }

            TempData["Error"] = "Please check you credentials again!";
            return View(LogInData);
        }

        public IActionResult SignUp()
        {
            var data = new SignUpViewModel();
            return View(data);
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(SignUpViewModel RegisterData)
        {
            if (!ModelState.IsValid)
                return View(RegisterData);

            var user = await _userManager.FindByEmailAsync(RegisterData.EmailAddress);
            if (user != null)
            {
                TempData["Error"] = "This email is already in use!";
                return View(RegisterData);
            }
            var newUser = new ApplicationUser()
            {
                FirstName = RegisterData.FirstName,
                LastName = RegisterData.LastName,
                UserName = RegisterData.UserName,
                Address = RegisterData.Address,
                Email = RegisterData.EmailAddress
            };

            var newUserResponse = await _userManager.CreateAsync(newUser, RegisterData.Password);

            if (newUserResponse.Succeeded)
                await _userManager.AddToRoleAsync(newUser, UserRoles.User);

            return View("RegistrationCompleted");
        }

        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
