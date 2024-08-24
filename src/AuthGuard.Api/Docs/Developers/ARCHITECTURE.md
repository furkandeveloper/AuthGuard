# Architecture

## Contexts
All database contexes are placed here.


***
## Controllers
All AspNet Controllers are placed here. They are seperated by version. Versionning rule is `v{ver}`, as sample `v1`, `v2` or `v3`...

***
## Dtos

This folder includes all Data Transfer Objects and they're seperated by **Request**, **Response** and **Service** folders.

***
## Exceptions
This folder contains custom exceptions which is inherited from BaseException. BaseException is handled by Middleware and returns a status code from exception. Exceptions can be thrwon in anywhere like Repository.

***
## Helpers
This folder includes helper codes and extensions which is undependent from any context. They are generic helper codes.

***
## Interfacfes
This fodler includes all interfaces in project.

***
## Mappings
This folder contains AutoMapper **Profile** objects. They define mappings between Dtos and Models. Also  this mappings is used for Projection to database queries.

***
## Middleware
This folder contains middleware processes like, Authentication, Authorization and Exception Handling. Also ActionFilters are here too.

***
## Entities
All the database models are here. Also They're foldered by database provider like **EntityFramework**.

***
## Repositories
All repositories with database query are here. Only this repository objects can reach database data! You can not use DbContext except repository. If you need reach database for custom reason, just create a repository to do that and resolve that repository from Dependency Injection Container.

***
## Services
Normally this layer must be a logic layer. But in this project and this version, it has only services which don't touch database and external api integrations.
***
## Validations
This folder includes model validations. You mustn't use if for check any of property in codebase! **All validations must be placed here instead of inline `if`**. These validations are provided by FluentValidation.

***
# Dependencies

| Library                                                                                                | Description                                                                           | Version |
|--------------------------------------------------------------------------------------------------------|---------------------------------------------------------------------------------------|:-------:|
| [AspNetCore.MarkdownDocumenting](https://github.com/enisn/MarkdownDocumenting)                         | This project provides markdown documentation for your .net core projects automaticly. | v2.3.1  |
| [EasyWeb.AspNetCore](https://github.com/furkandeveloper/EasyWeb)                                       | Easy Web it combines models common to every web application into a single solution.   | v1.0.2  |
| [EasyWeb.AspNetCore.Filters](https://github.com/furkandeveloper/EasyWeb)                               | Easy Web it combines models common to every web application into a single solution.   | v1.0.2  |
| [EasyWeb.AspNetCore.Standarts](https://github.com/furkandeveloper/EasyWeb)                             | Easy Web it combines models common to every web application into a single solution.   | v1.0.2  |
| [EasyWeb.AspNetCore.Swagger](https://github.com/furkandeveloper/EasyWeb)                               | Easy Web it combines models common to every web application into a single solution.   | v1.0.2  |
| [FluentValidation](https://github.com/FluentValidation/FluentValidation)                               | A popular .NET validation library for building strongly-typed validation rules.       | v11.0.1 |
| [FluentValidation.AspNetCore](https://github.com/FluentValidation/FluentValidation)                    | A popular .NET validation library for building strongly-typed validation rules.       | v11.0.1 |
| [FluentValidation.DependencyInjectionExtensions](https://github.com/FluentValidation/FluentValidation) | A popular .NET validation library for building strongly-typed validation rules.       | v11.0.1 |
| [Microsoft.AspNetCore.Mvc.NewtonsoftJson](https://github.com/dotnet/aspnetcore)                        | Newtonsoft for AspNetCore                                                             | v6.0.5  |
| [AutoMapper](https://github.com/AutoMapper/AutoMapper)                                                 | A convention-based object-object mapper in .NET.                                      | v12.0.1 |



