Topics Covered 
---------------------------------------------
Fundamentals of asp.net core
Entity Framework & Repository Pattern
MVC Application
Client and Server Validations
Viewbag, ViewData and TempData
DataTable/Toastr/FileUploads/RichTextEditor
Razor Pages
Error Solving

.Net Core RoadMap
-------------------------------------------------------------
web forms-> .Net MVC

Advantages
--------------------
Fast and Open source
Cross Platform
Built in Dependency Injection
Easy Updates
Cloud Friendly
Performance

Tools Needed
---------------------------------------
.Net 7 or 8
Visual Studio 2022
SSMS 2018
SQl Server

How to Upload your Project to Github?
-------------------------------------------
Add to Source Control -> Select Github and give the details and Add your Project to Github

To look into the Project File
--------------------------------
you have to right click on project -> Edit Project File
we can see which framework we are using for the project

Properties
-----------------------------
launchSettings.Json
This will defines when we are running or debugging we can use these url for IIS,http, https
Enivronemnt Variables = Development and it's a global variable

WWWroot
---------------------------------------
it contains Static content 
like css , javascript and images and pdf and powerpoint presentation
doesn't have HTML code

AppSettings.Json
----------------------------
where you will host connect string or any secret key for your Application
when you have database connection
when your are using azure blob storage , all connection string will be store here.

In Appsettings File if we add Appsettings.Production.Json
---------------------------------------------------------
the launchsettings.json file from Properties will use the production.sjon from appsettigs when we set environment variable as Production.

Program.cs
-------------------------------------
Add Services to the Container
COnfigure the request Pipeline

Pipeline means
-----------------------------
Basically when a request come to an Application how do you want to process that.
Development environmen variable is there 

when we have to add package to our Project
-----------------------------------------------------
right click on project and go to manage nuget package and install the packages
In this Project, I used 
Microsoft.EntityFrameworkcore preview version 8.0.3
Microsoft.EntityFrameworkCore.SqlServer preview version for the database 
Microsoft.EntityFrameworkcore.Tools => this will help for the migration

when you added the nuget packages to the project, it will add to the project file Immediately and you can see it in project file.

COnnectionString to add database to appsettings.Json
-------------------------------------------------------------
"ConnectonStrings":
{
"DefaultConnection": " Server:Koteswararao;Database=Bulky;Trusted_Connection=True;TrustServerCertificate=True"
}

To Establish connection between EntityFramewrok and Database 
------------------------------------------------------------------
we are adding Data Folder and creating class file ApplicationDbContext.
DbContext class: basically the root class of entityframework to use the entityframework- builtin class

how to pass connectionstring that we have inside appsettingsJson to DbContext
---------------------------------------------------------------------------------------
Constructor

Public ApplicationDbContext(DbContextOptions<ApplicationDbContext> Options):Base(Options)
{}

We have to register the APplicationDbContext in Program.cs file
how to register?
--------------------------------------------------------------------------------
builder.Services.AddDbContext<ApplicationDbContext>(options=>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));



 
