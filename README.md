# HMSAPP (Hospital Management System Application)

Welcome to **HMSAPP**! This is a lightweight, educational .NET 8 Web API project designed to explore and implement **Onion Architecture** (Clean Architecture) principles. It serves as a solid foundation for building decoupled, testable, and maintainable enterprise applications.

---
 
## 🧅 Architecture Overview

The project is structured around the **Onion Architecture** paradigm, where dependencies flow inward. The core business logic is completely isolated from external frameworks, databases, and UI concerns.

| Layer Category | Project Name | Description |
| :--- | :--- | :--- |
| **Core** | `HMSAPP.Domainn` | Contains domain entities (`Doctor`), enterprise business rules, and repository interfaces. |
| **Core** | `HMSAPP.Contract` | Defines abstractions, interfaces, and Data Transfer Objects (DTOs) for external communication. |
| **Core** | `HMSAPP.Application` | Implements application use cases, services (`DoctorService`), and AutoMapper profiles. |
| **Infrastructure**| `HMSAPP.Persistance` | Handles data access, EF Core `DbContext` (`HSDbContext`), Fluent API configurations, and the `GenericRepository` implementation. |
| **Infrastructure**| `HMSAPP.Infrasturuture`| Dedicated for third-party integrations, file storage, or external infrastructure tools. |
| **Presentation**  | `HMSAPP.WebAPI` | The entry point of the application. Contains controllers (`DoctorsController`), middleware, configuration files, and logging setups. |

---

## 🚀 Key Features

*   **Domain-Centric Design:** Business entities are clean and decoupled from data-access technologies.
*   **Generic Repository Pattern:** A reusable data-access abstraction layer handling basic CRUD operations smoothly.
*   **Fluent API Configurations:** Database constraints (lengths, uniqueness, indexes) are completely isolated inside `DoctorConfiguration` instead of cluttering the domain models with attributes.
*   **Object Mapping:** Automated conversion between Entities and DTOs using **AutoMapper** via a `CustomProfile`.
*   **Robust Logging:** Powered by **Serilog**, configured to write structured logs simultaneously to both the **Console** and automated rolling **Daily Text Files** (`Logs/log-*.txt`).

---

## 📁 Project Structure Tree

Based on the solution architecture:

```text
HMSAPP/
│
├── core/
│   ├── HMSAPP.Domainn/          # Entities (Doctor), Repository Interfaces
│   ├── HMSAPP.Contract/         # Abstractions, DTOs
│   └── HMSAPP.Application/      # Services (DoctorService), Mapper Profiles
│
├── infrasturuture/
│   ├── HMSAPP.Infrasturuture/   # Infrastructure services
│   └── HMSAPP.Persistance/      # DB Context, GenericRepository, Fluent Configurations
│
└── presentation/
    └── HMSAPP.WebAPI/           # Controllers, Serilog Configurations, App Settings
```
🛠️ Getting Started & Setup
Prerequisites
.NET 8 SDK

SQL Server (LocalDB or Express)

Database Configuration
Update the connection string inside presentation/HMSAPP.WebAPI/appsettings.json:

```
{
  "ConnectionStrings": {
    "DefaultConnectionString": "Server=YOUR_SERVER;Database=HMSDb;Trusted_Connection=True;TrustServerCertificate=True;"
  }
}
```
Running Database Migrations
Open your Package Manager Console in Visual Studio, set HMSAPP.Persistance as the Default Project, and run:
```
Add-Migration InitialCreate -Project HMSAPP.Persistance -StartupProject HMSAPP.WebAPI
Update-Database -Project HMSAPP.Persistance -StartupProject HMSAPP.WebAPI
```
📝 Logging with Serilog
Structured logging is fully initialized in Program.cs.

Console Tracking: Real-time debugging in the console container.

Rolling File Logs: Saved under presentation/HMSAPP.WebAPI/Logs/. A new text file is automatically generated every day (e.g., log-20260718.txt) to keep track of system errors and actions without data loss.

🤝 Contributing
Since this is a showcase and sandbox learning project, feel free to fork it, experiment with adding new entities, or test out alternative micro-ORMs like Dapper in the persistence layer!
```
