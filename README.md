# MovieReviewApp

This is a WebAPI built using .NET 6. It allows users to perform CRUD on definied models.

## Requirements

- .NET 6
- MSSQL

## Installation

1. Clone the repository: `git clone https://github.com/PWidla/MovieReviewApp.git`

2. In Package Manager Console apply migration to the database (database connection is definied in appsettings.json - "DefaultConnection" string): 
- Update-Database 

3. Run the application by clicking 
  ![image](https://user-images.githubusercontent.com/89644623/219941195-d99f7232-ca28-453e-8ccb-6127ee06ca80.png)

## User Guide

After running the application, users can access different actions - basic CRUD for every model + for instance GET action which returns directors with specified ownerId.
