Vehicle Service Booking System

A 3-Layer Architecture Windows Forms C# application integrated with SQL Server to manage vehicle workshop service bookings.

🚀 Features

Add Booking: Create new customer service bookings.

Update Booking: Modify existing booking details.

Delete Booking: Remove service bookings from the system.

View All: Fetch and list all active bookings from SQL Server in a DataGridView.

Data Validation: Prevents empty inputs, invalid costs, and past booking dates.

🏗️ Architecture

This project follows a 3-Layer Architecture pattern:

Presentation Layer (Presentation): Form1.cs — Handles UI inputs and events.

Business Logic Layer (BusinessLogic): ServiceBooking.cs & Validation.cs — Defines data structures and business validation rules.

Data Access Layer (DataAccess): DataHandler.cs — Manages SQL database connection and executes CRUD operations.

🛠️ Prerequisites & Setup

Database Setup:

Open SQL Server Management Studio (SSMS).

Run the provided SQL script to build WorkshopDB and the ServiceBookings table.

Configuration:

Update the connection string in DataHandler.cs with your local SQL Server name if necessary (default: WIN-D9ID2HMIDFR\SQLEXPRESS01).

Run Application:

Open VehicleServiceBookingSystem.sln in Visual Studio 2022 and click Start.
