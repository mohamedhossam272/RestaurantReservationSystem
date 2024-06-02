# Restaurant Reservation System

This project is a Restaurant Reservation System built with ASP.NET Core MVC. It includes functionalities for managing restaurant reservations, user authentication, and role-based access control.

## Features

- User Registration and Login
- Role Management (Admin and User roles)
- Restaurant Management
- Table Management
- Reservation Management
- Password Reset via Email
- Exception Handling and Custom Error Pages

## Getting Started

### Prerequisites

- [.NET 6 SDK](https://dotnet.microsoft.com/download/dotnet/6.0)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)

### Installation

1. Clone the repository:

    ```sh
    git clone https://github.com/yourusername/RestaurantReservationSystem.git
    cd RestaurantReservationSystem
    ```

### Project Structure

- **Models**: Contains the entity classes such as `Restaurant`, `Table`, `Reservation`, and `ApplicationRole`.
- **Controllers**: Contains the MVC controllers for handling requests and actions, such as `HomeController`, `AccountController`, `RestaurantController`, and `RoleController`.
- **Views**: Contains the Razor views for the application.
- **DAL/Context**: Contains the `ApplicationDbContext` class for EF Core.
- **Services**: Contains the email service implementation.
- **Filters**: Contains custom filters for exception handling.

### Key Implementations

#### User Registration and Login

Implemented using ASP.NET Core Identity. Users can register, login, and reset passwords via email.

#### Role Management

Roles are managed through the `RoleController`. Admins can create and manage roles.

#### Restaurant Management

Admins can manage restaurants, tables, and reservations through the respective controllers and views.

#### Password Reset via Email

Password reset functionality is implemented using Ethereal email service. Users can request a password reset link which is sent to their email.

#### Exception Handling and Custom Error Pages

Custom exception handling is implemented using middleware and filters. Unauthorized access redirects to a custom `AccessDenied` page.

### Roles and Authorization

- **Admin**: Full access to manage users, roles, restaurants, tables, and reservations.
- **User**: Limited access to make reservations.

