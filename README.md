# ASP.NET Core MVC Project with Entity Framework

This is a sample ASP.NET Core MVC project using Entity Framework for database connectivity.

## Prerequisites

- [.NET 6 SDK](https://dotnet.microsoft.com/download/dotnet/6.0)
- [Visual Studio](https://visualstudio.microsoft.com/downloads/) or [Visual Studio Code](https://code.visualstudio.com/download)

## Getting Started

1. **Clone the Repository**

   ```git clone
   https://github.com/Fahim2280/ASP.NET-INTERNSHIP
   ```

2. **Install Dependencies**  

  ```bash
  dotnet restore 
  ```
3. **Database Configuration**
- Create a database in your preferred SQL Server.

- Update the connection string in appsettings.json:
     ```json
     "ConnectionStrings": {
      "DefaultConnection": "Server=<server>;Database=<database>;User   
      Id=<username>;Password=<password>;"           
      }
     ```
4. **Apply Migrations**     
   
   ```bash
   dotnet ef database update
   ```
# Project Structure
- Models: Contains the entity models (Student.cs, Class.cs).
- Data: Contains the ApplicationDbContext.cs for database context setup.
- Controllers: Contains the controllers (StudentController.cs, ClassController.cs).
- Views: Contains the views for the respective controllers.

## Adding New Student
- Click the "Add New Student Info" button.
- Fill in the required information in the form (Name, Class, DOB, Gender).
- Click "Submit" to add the new student.

## Editing Student Information
- Click the "Edit" button next to the student you want to edit.
- Modify the information in the form.
- Click "Submit" to save the changes.

## Viewing Student Details
- Click the "Details" button next to the student you want to view.

## Deleting Student
- Click the "Delete" button next to the student you want to delete.
- Confirm the deletion.

## Class Table
- Data for the Class table should be added manually.

## Database Schema
- Please find the database schema in the schema.txt file.

## Additional Notes
Link to Additional Documentation or Wiki
