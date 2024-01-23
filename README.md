ePharma is a web application created using ASP.NET MVC and Entity Framework. It
functions as an online pharmacy, providing user-friendly features such as user
authentication, product catalog, shopping cart, order placement, and order history.
Administrators have access to an admin console for product management and order
handling. This project is still being worked on and future plans include integrating PayPal
and an admin console for enhanced user experience.

To run the project you need to:

1. Change DefualtConnectionString @appsetting.json to yours.
2. Open Package Manager Console and create a new migration (Add-Migration InitialMigration then update-database)
3. There are currently some seed data that will populate your database once you run the project.
5. You can use these credentials for log in (e-mail: user1@gmail.com ; password: Coding@1234?) or you can create a new user.

P.S (Still unfinished with the placing orders and orders history)
