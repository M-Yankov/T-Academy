# Company
Ready to use ASP.NET Web Api

1. Database
   - Uses a `Unit of Work` and `Repository pattern` (Generic repository).
   - Migrations Enabled.
   - Separate project for models.
      - includes a default User from ASP.NET 
   - Entity Framework (Code First).
2. WebApi
   - Cleared MVC files.
   - Refactored classes in separate files, ready structure, configuration - Automapper, Ninject and database initialization.
   - Uses Ninject Web Api Host, AutoMapper.
   - WCF Client
      - Configured Ninject.Extensions.Wcf.
      - Example `UsersService`.
3. Service
   - Use `Contracts` folder to create interfaces and implement it with class, Ninject will bind it automatically if they are named like: `IProductService` and `ProductService : IProductService`.
4. Todo's notes and comments. Search in your IDE for 'Todo:'
