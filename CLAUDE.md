# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## Project Overview

BnB is a bed & breakfast reservation and property management system for Hawaii's Best Bed & Breakfasts (HBBB). The project contains both a legacy VB5 application (reference only) and an active .NET 8 WinForms modernization.

**Active development is in the `src/` directory** - the modern C#/.NET 8 application.

## Build Commands

```powershell
# Build solution
dotnet build src/BnB.sln

# Run tests
dotnet test src/BnB.Tests/BnB.Tests.csproj

# Run the application
dotnet run --project src/BnB.WinForms/BnB.WinForms.csproj

# Build and publish (self-contained single-file exe)
.\build.ps1 -Publish

# Clean build
.\build.ps1 -Clean -Publish
```

### EF Core Migrations

```powershell
# Add a new migration
dotnet ef migrations add MigrationName --project src/BnB.Data --startup-project src/BnB.WinForms

# Update database
dotnet ef database update --project src/BnB.Data --startup-project src/BnB.WinForms
```

## Technology Stack

- **Language:** C# / .NET 8.0-windows (LTS)
- **UI Framework:** WinForms (MDI application)
- **Data Access:** Entity Framework Core 8.0
- **Database:** SQLite (default) or PostgreSQL
- **Reporting:** QuestPDF
- **Charting:** ScottPlot.WinForms
- **Platform:** x86 (32-bit), Windows 10+

## Directory Structure

```
src/                      # Modern .NET 8 application (ACTIVE)
├── BnB.sln              # Solution file
├── BnB.Core/            # Domain models (Guest, Property, Accommodation, etc.)
├── BnB.Data/            # EF Core DbContext and migrations
├── BnB.WinForms/        # UI layer - Forms, Controls, Reports
│   └── Forms/           # All form implementations
└── BnB.Tests/           # Unit tests

BNBCode/                 # Legacy VB5 source (REFERENCE ONLY)
BNB1_MDB/                # Original Access database files
Reports/                 # Legacy Crystal Reports (.rpt files)
tools/                   # Data migration utilities
installer/               # Inno Setup installer configuration
```

## Architecture

### Solution Projects

| Project | Purpose |
|---------|---------|
| BnB.Core | Domain models, enums (FormMode), business entities |
| BnB.Data | BnBDbContext, EF Core configuration, migrations |
| BnB.WinForms | UI forms, controls, PDF reports, application entry point |
| BnB.Tests | Unit tests |

### Key Domain Models (BnB.Core/Models/)

- **Guest** - Guest records with auto-increment Id, links to Accommodations and Payments
- **Property** - Host properties with AccountNumber as PK, commission rates, payment policies
- **Accommodation** - Bookings linking Guest to Property with dates, rates, taxes
- **Payment** - Payment records linked to Guest
- **RoomType/RoomBlackout** - Room availability management
- **TaxRate/TaxPlan** - Tax configuration
- **Check/CheckNumberConfig** - Check printing functionality

### Form Mode System

Forms use a mode-based state pattern defined in `BnB.Core/FormMode.cs`:
```csharp
public enum FormMode { Browse, Insert, Update, Delete, Find, NoRows }
```

The mode controls which UI elements are enabled and how data binding behaves.

### Data Access (BnB.Data/)

`BnBDbContext` configures all entity relationships with Fluent API:
- Guest → Accommodations (1:many via GuestId)
- Guest → Payments (1:many via GuestId)
- Property → Accommodations (1:many via PropertyAccountNumber)
- Property → RoomTypes (1:many)
- RoomType → RoomBlackouts (1:many)

### Database Configuration

Default SQLite database location: `%LOCALAPPDATA%\BnB\bnb.db`

Configure in `appsettings.json` for PostgreSQL:
```json
{
  "Database": {
    "Provider": "PostgreSQL",
    "PostgreSQL": { "Host": "localhost", "Database": "bnb", ... }
  }
}
```

## Key Forms (src/BnB.WinForms/Forms/)

| Form | Purpose |
|------|---------|
| MainForm | MDI container, menu system |
| GuestForm | Guest management |
| AccommodationForm | Booking/reservation management |
| PaymentForm, RecordPaymentForm | Payment processing |
| PropertyForm | Host/property management |
| AvailabilityForm | Year-at-a-glance room calendar |
| BookingListForm | Booking search and listing |
| CheckPrintForm, CheckEditForm | Check printing |

## Legacy VB5 Reference (BNBCode/)

The `BNBCode/` directory contains the original VB5 application for reference when implementing features:

| Module | Purpose |
|--------|---------|
| BNB1.BAS | Global functions (CurrencyToText, tax calculations) |
| BNBMODE.BAS | Original form mode management |
| *.FRM files | Original form layouts and logic |

## Installer

Build installer using Inno Setup:
1. Run `.\build.ps1 -Publish`
2. Open `installer/BnB.iss` in Inno Setup Compiler
3. Compile to create `installer/output/BnB_Setup.exe`
