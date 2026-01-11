# BnB Modernization Plan: VB5 to Modern Windows (10/11)

This document outlines the strategy for migrating the BnB (Bed & Breakfast) reservation system from Visual Basic 5.0 to a modern platform compatible with Windows 10/11.

## Executive Summary

The current BnB application is a VB5 desktop application (~25,000 lines of code) with 45 forms and an Access database. VB5 executables do not run natively on modern Windows. A complete rewrite is required.

## Migration Options

### Option A: Windows Desktop (WinForms/.NET) - Recommended
**Pros:** Closest to original UX, fastest development, direct database migration path
**Cons:** Desktop-only, requires installation

**Technology Stack:**
- C# with .NET 8 (LTS)
- WinForms for UI (familiar MDI paradigm)
- Entity Framework Core for data access
- SQL Server Express LocalDB or SQLite (replacing Access)
- RDLC Reports or FastReport (replacing Crystal Reports)

### Option B: Windows Desktop (WPF/.NET)
**Pros:** Modern XAML-based UI, better separation of concerns
**Cons:** Steeper learning curve, more development time

### Option C: Web Application (ASP.NET Core + Blazor)
**Pros:** Cross-platform access, no installation required, cloud-ready
**Cons:** Different UX paradigm, requires web hosting

### Option D: Cross-Platform Desktop (MAUI)
**Pros:** Single codebase for Windows/Mac/mobile
**Cons:** Newer technology, smaller ecosystem

---

## Recommended Approach: Option A (WinForms/.NET 8)

This minimizes risk and development time while achieving modern Windows compatibility.

## Phase 1: Foundation Setup

### 1.1 Create New Solution Structure
```
BnB.Modern/
├── BnB.sln
├── src/
│   ├── BnB.Core/              # Domain models, business logic
│   │   ├── Models/
│   │   ├── Services/
│   │   └── Interfaces/
│   ├── BnB.Data/              # Data access layer
│   │   ├── DbContext/
│   │   ├── Repositories/
│   │   └── Migrations/
│   ├── BnB.WinForms/          # UI layer (main app)
│   │   ├── Forms/
│   │   ├── Controls/
│   │   └── Reports/
│   └── BnB.Common/            # Shared utilities
└── tests/
    └── BnB.Tests/
```

### 1.2 Database Migration Strategy

**Current:** bnb1.mdb (Access/Jet)

**Target:** SQL Server Express LocalDB (or SQLite for portability)

Steps:
1. Analyze Access database schema using SSMA (SQL Server Migration Assistant)
2. Create Entity Framework Core models matching existing tables
3. Create data migration tool to import existing Access data
4. Implement EF Core DbContext with proper relationships

**Key Tables to Migrate:**
- Guests (confirmation numbers, contact info)
- Properties/Hosts (proptbl - account info, commission rates)
- Accommodations (room reservations)
- Payments (payment records)
- Tax Rates/Plans (taxrates, tax plans)
- Travel Agencies (commission tracking)
- Car Rentals (car rental accounts)
- Check Ledger (financial records)
- math_tbl (currency-to-text conversion lookup)

### 1.3 Replace Obsolete Dependencies

| VB5 Component | Modern Replacement |
|--------------|-------------------|
| Crystal Reports 5 (CRYSTL32.OCX) | RDLC Reports, FastReport, or Telerik |
| Sheridan SSDBGrid (SSDATB32.OCX) | DataGridView (built-in) |
| Sheridan Data Widgets (SSDATA32.OCX) | Standard .NET controls |
| DAO 2.5 | Entity Framework Core |
| Graphs32.OCX | LiveCharts2, ScottPlot, or OxyPlot |
| THREED32.OCX | Not needed (modern UI has built-in styling) |
| WinHelp (.HLP) | HTML Help (.CHM) or integrated help |

---

## Phase 2: Core Module Migration

### 2.1 Migrate BNB1.BAS → BnB.Core

Convert global functions and utilities:

| VB5 Function | C# Equivalent |
|-------------|---------------|
| `CurrencyToText()` | `CurrencyToWordsService.Convert()` |
| `SizeGridCells()` | Use DataGridView.AutoResizeColumns() |
| `FileExists()` | `File.Exists()` |
| `RFill()` | `string.PadRight()` |
| `Replace_All_In_With()` | `string.Replace()` |
| `DateFormatOk()` | `DateTime.TryParse()` |
| `GetWildcardDate()` | Custom date pattern parser |
| `CalculateAmounts()` | `TaxCalculationService` |
| `ExportData()` | `DataExportService` (CSV, Excel via EPPlus) |

### 2.2 Migrate BNBMODE.BAS → FormStateManager

The VB5 mode system (Browse/Insert/Update/Delete/Find) should become a service:

```csharp
public enum FormMode { Browse, Insert, Update, Delete, Find, NoRows }

public class FormStateManager
{
    public void SetMode(Form form, FormMode mode);
    public FormMode GetMode(Form form);
    public void EnableControlsForMode(Form form, FormMode mode);
}
```

### 2.3 Business Logic Services

Create services for key business operations:

```csharp
// Tax calculation (from CalculateAmounts in BNB1.BAS)
public interface ITaxCalculationService
{
    TaxResult CalculateAccommodationTaxes(
        decimal grossRate,
        int nights,
        string taxPlanCode,
        decimal percentToHost,
        DateTime arrivalDate);
}

// Currency to words (for check printing)
public interface ICurrencyToWordsService
{
    string Convert(decimal amount);
}

// Report generation
public interface IReportService
{
    void GenerateConfirmation(int confirmationNumber);
    void GenerateCommissionReport(DateRange range);
    // ... other reports
}
```

---

## Phase 3: Form Migration (45 Forms)

### Priority 1: Core Forms (Critical Path)
1. **MDIBNB.FRM** → MainForm.cs (MDI container, menu system)
2. **GENGUEST.FRM** → GuestForm.cs (guest management)
3. **ACCOM.FRM** → AccommodationsForm.cs (reservations)
4. **PAYMENT.FRM** → PaymentForm.cs (payment processing)
5. **PROPERTY.FRM** → PropertyForm.cs (host accounts)

### Priority 2: Financial Forms
6. CHKLEDGR.FRM → CheckLedgerForm.cs
7. Commish.frm → CommissionForm.cs
8. PayRec.frm → PaymentReceiptForm.cs
9. Tax1099.frm → Tax1099Form.cs
10. TAXRATES.FRM → TaxRatesForm.cs

### Priority 3: Secondary Forms
11. TRAVACCT.FRM → TravelAgencyForm.cs
12. Car.frm → CarRentalForm.cs
13. Avail.frm → AvailabilityForm.cs
14. RoomType.frm → RoomTypeForm.cs
15. COMPINFO.FRM → CompanyInfoForm.cs

### Priority 4: Dialog Forms
16. PRINTDLG.FRM → PrintDialog.cs
17. XPORTDLG.FRM → ExportDialog.cs
18. BACKDLG.FRM → BackupDialog.cs
19. LISTDIAG.FRM → ListDialog.cs
20. CONFDLG.FRM → ConfirmationDialog.cs
21. TRENDDLG.FRM + TRENDGRA.FRM → TrendAnalysisForm.cs

### Priority 5: Remaining Forms
- (Continue with remaining 24 forms)

### Form Migration Pattern

For each VB5 form:
1. Create C# WinForms equivalent
2. Replicate control layout (use VS Designer)
3. Migrate event handlers
4. Connect to new data services
5. Implement mode management
6. Test thoroughly

---

## Phase 4: Report Migration

### Current Reports (27 Crystal Reports .rpt files)

| Report | Purpose |
|--------|---------|
| conf.rpt, conf2.rpt | Reservation confirmations |
| Arrival1.rpt, Depart1.rpt | Arrival/departure lists |
| Commish1.rpt, Commish2.rpt, Commish3.rpt | Commission reports |
| Daily1.rpt | Daily booking summary |
| ChkLedgr.rpt | Check ledger |
| Various others | Financial, tax, operational reports |

### Migration Approach

1. **Analyze each .rpt file** to understand:
   - Data source (SQL query)
   - Layout and formatting
   - Parameters and filters

2. **Recreate using RDLC** (or chosen reporting tool):
   - Define report data models
   - Design report layouts
   - Implement parameter handling

3. **Create ReportViewer integration**

---

## Phase 5: Data Migration Tool

Create a one-time migration utility:

```csharp
public class DataMigrationService
{
    public async Task MigrateFromAccess(string accessDbPath, string connectionString)
    {
        // 1. Connect to Access database
        // 2. Read all tables
        // 3. Transform data as needed
        // 4. Insert into new SQL database
        // 5. Verify data integrity
    }
}
```

---

## Phase 6: Testing & Deployment

### 6.1 Testing Strategy
- Unit tests for business logic
- Integration tests for data access
- UI automation tests for critical workflows
- User acceptance testing with existing data

### 6.2 Deployment
- Create MSI/MSIX installer
- Include SQL Server Express LocalDB or SQLite runtime
- Auto-update capability (optional)
- Migration wizard for existing installations

---

## Technical Considerations

### Data Integrity
- Maintain confirmation number sequences
- Preserve historical financial data
- Audit trail for migration

### Security Improvements
- Replace hardcoded database paths with configuration
- Implement proper user authentication (if multi-user)
- Encrypt sensitive data (credit card info, etc.)

### Performance
- Index database properly
- Implement lazy loading for large datasets
- Cache frequently accessed lookup data

---

## Estimated Component Mapping

| VB5 Lines | Component | Estimated C# Lines | Notes |
|-----------|-----------|-------------------|-------|
| 1,704 | BNB1.BAS | ~800-1,000 | Split into services |
| 803 | BNBMODE.BAS | ~300-400 | FormStateManager |
| 1,133 | CONSTANT.BAS | ~100-200 | Use .NET constants |
| 91 | WINAPI.BAS | ~20-50 | Most not needed |
| ~21,000 | 45 Forms | ~15,000-20,000 | Designer + code-behind |
| - | Data Layer | ~2,000-3,000 | EF Core models/context |
| - | Reports | ~500-1,000 | RDLC definitions |

**Total Estimated: ~20,000-25,000 lines of C#**

---

## Risk Mitigation

1. **OCX Control Behavior** - Document exact behavior of Sheridan controls before replacement
2. **Crystal Reports Formulas** - Extract all formulas and recreate in new system
3. **Tax Calculations** - Thoroughly test tax plan logic against known results
4. **Currency-to-Text** - Verify math_tbl conversion matches expected output
5. **Date Handling** - VB5 date handling differs from .NET; test edge cases

---

## Getting Started

1. Set up development environment:
   - Visual Studio 2022+
   - .NET 8 SDK
   - SQL Server Express LocalDB

2. Create solution structure (see Phase 1.1)

3. Begin with data layer:
   - Analyze bnb1.mdb schema
   - Create EF Core models
   - Build migration tool

4. Migrate core forms in priority order

5. Iterate and test
