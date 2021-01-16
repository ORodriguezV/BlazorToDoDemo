# BlazorToDoDemo
Blazor demo application to showcase best practices.

Some features:
- The data access layer of the backend uses Dapper.
- The http interaction from the WebAssembly to the server uses a http wrapper to handle errors
- Repositories use interfaces and dependency injection to facilitate unit testing.
