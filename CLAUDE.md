# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## Project Overview

BnB is a bed & breakfast reservation and property management system built with Visual Basic 5.0. It's a Windows MDI (Multiple Document Interface) desktop application used by Hawaii's Best Bed & Breakfasts (HBBB) for managing guests, properties, reservations, payments, and commissions.

## Technology Stack

- **Language:** Visual Basic 5.0
- **Database:** Microsoft Access (Jet/DAO 2.5)
- **Reporting:** Crystal Reports 5.x (CRYSTL32.OCX)
- **UI Controls:** Sheridan Software data-bound grids (SSDATB32.OCX, SSDATA32.OCX)
- **Charting:** Graphs32.OCX
- **Runtime:** MSVBVM50.DLL (VB5 Runtime)

## Directory Structure

```
BNBCode/          # Main application source (bnb.vbp)
├── *.BAS         # 4 code modules (BNB1, BNBMODE, CONSTANT, WINAPI)
└── *.FRM         # 45 forms

BNB1_MDB/         # Database files
├── bnb1.mdb      # Production database (21 MB)
└── bnbNoDat.mdb  # Empty template database

InstCode/         # Setup/installation application (Setup1.vbp)
Distrib/          # Pre-built distribution with compressed dependencies
Reports/          # 27 Crystal Reports (.rpt files)
BNBHelp/          # Windows Help system (HLP/RTF)
KeyGen/           # License key generator
Patch/            # Version patches (1-12)
```

## Build Instructions

1. Open `BNBCode/bnb.vbp` in Visual Basic 5.0 IDE
2. Ensure all OCX controls are registered on the system
3. File → Make bnb.exe

**Required OCX registrations:**
- CRYSTL32.OCX, SSDATB32.OCX, SSDATA32.OCX
- GRAPHS32.OCX, THREED32.OCX, SPIN32.OCX, COMDLG32.OCX

## Architecture

### Core Modules

| Module | Purpose |
|--------|---------|
| BNB1.BAS | Global variables, database connection (`gBNB As Database`), helper functions |
| BNBMODE.BAS | Form state management (Browse/Insert/Update/Delete/Find modes) |
| CONSTANT.BAS | Global constants (key codes, currency formats, VB constants) |
| WINAPI.BAS | Windows API declarations |

### Form Mode System

Forms operate in distinct modes managed by `BNBMODE.BAS`:
- **Browse** - Read-only viewing
- **Insert** - Adding new records
- **Update** - Editing existing records
- **Delete** - Removing records
- **Find** - Search functionality

The mode system dynamically enables/disables controls and updates form captions.

### Data Access Pattern

Forms use data-bound controls connected directly to DAO recordsets:
```
Form Controls ←→ DAO Recordset ←→ Access Database (bnb1.mdb)
```

Global database connection: `Public gBNB As Database` (declared in BNB1.BAS)

### Main Form Hierarchy

`MDIBNB.FRM` is the MDI container with menus:
- **File** - Backup, printer setup, exit
- **Guests** - General info, accommodations, travel, autos
- **Accounts** - Hosts, travel agencies, car agencies
- **Availability** - Room/car availability calendars
- **Reports** - Business reports via Crystal Reports
- **Tools** - Data analysis, configuration

## Key Form Files

| Form | Lines | Purpose |
|------|-------|---------|
| MDIBNB.FRM | 2,525 | Main MDI container |
| PAYMENT.FRM | 2,511 | Payment processing |
| PROPERTY.FRM | 2,338 | Property/host management |
| GENGUEST.FRM | 1,755 | Guest information |

## Database

- **bnb1.mdb** - Production database with sample data
- **bnbNoDat.mdb** - Empty template for testing/new installations

Tables include: Guests, Properties, Accommodations, Reservations, Payments, Commissions, Travel Agencies, Car Rental Agencies, Check/Ledger records.

## Modernization Notes

This codebase targets Windows 95/98/NT/2000 era systems. Key challenges for modernizing to Windows 10/11:

1. **VB5 to VB.NET/C# Migration** - VB5 is not supported on modern systems; requires rewrite
2. **OCX Dependencies** - Third-party OCX controls (Sheridan, Crystal Reports 5.x) are obsolete
3. **DAO to ADO.NET/EF** - DAO 2.5 should be replaced with modern data access
4. **Access Database** - Consider migrating to SQL Server Express or SQLite
5. **Crystal Reports** - Replace with modern reporting (RDLC, Telerik, or web-based)
6. **Help System** - WinHelp (.HLP) is not supported on 64-bit Windows; use CHM or HTML

## Code Statistics

- ~25,000 lines of VB code
- 45 forms, 4 modules
- 27 Crystal Reports
