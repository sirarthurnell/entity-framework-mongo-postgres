# Example of interchangeable data layer between MongoDB and PostgreSQL

Created with love and dotnet version 2.2.

The PostgreSQL uses Entity Framework Core to access the database, while MongoDB uses its own driver only. There's a proyect that constitutes the common data abstraction layer. Then, there's one project for PostgreSQL and other for MongoDB that implement that abstraction layer.

There's a frontend too created with Angular.

In order to run the example, you need to have both, MongoDB and PostgreSQL installed. After that, execute ```dotnet restore```, and apply the initial migration included for the PostgreSQL part.