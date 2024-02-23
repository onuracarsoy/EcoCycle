Project Technology: ASP.NET Core 8.0

Technologies Used:
- N-Tier Architecture
- Repository Design Pattern
- Dependency Injection
- FluentValidation
- X.PagedList
- Entity Framework Core
- Identity Core
- Code First (Migration) Approach
- Google Charts API

Packages Used:
- FluentValidation (V11.9.0)
- FluentValidation.AspNetCore (V11.0.3)
- FluentValidation.DependencyInjectionExtensions (V11.9.0)
- Microsoft.AspNetCore.Components.QuickGrid.EntityFrameworkAdapter (V8.0.1)
- Microsoft.AspNetCore.Identity.QuickGrid.EntityFrameworkCore (V8.0.1)
- Microsoft.EntityFrameworkCore (V8.0.1)
- Microsoft.EntityFrameworkCore.Design (V8.0.1)
- Microsoft.EntityFrameworkCore.SqlServer (V8.0.1)
- Microsoft.EntityFrameworkCore.Tools (V8.0.1)
- X.PagedList (V8.4.7)
- X.PagedList.Mvc.Bootstrap4 (V8.1.0)
- X.PagedList.Mvc.Core (V8.4.7)

Database Operations:
1. Open the ".sln" file in Microsoft Visual Studio (recommended version: 2022).
2. In the project layers, navigate to DataAccessLayer > Concrete > Context class and modify the Connection String for your SQL Server setup.
3. Open View > Other Windows > Package Manager Console.
4. Choose the DataAccess layer and execute the following commands sequentially:
   - enable-migrations
   - add-migration [migration_name]
   - update-database

By running these commands, you'll create the database, and the project is ready for deployment.