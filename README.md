# DocBook

DocBook is a test application for scheduling appointments with a doctor.

## Architecture

The project is implemented using a layered architecture:
- **DocBook.Core**: Contains the core business logic and domain models. This represents the Business Logic Layer.
- **DocBook.Data**: Handles data access, interacting with databases. This is part of the Data Access Layer.
- **DocBook.WebAPI**: Responsible for handling HTTP requests, routing, and exposing APIs. This serves as the Presentation Layer or Service Layer.

## Tech Stack
- ASP.NET Core Web API (.NET 8)
- Entity Framework Core
- Serilog
- Swagger
- MSTest

## Prerequisites
- MSSQL Server
- .NET 8.0

## Instructions for Running the Application
1. Use the "http" launch setting to run the project.
2. Set **DocBook.WebAPI** as the startup project.
3. To create the **DocBookDb** for the application:
   - Modify the connection string in `appsettings.json` to connect to your MSSQL server.
   - In the Package Manager Console, select **DocBook.Data** as the default project, then run the command `Update-Database` to initialize the database with seed data.

The app will be available at `http://localhost:5000/swagger/index.html` by default.

## Postman Collection
I have added scripts to the Postman collection methods for convenient interaction with the API endpoints.
