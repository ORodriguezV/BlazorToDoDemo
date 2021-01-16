# Blazor To-Do Demo
This is a Blazor (ASP.NET 5.0) demo application to showcase some best practices.

Some features:
- The data access layer of the backend uses Dapper for improved performance over Entity Framework.
- The http interaction from the WebAssembly to the server uses a http wrapper to facilitate error handling.
- All repositories use interfaces and dependency injection to facilitate unit testing.
- DRY: Reusability of razor components, including the create and update form.
- Form validation using Data Annotations.
