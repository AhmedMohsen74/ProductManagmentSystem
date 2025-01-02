# Product Management System

This repository contains the implementation of a **Simple Product Management System** developed using the following tech stack:

## Technical Stack

### Backend:
- **Framework:** .NET 8 Web API
- **Approach:** Minimal API (with FluentValidation and organized endpoint groups)
- **ORM:** Entity Framework Core
- **Database:** SQL Server (Express/Developer Edition)

### Frontend:
- **Framework:** Angular 17 

## Features Implemented

### 1. Products List Page:
- **Data Display:** Products are displayed using PrimeNG Datatable.
- **Columns:** ID, Name, Description, Price, Created Date.
- **Search:** Implemented search functionality by product name.

### 2. Create Product Page:
- **Form Fields:**
  - Name: Required, max 100 characters.
  - Description: Required, max 500 characters.
  - Price: Required, must be a positive number.
- **Validation:** Implemented validation with error messages for invalid inputs.
- **Notifications:** Success notification upon successful creation.

### 3. Edit Product Page:
- **Pre-filled Form:** Displays existing product data for editing.
- **Validation:** Same as Create Product Page.
- **Notifications:** Success/Error notifications based on operation outcome.

### 4. Delete Product:
- **Confirmation Dialog:** Confirmation prompt before deletion.
- **Notifications:** Success/Error notifications upon completion.

### Bonus Features:
- **Loading Indicators:** Shown during API calls.
- **Error Handling:** API errors are displayed as user-friendly messages.
## Setup Instructions

### Prerequisites:
- **Backend:**
  - Install .NET 8 SDK.
  - Install SQL Server (Express/Developer Edition).
- **Frontend:**
  - Install Node.js (18.x or higher).
  - Install Angular CLI (v19).
- **Database:**
  - Ensure SQL Server is running.

### Backend Setup:
1. Download Project From repo
2. Restore NuGet packages:
   ```bash
   dotnet restore
   ```
3. Update the database connection string in `appsettings.json`.
4. Apply migrations to create the database:
   ```bash
   dotnet ef database update
   ```
5. Run the application:
   ```bash
   dotnet run
   ```
   The API will be available at `https://localhost:7253/api`.  ----You can change it according to your LocalHost.

### Frontend Setup:
1. Navigate to the frontend directory:
   ```bash
   cd Angular app
   ```
2. Install dependencies:
   ```bash
   npm install
   ```
3. Configure the backend API URL in `environment.ts`.
4. Start the Angular application:
   ```bash
   ng serve
   ```
   The application will be available at `http://localhost:4200`.

### Database Setup:
- A script to create the database is provided: `CreateDatabase.sql`. Run it in SQL Server Management Studio (SSMS) before starting the backend.
- Or Copy the .MDF and .LDF files to MicrosoftSqlServer Data here you are the path ==>  C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA

## Usage
1. Open the application in a browser at `http://localhost:4200`.
2. Navigate between the **Product**, **Category** pages.
3. Add, edit, and delete products with real-time updates.

## Testing the Application
- Test API endpoints using tools like Postman (available at `https://localhost:7253/api`). You can change it according to your LocalHost.

## Additional Notes
- Ensure the backend and database are running before starting the frontend.
- For debugging, logs are available in the console for both frontend and backend.

## Repository Details
- **GitHub URL:** https://github.com/AhmedMohsen74/ProductManagmentSystem
- **Email:** a.mohsen0033@gmail.com

---

Thank you for reviewing the project!

