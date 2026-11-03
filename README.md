# DVLD-System

Driving & Vehicle License Department management system built with C# WinForms and SQL Server, following a 3-layer architecture (UI / Business / Data).

## Features
- Manage people and users
- Local and international driving license applications
- Test appointments and results (vision, written, street)
- License issuing, renewal, replacement
- Detain and release licenses

## Requirements
- Visual Studio 2019 or newer
- SQL Server 2017 or newer

## Setup
1. Run `Database/database.sql` on your SQL Server.
2. If your server name is not `.` (e.g. SQL Express: `.\SQLEXPRESS`), edit it in `DataConnection.cs` (Data Layer).
3. Open the `.sln` in Visual Studio, then Build and Start.

## Demo login
- Username: `admin`
- Password: `admin123`

## Notes
All data in the database script is fake and for testing only.