# CPW219eCommerceSite

## Description
This repo is a class example to get practice with EntityFramework Core. It is a basic eCommerce website for selling video games. 

## Getting started

### Requirements:
- Visual Studio 2022
- VS should be configured with ASP.NET Web Devolopement
- .NET 8

### Cloning the repo
After you make sure you have the nessecary software installed, you cna then clone the repo. [Here is a tutorial for cloning gitHub repositories.](https://learn.microsoft.com/en-us/visualstudio/version-control/git-clone-repository?view=vs-2022)

### Packages
To use this repo you will need to download the required packages at the least and it is recommended you also download the optional packages. To download these packages, you can right click on you project in the solution manager inside Visual Studio. Click on the "Manage NuGet Packages..." option. Make sure you are in the browse tab and search for these packages. 

You can also add them through the Package Manager Console by copying the command on each of their respective pages into the console and executing the command. 

### Required: 
- [Microsoft.EntityFrameworkCore.SQLServer](https://www.nuget.org/packages/Microsoft.EntityFrameworkCore.SqlServer/8.0.7?_src=template) Note: This is the version for Microsoft SQL Server. If you are using a different database engine, you will need to find the appropriate package.
- [Microsoft.EntityFrameworkCore.Tools](https://www.nuget.org/packages/Microsoft.EntityFrameworkCore.Tools/8.0.7?_src=template) This package allows you to use certain commands to update (or otherwise interact with) the databse.

### Optional:
- [Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore](https://www.nuget.org/packages/Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore/8.0.7?_src=template) This is a helper package that gives better error messages for EF Core migrations.
