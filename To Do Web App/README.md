# TODO Web App

## 1. Introduction
This is a basic ASP.NET Core web app using the MVC framework. It supports user registration, login, and CRUD operations for managing TO DO items. You can also edit and delete your account.

**Backend:**
- Authentication with Cookies/Sessions
- Entity Framework Core for ORM
- Identity Core for user management
- SQLite for database

**Frontend:**
- Bootstrap

**Tooling:**
- Git Extensions for version control
- Visual Studio Code for editing
- Docker for containerization
- Windows 10 OS

For questions, feel free to contact me.

## 2. SDK Version
.NET Core SDK v3.1.301

## 3. Tools
- dotnet-ef
- dotnet-aspnet-codegenerator

## 4. Packages
- AutoMapper v10.0.0
- AutoMapper.Extensions.Microsoft.DependencyInjection v7.0.0
- Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore v3.1.5
- Microsoft.AspNetCore.Identity.EntityFrameworkCore v3.1.5
- Microsoft.AspNetCore.Identity.UI v3.1.5
- Microsoft.AspNetCore.Mvc.NewtonsoftJson v3.1.5
- Microsoft.EntityFrameworkCore.Design v3.1.5
- Microsoft.EntityFrameworkCore.Sqlite v3.1.5
- Microsoft.EntityFrameworkCore.SqlServer v3.1.5
- Microsoft.EntityFrameworkCore.Tools v3.1.5
- Microsoft.VisualStudio.Web.CodeGeneration.Design v3.1.3

## 5. How to Run the App

### 5.1. Using Docker
1. Install Docker.
2. Clone or download the repository.
3. Open a terminal and navigate to the repository folder.
4. Run: `docker build -t todowebapp:v1 .`
5. Run: `docker run -it --rm -p 5000:5000 todowebapp:v1`

### 5.2. Using .NET Core SDK
1. Install .NET Core SDK v3.1.301 or later.
2. Clone or download the repository.
3. Open a terminal and navigate to the repository folder.
4. Run: `dotnet restore`
5. Navigate to the `Server` folder.
6. Run: `dotnet run`

### 5.3. Testing and Stopping
1. Open your browser and go to: `http://localhost:5000`
2. Register a user, log in, and manage TODO items.
3. Press `Ctrl+C` in the terminal to stop the server.

## 6. Limitations

### 6.1. Error Handling
The app lacks extensive error handling and response values. Known issues may arise with incorrect input.

## 7. Future Enhancements
- Add first name and last name fields
- Customize Identity UI
- Implement Facebook sign-in (Maybe not, it seems complicated)
- Add roles (admin, user)
- Implement automated unit and integration tests

## 8. Resources
The app uses code from my TODOtNET_API and TODOtNET_APP projects. For more details, check the resources listed in their README files:

- [ASP.NET MVC Tutorial](https://asp.mvc-tutorial.com/)
- [ASP.NET Core MVC Tutorial](https://docs.microsoft.com/en-us/aspnet/core/tutorials/first-mvc-app/?view=aspnetcore-3.1)
