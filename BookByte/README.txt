An ASP.NET Core MVC-based eCommerce Book Store application that allows users to browse,
search, and purchase books online. It features user authentication, product management,
shopping cart functionality, and secure checkout integration

This ASP.NET Core MVC eCommerce Book Store project is built with a clean, layered architecture,
following best practices for scalability and maintainability. It includes separate layers for Presentation,
Business Logic, Data Access, and Models, ensuring clear separation of concerns and ease of future development

  1 This project includes additional sub-projects to maintain a clean architecture and separation of concerns
      
      This project includes a well-defined CI/CD pipeline to automate build, test, and deployment processes.
      It ensures code quality,streamlines integration,
      and supports continuous delivery for faster and more reliable releases

      2 This project utilizes compiled classes to enhance performance and maintain a clean separation between logic and presentation.
      By precompiling reusable components, the application achieves faster execution and better modularity

      3 Also, add the compiled class for DataAccess.  

      4 Add the compiled Utility class to the common codebase

      5 I deleted the default Class1 that was created when the project was added.
        Then, I moved the Models folder from the main project directory into the BookByte.Models folder and updated the namespace accordingly

      6 It's important to clean and build the main project. It may throw an error because it references another project.
        To resolve this, right-click the main project and add the necessary project reference.

      7 Same change for the view Shared error file change the namespace to BookByte.Models
     
      8  Follow the same process for the DataAccess project: cut the Data folder from the main project, paste it into the DataAccess project,
        update the namespace accordingly, and install the required packages.


2   After that change the default connection string in the appsettings.json file then go to the program.cs file and update the constring string 
    and same change the database name into the appsettings.json file.


3 Create the Area into main project for the Customer and it`s name is customer then delete the data folder , model folder, then Cut the HomeController from
  the Main Project`s Home controller and paste it into the Customer Area controller folder. 

  1 after this process then delete the controller folder form the outer main project
  2 remeber the when use the Area Controller the you should use the [Area("Customer")] above the controller class")]
  3 same as the view cut from main project then it paste into Area`s Customer view
  4 like this add  pattern: "{area=Customer}/{controller=Home}/{action=Index}/{id?}");  into program.cs file that will works the project
  5 after that run the project it will works fine. but then it show the layout becasue we need copy the files view`s ViewImports.cshtml and ViewStart.cshtml from main project to Area`s Customer View folder   


  4 Same for Create the Admin Area into main project for the Admin and it`s name is Admin then delete the data folder , model folder, then Cut the HomeController from
    the Main Project`s Home controller and paste it into the Admin Area controller folder. 
    1 after this process then delete the controller folder form the outer main project
    2 remeber the when use the Area Controller the you should use the [Area("Admin")] above the controller class")]
    3 same as the view cut from main project then it paste into Area`s Admin view
    4 like this add  pattern: "{area=Admin}/{controller=Home}/{action=Index}/{id?}");  into program.cs file that will works the project
    5 after that run the project it will works fine. but then it show the layout becasue we need copy the files view`s ViewImports.cshtml and ViewStart.cshtml from main project to Area`s Admin View folder


    5 After this work`s works done then go to Nugetpage Console then select the project where we add the migration for the Identity frameWork remaber 
    Two basic class`s       add-migration intiLoad
                            update-database    


   6 So another project install here runtimeCompilation package that will help to update the changes without rebuild the project
      Install-Package Microsoft.AspNetCore.Mvc.Razor.RuntimeCompilation 
      1 the add into the program.cs file builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation(); // Enable runtime compilation for Razor views
   
   7 Now add the Theme for layout  go to website   https://bootswatch.com/yeti/  then copy the bootstap.css  then go to project 
     directory wwwroot/lib/dist/css/bootstap.css  then paste here which copy the code 

     after that go to layout then  <link rel="stylesheet" href="~/lib/bootstrap/dist/css/bootstrap.css" /> show the  in last before the css remove the min.
     then run the project 

   8 Now Create Models into the Models project 
      2 Category.cs
      3 CoverType.cs
      then go to DataAccess project create the folder name is ApplicationDbContext.cs remember don't forget add the reference the Models project into DataAccess project
      then create the DBsets for the Category and CoverType
     

     9 After this work create the migration for the Models project that we create just now
       add-migration addCategoryAndCoverType -Project BookByte.DataAccess -StartupProject BookByte
       update-database -Project BookByte.DataAccess -StartupProject BookByte

    10  This project implements the Generic Repository pattern to promote code reusability and separation of concerns in data access. By abstracting common CRUD operations into a generic base class, we reduce duplication and simplify interaction with the Entity Framework.
        Each entity type can be managed through a shared interface, making the codebase cleaner and easier to maintain
        
        1 Go to DataAccess project create the folder name is Repository then inside add the IRepository 