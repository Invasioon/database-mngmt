
# Database Management Application

This repository contains an application for managing a database with CRUD operations. It is built using:
- **C#** for the GUI and primary SQL interactions.
- **Java** for additional processing, such as data exporting to CSV.

## Features
- Add, update, and delete items in the database.
- Export data to a CSV file using the Java component.

## Prerequisites
- .NET Framework or .NET Core
- JDK (Java Development Kit)
- Microsoft SQL Server or compatible database
- Ensure the database has a table named `Items` with columns:
  - `Id` (INT, Primary Key)
  - `Name` (VARCHAR)

## Usage
### C# Application
1. Update the connection string in the `MainForm` class.
2. Build and run the application.
3. Use the GUI for CRUD operations.

### Java Data Exporter
1. Update the JDBC connection string in the `DatabaseExporter` class.
2. Compile and run the Java program:
   ```bash
   javac DatabaseExporter.java
   java DatabaseExporter
   ```

## License
This project is licensed under the MIT License.
