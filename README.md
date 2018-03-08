# End-to-end TodoMVC Demo with PostgreSQL, .NET Core and Angular
This is an original TodoMVC demo (http://todomvc.com) adopted to PostgreSQL + .NET Core with EF/ASP.NET MVC as a backend.

The demo is based on the default ASP.NET Core + Angular project template in Visual Studio 2017. It supports simultaneous backend and frontend debugging.

Prerequisities:
1. You need to have PostgreSQL installed. Just download it from https://www.postgresql.org/download/ and install. No further configuration is required.
2. Open the solution in Visual Studio and wait for referenced NuGet and NPM packages to be restored. It may take a while. Once it's done you need to configure user secrets file (secrets.json). Right-click on the solution's node and select Manage User Secrets. This will open secrets.json file where you need to create a property "PostgresPwd" with a value set to your PostgreSQL isntance password. You can read more about user secrets at https://docs.microsoft.com/en-us/aspnet/core/security/app-secrets?tabs=visual-studio.
3. Open CMD console and go to your solution's folder. Then run "dotnet ef database update". This will create a database in PostgreSQL and set it up for the application.
4. You're all set. Just build the solution and run it from Visual Studio.
