# Library Book Lending System

## 1. Project Overview

The Library Book Lending System is a web-based application developed to manage library book records, members, book reservations, borrowing, returns, and other library services.

The system provides an HTML and JavaScript frontend that consumes an ASP.NET Core REST Web API backed by a relational database. It implements authentication and role-based authorization to control access to library operations.

This project is developed as part of the requirements for Integrative Programming and Technologies I (IPT).

## 2. User Roles

### Librarian
The Librarian has administrative access to authorized library operations, including:

- Manage member accounts.
- Manage book records.
- Manage book reservations.
- Manage borrowing and return transactions.
- Monitor overdue borrowings.
- Manage seat reservations and reading-space reservations.
- Monitor QCPL external reservations.
- Access reports and summaries.

### Member
Members can:

- Register and log in.
- View available book records.
- Submit book reservations.
- View their own reservation and borrowing records.
- Use member-authorized library services.

Access to restricted operations is enforced by the API.

## 3. Features

- User registration and login.
- JWT authentication.
- Role-based authorization.
- Member management.
- Book records management.
- Book reservation management.
- Borrowing and return management.
- Borrowing status workflow.
- Overdue tracking.
- Seat management and seat reservations.
- Reading-space management and reservations.
- QCPL external reservation monitoring.
- Reports and summary endpoints.

## 4. Technologies

- C#
- ASP.NET Core Web API
- Entity Framework Core
- SQL Server / SQL Server LocalDB
- HTML
- CSS
- JavaScript
- Fetch API
- JWT Bearer Authentication

## 5. Prerequisites

Before running the project, install:

- Visual Studio 2022
- .NET 8 SDK
- SQL Server LocalDB
- Git

## 6. Installation

1. Clone the repository.
2. Open the project or solution in Visual Studio 2022.
3. Restore the NuGet packages.
4. Configure the database connection string.
5. Configure the JWT signing key using Visual Studio User Secrets.

   To configure the JWT key:

   - Right-click the API project in Solution Explorer.
   - Select **Manage User Secrets**.
   - Add the following configuration to `secrets.json`:

   ```json
   {
     "Jwt": {
       "Key": "YOUR_LOCAL_SECRET_KEY_HERE"
     }
   }
   ```

   Generate your own secret key of at least 32 characters. Do not commit your actual JWT key to GitHub.

6. Apply the database migrations.
7. Build the project.
8. Run the application.
## 7. Database Setup

The application uses Entity Framework Core with SQL Server or SQL Server LocalDB.

Open the Package Manager Console in Visual Studio and execute:

```powershell
Update-Database
```

To create a new migration after coordinated model changes:

```powershell
Add-Migration MigrationName
Update-Database
```

Database migrations should be coordinated with the other contributor before integration.

## 8. Running the Application

1. Open the project in Visual Studio 2022.
2. Set the API project as the startup project.
3. Ensure the database configuration and JWT configuration are properly set.
4. Build the application.
5. Run the application.

The frontend is served through the application's `wwwroot` folder.

## 9. Frontend

The application uses HTML, CSS, and JavaScript.

The frontend communicates with the API using the Fetch API. Authentication tokens are used for protected API requests.

The interface provides role-appropriate functionality and displays server responses, validation messages, and operation feedback.

## 10. Swagger

Swagger is used to document and test the REST API endpoints.

Swagger URL:

`[Insert verified Swagger URL here]`

## 11. Test Accounts

Test accounts will be provided for each role to allow the evaluator to test the application.

|			Role		|		Email/Username		|	  Password		|
|			---			|			---				|		---			|
|		 Librarian		|  [librarian@library.com]  |   [Library123!]	|
|		   Member		|   [member@library.com]    |   [Library123!]	|

Only verified test credentials should be included in this section.

## 12. Project Structure

| Folder/File | Description |
|---|---|
| `Controllers/` | REST API controllers						|
| `Data/`		 | Database context and database seeding	|
| `DTOs/`		 | Data transfer objects					|
| `Models/`		 | Application models and enums				|
| `Migrations/`  | Entity Framework Core migrations			|
| `wwwroot/`	 | HTML, CSS, and JavaScript frontend		|
| `Program.cs`	 | Application configuration and middleware |

## 13. Authentication and Authorization

The system uses JWT Bearer Authentication.

Passwords are hashed using password hashing mechanisms. Protected endpoints require authentication and role authorization.

Unauthorized requests and requests from users without the required permissions are rejected by the API.

## 14. GitHub Collaboration

The project uses Git branches for development, integration, and version control.

Contributors work on their assigned branches and submit changes for integration through pull requests.

Contribution details are documented in `CONTRIBUTIONS.md`.

## 15. Contributors

- Kim
- Cy

## 16. Academic Purpose

This application is developed for academic purposes as part of the Integrative Programming and Technologies I course requirements.

