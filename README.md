# ePharma ASP.NET MVC Online Pharmacy Shop

Welcome to ePharma, an online pharmacy shop web application built with ASP.NET MVC!

## Features

- **User Authentication**: Users can register and log in securely.
- **Product Management**: Users can browse products, add them to their shopping carts, and proceed to order them.
- **Prescription Upload**: If a product requires a prescription from a doctor, a partial view will prompt the user to upload a picture of the prescription.
- **Future Development**:
  - **Admin Console**: Implementing an admin console for managing products, orders, and users.
  - **Pagination**: Adding pagination for better navigation through product listings.
  - **PayPal Integration**: Integrating PayPal for secure and convenient payment processing.

## Technologies Used

- **.NET 5**: The foundation of the application, providing a robust and modern framework for development.
- **Entity Framework Core**: Used for data access and database management.
- **Fluent API**: Employed for configuring the database context and defining the relationships between entities.
- **Identity Framework**: For secure user authentication and authorization.
- **Dependency Injection**: Utilized for managing object dependencies and promoting loose coupling.
- **EntityBase Repository**: A generic repository pattern for common CRUD operations on entities.

## Getting Started

1. **Clone the Repository**: `git clone https://github.com/orgestbelba/ePharma-asp-mvc.git`
2. **Navigate to the Project Directory**: `cd ePharma-asp-mvc`
3. **Install Dependencies**: `dotnet restore`
4. **Set up the Database**: Ensure your connection string is configured correctly in `appsettings.json` and then run `dotnet ef database update` to apply migrations.
5. **Run the Application**: `dotnet run`
6. **Access the Application**: Open your browser and navigate to `https://localhost:5001` to start using the ePharma web app.

## Contributing

Contributions are welcome! If you'd like to contribute to the project, please fork the repository and submit a pull request with your changes.
