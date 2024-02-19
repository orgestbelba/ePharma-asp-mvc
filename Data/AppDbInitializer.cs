using ePharma_asp_mvc.Models;
using ePharma_asp_mvc.Static;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ePharma_asp_mvc.Data
{
    public class AppDbInitializer
    {

        //Seeding the default data.
        public static void SeedProducts(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {

                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

                context.Database.EnsureCreated();

                //Product
                if (!context.Products.Any())
                {
                    context.Products.AddRange(new List<Product>()
                    {
                        new Product()
                        {
                            Name = "Bioderma",
                            ImagePath = "~/images/product_01.png",
                            Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Eius repellat, dicta at laboriosam, nemo exercitationem itaque eveniet architecto cumque, deleniti commodi molestias repellendus quos sequi hic fugiat asperiores illum. Atque, in, fuga excepturi corrupti error corporis aliquam unde nostrum quas.Accusantium dolor ratione maiores est deleniti nihil? Dignissimos est, sunt nulla illum autem in, quibusdam cumque recusandae, laudantium minima repellendus.",
                            Price = 7,
                            NeedsPrescription = false
                        },
                        new Product()
                        {
                            Name = "Chanca Pedra",
                            ImagePath = "~/images/product_02.png",
                            Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Eius repellat, dicta at laboriosam, nemo exercitationem itaque eveniet architecto cumque, deleniti commodi molestias repellendus quos sequi hic fugiat asperiores illum. Atque, in, fuga excepturi corrupti error corporis aliquam unde nostrum quas.Accusantium dolor ratione maiores est deleniti nihil? Dignissimos est, sunt nulla illum autem in, quibusdam cumque recusandae, laudantium minima repellendus.",
                            Price = 11,
                            NeedsPrescription = true
                        },
                        new Product()
                        {
                            Name = "Umcka ColdCare",
                            ImagePath = "~/images/product_03.png",
                            Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Eius repellat, dicta at laboriosam, nemo exercitationem itaque eveniet architecto cumque, deleniti commodi molestias repellendus quos sequi hic fugiat asperiores illum. Atque, in, fuga excepturi corrupti error corporis aliquam unde nostrum quas.Accusantium dolor ratione maiores est deleniti nihil? Dignissimos est, sunt nulla illum autem in, quibusdam cumque recusandae, laudantium minima repellendus.",
                            Price = 5,
                            NeedsPrescription = false
                        },
                        new Product()
                        {
                            Name = "Cetyl Pure",
                            ImagePath = "~/images/product_04.png",
                            Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Eius repellat, dicta at laboriosam, nemo exercitationem itaque eveniet architecto cumque, deleniti commodi molestias repellendus quos sequi hic fugiat asperiores illum. Atque, in, fuga excepturi corrupti error corporis aliquam unde nostrum quas.Accusantium dolor ratione maiores est deleniti nihil? Dignissimos est, sunt nulla illum autem in, quibusdam cumque recusandae, laudantium minima repellendus.",
                            Price = 15,
                            NeedsPrescription = true
                        },
                        new Product()
                        {
                            Name = "CLACore",
                            ImagePath = "~/images/product_05.png",
                            Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Eius repellat, dicta at laboriosam, nemo exercitationem itaque eveniet architecto cumque, deleniti commodi molestias repellendus quos sequi hic fugiat asperiores illum. Atque, in, fuga excepturi corrupti error corporis aliquam unde nostrum quas.Accusantium dolor ratione maiores est deleniti nihil? Dignissimos est, sunt nulla illum autem in, quibusdam cumque recusandae, laudantium minima repellendus.",
                            Price = 8,
                            NeedsPrescription = false
                        },
                        new Product()
                        {
                            Name = "Poo-Pourt",
                            ImagePath = "~/images/product_06.png",
                            Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Eius repellat, dicta at laboriosam, nemo exercitationem itaque eveniet architecto cumque, deleniti commodi molestias repellendus quos sequi hic fugiat asperiores illum. Atque, in, fuga excepturi corrupti error corporis aliquam unde nostrum quas.Accusantium dolor ratione maiores est deleniti nihil? Dignissimos est, sunt nulla illum autem in, quibusdam cumque recusandae, laudantium minima repellendus.",
                            Price = 20,
                            NeedsPrescription = true
                        },
                        new Product()
                        {
                            Name = "Ibuprofen",
                            ImagePath = "~/images/product_07.png",
                            Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Eius repellat, dicta at laboriosam, nemo exercitationem itaque eveniet architecto cumque, deleniti commodi molestias repellendus quos sequi hic fugiat asperiores illum. Atque, in, fuga excepturi corrupti error corporis aliquam unde nostrum quas.Accusantium dolor ratione maiores est deleniti nihil? Dignissimos est, sunt nulla illum autem in, quibusdam cumque recusandae, laudantium minima repellendus.",
                            Price = 8,
                            NeedsPrescription = false
                        },

                    });

                    context.SaveChanges();
                }
            }
        }

        public static async Task SeedUsersAndRolesAsync(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {

                //Roles
                var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
                if (!await roleManager.RoleExistsAsync(UserRoles.User))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.User));

                //Users
                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();

                //Admin
                string adminUserEmail = "admin@etickets.com";

                var adminUser = await userManager.FindByEmailAsync(adminUserEmail);
                if (adminUser == null)
                {
                    var newAdminUser = new ApplicationUser()
                    {
                        FirstName = "Admin",
                        LastName = "Admin",
                        UserName = "admin",
                        Email = adminUserEmail,
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(newAdminUser, "Coding@1234?");
                    await userManager.AddToRoleAsync(newAdminUser, UserRoles.Admin);
                }

                //User1
                string appUserEmail = "user1@gmail.com";

                var appUser = await userManager.FindByEmailAsync(appUserEmail);
                if (appUser == null)
                {
                    var newAppUser = new ApplicationUser()
                    {
                        FirstName = "First",
                        LastName = "User",
                        UserName = "user1",
                        Email = appUserEmail,
                        EmailConfirmed = true,
                        Address = "1010, Tirana, Albania",
                    };
                    await userManager.CreateAsync(newAppUser, "Password1!");
                    await userManager.AddToRoleAsync(newAppUser, UserRoles.User);
                }

                //User2
                string userEmail2 = "user2@yahoo.com";
                var user2 = await userManager.FindByEmailAsync(userEmail2);
                if (user2 == null)
                {
                    var newUser2 = new ApplicationUser()
                    {
                        FirstName = "Second",
                        LastName = "User",
                        UserName = "user2",
                        Email = userEmail2,
                        EmailConfirmed = true,
                        Address = "3407, Prrenjas, Albania"
                    };

                    await userManager.CreateAsync(newUser2, "Password1!");
                    await userManager.AddToRoleAsync(newUser2, UserRoles.User);
                }
            }
        }
    }
}
