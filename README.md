# TargDeMuzica - Music Marketplace

TargDeMuzica is a comprehensive web application built with ASP.NET Core that serves as a digital marketplace for music products. The platform allows users to browse, purchase, and review various music formats including vinyl records, CDs, digital downloads, and cassettes.

## Features

### User Management
- Multiple user roles: Administrator, Collaborator, and Regular Users (UserN and UserI)
- Secure authentication and authorization
- User profile management
- Role-based access control for different functionalities

### Product Management
- Comprehensive product catalog with detailed information
- Support for multiple music formats (Vinyl, CD, Digital Download, Cassette)
- Product categorization by artist and format
- Product search and sorting functionality
- Product ratings and review system
- Image upload support for product covers

### Artist Management
- Artist profiles with biographical information
- Connection between artists and their products
- Artist search and filtering capabilities

### Shopping Features
- Shopping cart functionality
- Order management system
- Price tracking and calculation

### Review System
- Star-based rating system (1-5 stars)
- Written review support
- Date tracking for reviews
- Review management (edit/delete) for administrators

### Content Moderation
- Product submission system for collaborators
- Administrative review process for new product submissions
- Comment moderation capabilities

## Technical Details

### Technologies Used
- ASP.NET Core MVC
- Entity Framework Core
- Microsoft Identity for authentication and authorization
- SQL Server for data storage
- Bootstrap for frontend styling

### Data Models
- ApplicationUser: Extends IdentityUser for user management
- Artist: Manages artist information
- Cart: Handles shopping cart functionality
- Product: Core product information and relationships
- Review: User reviews and ratings
- MusicSuport: Product category management
- IncomingRequest: Handles new product submissions

### Key Components
- Role-based authorization
- File upload handling
- Entity relationships
- CRUD operations for all major entities
- Search and filter functionality
- Image management
- User interface for different user roles

## Setup Instructions

1. Prerequisites:
   - Visual Studio 2022 or later
   - .NET 6.0 SDK or later
   - SQL Server (Local or Express)

2. Database Setup:
   ```bash
   Update-Database
   ```

3. Initial Configuration:
   - The system comes with predefined roles:
     * Administrator
     * Collaborator
     * UserN (Normal User)
     * UserI (Identified User)
   - Default admin credentials:
     * Email: admin@test.com
     * Password: Admin1!

4. Running the Application:
   - Open the solution in Visual Studio
   - Restore NuGet packages
   - Build the solution
   - Run the application

## Usage Guidelines

### For Administrators
- Full access to all system features
- Can manage users, roles, and content
- Review and approve product submissions
- Manage artist profiles

### For Collaborators
- Can submit new products for review
- Manage their own submissions
- Write reviews and ratings

### For Regular Users
- Browse and search products
- Make purchases
- Write reviews (if authenticated)
- Manage their shopping cart

## Project Structure

```
TargDeMuzica/
├── Controllers/          # MVC Controllers
├── Models/              # Data Models
├── Views/               # MVC Views
├── Data/               # Database Context
├── wwwroot/            # Static Files
└── Properties/         # Project Properties
```

## Acknowledgments

- Built with ASP.NET Core
- Uses Entity Framework Core for data access
- Bootstrap for responsive design
- FontAwesome for icons
