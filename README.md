# HMSAPP (Hospital Management System Application)

Welcome to **HMSAPP**! This is a lightweight, educational .NET 8 Web API project designed to explore and implement **Onion Architecture** (Clean Architecture) principles alongside a decoupled **Vanilla Frontend** UI. It serves as a solid foundation for building decoupled, testable, and maintainable enterprise applications.

---

## 🧅 Architecture Overview

The project is structured around the **Onion Architecture** paradigm, where dependencies flow inward. The core business logic is completely isolated from external frameworks, databases, and UI concerns.

| Layer Category | Project Name / Directory | Description |
| :--- | :--- | :--- |
| **Core** | `HMSAPP.Domainn` | Contains domain entities (`Doctor`), enterprise business rules, and repository interfaces. |
| **Core** | `HMSAPP.Contract` | Defines abstractions, interfaces, and Data Transfer Objects (DTOs) for external communication. |
| **Core** | `HMSAPP.Application` | Implements application use cases, services (`DoctorService`), and AutoMapper profiles. |
| **Infrastructure**| `HMSAPP.Persistance` | Handles data access, EF Core `DbContext` (`HSDbContext`), Fluent API configurations, and the `GenericRepository` implementation. |
| **Infrastructure**| `HMSAPP.Infrasturuture`| Dedicated for third-party integrations, file storage, or external infrastructure tools. |
| **Presentation**  | `HMSAPP.WebAPI` | The API entry point. Contains controllers (`DoctorsController`), middleware, configuration files, and Serilog setups. |
| **Frontend**      | `client/` | Lightweight, dependency-free UI built with HTML5, Custom CSS3, and JavaScript (`fetch` API). |

---

## 🚀 Key Features

* **Domain-Centric Design:** Business entities are clean and decoupled from data-access technologies.
* **Generic Repository Pattern:** A reusable data-access abstraction layer handling basic CRUD operations smoothly.
* **Fluent API Configurations:** Database constraints (lengths, uniqueness, indexes) are completely isolated inside `DoctorConfiguration` instead of cluttering the domain models with attributes.
* **Object Mapping:** Automated conversion between Entities and DTOs using **AutoMapper** via a `CustomProfile`.
* **Robust Logging:** Powered by **Serilog**, configured to write structured logs simultaneously to both the **Console** and automated rolling **Daily Text Files** (`Logs/log-*.txt`).
* **Lightweight Vanilla UI:** Pure HTML5, custom CSS layout (Flexbox/Grid), and modular Vanilla JS for asynchronous API communication using `async/await` and `fetch`.
* **Modular Code Structure:** Full separation of concerns on the client side with standalone HTML pages, CSS files, and page-specific JS modules (`index.js`, `create.js`, `edit.js`, `delete.js`).

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
├── presentation/
│   └── HMSAPP.WebAPI/           # Controllers, Serilog Configurations, App Settings
│
└── client/                      # Vanilla Frontend
    ├── css/
    │   └── style.css            # Custom CSS styles
    ├── javascripts/
    │   ├── index.js             # List fetching & dynamic table render
    │   ├── create.js            # Add new doctor form handler
    │   ├── edit.js              # Update doctor form handler
    │   └── delete.js            # Delete confirmation handler
    ├── index.html               # Doctors list dashboard
    ├── create.html              # Doctor registration form
    ├── edit.html                # Doctor modification page
    └── delete.html              # Delete confirmation page
```
## 🚀 Getting Started & Setup

### Prerequisites

- .NET 8 SDK
- SQL Server (LocalDB or Express)
- Live Server (VS Code extension) or any static web server for running the frontend.

### Database Configuration

Update the connection string inside `presentation/HMSAPP.WebAPI/appsettings.json`:

```json
{
  "ConnectionStrings": {
    "DefaultConnectionString": "Server=YOUR_SERVER;Database=HMSDb;Trusted_Connection=True;"
  }
}
```

### Running Database Migrations

Open your Package Manager Console in Visual Studio, set `HMSAPP.Persistance` as the Default Project, and run:

```bash
Add-Migration InitialCreate -Project HMSAPP.Persistance -StartupProject HMSAPP.WebAPI
Update-Database -Project HMSAPP.Persistance -StartupProject HMSAPP.WebAPI
```

### Running the Application

1. **Start the Web API:**
   Run the `HMSAPP.WebAPI` project. Ensure the API is running on `https://localhost:7223` (or update `client_url` inside the JS files under `client/javascripts/` if using a different port).

2. **Launch the Frontend:**
   Open `client/index.html` using Live Server in Visual Studio Code or directly via browser.

## 📝 Logging with Serilog

Structured logging is fully initialized in `Program.cs`.

- **Console Tracking:** Real-time debugging in the console container.
- **Rolling File Logs:** Saved under `presentation/HMSAPP.WebAPI/Logs/`. A new text file is automatically generated every day (e.g., `log-20260718.txt`) to keep track of system errors and actions without data loss.

## 🤝 Contributing

Since this is a showcase and sandbox learning project, feel free to fork it, experiment with adding new entities, or test out alternative micro-ORMs like Dapper in the persistence layer!
