# 🐱 CatBlog

[![.NET](https://img.shields.io/badge/.NET-7-blue)](https://dotnet.microsoft.com/)
[![License](https://img.shields.io/badge/License-MIT-green)](LICENSE)
[![Last Commit](https://img.shields.io/github/last-commit/<your-username>/CatBlog)](https://github.com/<your-username>/CatBlog)

A **personal Cat Blog** built with **ASP.NET Core MVC** and **Entity Framework Core**.  
Browse cat posts, read content, and enjoy cute cat images. Admin login only, no public registration.

## Table of Contents

- [Project Overview](#project-overview)
- [Technologies Used](#technologies-used)
- [Screenshot](#screenshot)
- [Getting Started](#getting-started)
  - [Prerequisites](#prerequisites)
  - [Installation](#installation)
- [Admin Login](#admin-login)
- [Project Structure](#project-structure)
- [Usage](#usage)
- [Future Improvements](#future-improvements)
- [License](#license)

## Project Overview

CatBlog is a simple blog dedicated to cats. Key features include:

- Display cat posts with **title, content, and images**.
- Admin login (no public registration allowed).
- Seed data for initial posts and admin account.
- Clean and responsive layout for posts.

## Technologies Used

- **ASP.NET Core MVC** (.NET 7 or later)
- **Entity Framework Core** (Code First)
- **SQL Server**
- **Razor Views**
- **HTML/CSS** (custom styling)
- **Bootstrap** (optional, for card styling)

## Screenshot

![CatBlog Screenshot](https://i.imgur.com/your-sample-image.jpg)  
*Replace the URL with an actual screenshot of your blog.*

## Getting Started

### Prerequisites

- **Visual Studio 2022** or later
- **.NET 7 SDK** or later
- **SQL Server** (local or remote)

### Installation

1. **Clone the repository**:

   ```bash
   git clone https://github.com/<your-username>/CatBlog.git
   cd CatBlog
   ```

2. **Restore NuGet packages**:

   ```bash
   dotnet restore
   ```

3. **Configure the connection string** in `appsettings.json`:

   ```json
   "ConnectionStrings": {
     "DefaultConnection": "Server=.;Database=CatBlogDB;Trusted_Connection=True;TrustServerCertificate=True;"
   }
   ```

4. **Build the project**:

   ```bash
   dotnet build
   ```

5. **Run EF Core migrations**:

   ```bash
   dotnet ef migrations add InitialCreate
   dotnet ef database update
   ```

## Admin Login

Default admin credentials are seeded in the database:

- **Username**: `admin`
- **Password**: `12345`

*Note*: Only the admin can log in; public registration is not supported.

## Project Structure

```
CatBlog/
├── Controllers/
│   ├── HomeController.cs
│   └── AdminController.cs
├── Models/
│   ├── Post.cs
│   ├── Admin.cs
│   └── LoginViewModel.cs
├── Data/
│   └── CatBlogContext.cs
├── Views/
│   ├── Home/
│   │   ├── Index.cshtml
│   │   └── Details.cshtml
│   ├── Admin/
│   │   └── Login.cshtml
│   └── Shared/
│       └── _Layout.cshtml
├── wwwroot/
│   ├── css/
│   └── js/
├── appsettings.json
└── Program.cs
```

## Usage

1. **Start the application**:

   ```bash
   dotnet run
   ```

2. Visit `https://localhost:5001/` (or the URL shown in the console).
3. Browse cat posts on the Home page.
4. Use the Admin Login link to manage posts (admin only).

## Future Improvements

- Add post creation and editing functionality for admins.
- Implement image upload instead of using URLs.
- Add categories or tags for posts.
- Enhance styling and responsiveness.
- Add a comments section for posts.

## License

This project is licensed under the [MIT License](LICENSE).