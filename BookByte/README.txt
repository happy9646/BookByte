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