using System.Data;
using BnB.Core.Models;
using BnB.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace BnB.WinForms.Services;

/// <summary>
/// Service to migrate data from legacy Access database to SQLite
/// </summary>
public class DataMigrationService
{
    private readonly string _accessDbPath;
    private readonly BnBDbContext _context;
    private readonly IProgress<MigrationProgress>? _progress;

    public DataMigrationService(string accessDbPath, BnBDbContext context, IProgress<MigrationProgress>? progress = null)
    {
        _accessDbPath = accessDbPath;
        _context = context;
        _progress = progress;
    }

    public async Task<MigrationResult> MigrateAllAsync()
    {
        var result = new MigrationResult();

        using var reader = new AccessDataReader(_accessDbPath);
        reader.Open();

        try
        {
            // Migration order respects foreign key dependencies
            result.TaxRates = await MigrateTaxRatesAsync(reader);
            result.TaxPlans = await MigrateTaxPlansAsync(reader);
            result.TravelAgencies = await MigrateTravelAgenciesAsync(reader);
            result.CarAgencies = await MigrateCarAgenciesAsync(reader);
            result.Properties = await MigratePropertiesAsync(reader);
            result.RoomTypes = await MigrateRoomTypesAsync(reader);
            result.Guests = await MigrateGuestsAsync(reader);
            result.Accommodations = await MigrateAccommodationsAsync(reader);
            result.Payments = await MigratePaymentsAsync(reader);
            result.Checks = await MigrateChecksAsync(reader);
            result.TravelAgentBookings = await MigrateTravelAgentBookingsAsync(reader);
            result.CarRentals = await MigrateCarRentalsAsync(reader);

            result.Success = true;
        }
        catch (Exception ex)
        {
            result.Success = false;
            // Get the innermost exception for more details
            var innerEx = ex;
            while (innerEx.InnerException != null)
                innerEx = innerEx.InnerException;
            result.ErrorMessage = $"{ex.Message}\nDetails: {innerEx.Message}";
        }

        return result;
    }

    private void ReportProgress(string table, int current, int total)
    {
        _progress?.Report(new MigrationProgress(table, current, total));
    }

    private async Task<int> MigrateTaxRatesAsync(AccessDataReader reader)
    {
        ReportProgress("Tax Rates", 0, 0);

        // Clear existing data
        await _context.TaxRates.ExecuteDeleteAsync();

        var table = reader.ReadTable("taxrates");
        var count = 0;

        foreach (DataRow row in table.Rows)
        {
            var taxRate = new TaxRate
            {
                TaxOne = AccessDataReader.GetDecimal(row, "tax_one"),
                TaxOneDescription = AccessDataReader.GetString(row, "tax_one_desc"),
                FutureTaxOne = AccessDataReader.GetNullableDecimal(row, "future_tax_one"),
                FutureTaxOneEffectiveDate = AccessDataReader.GetDateTime(row, "tax_one_eff_date"),
                TaxTwo = AccessDataReader.GetDecimal(row, "tax_two"),
                TaxTwoDescription = AccessDataReader.GetString(row, "tax_two_desc"),
                FutureTaxTwo = AccessDataReader.GetNullableDecimal(row, "future_tax_two"),
                FutureTaxTwoEffectiveDate = AccessDataReader.GetDateTime(row, "tax_two_eff_date"),
                TaxThree = AccessDataReader.GetDecimal(row, "tax_three"),
                TaxThreeDescription = AccessDataReader.GetString(row, "tax_three_desc"),
                FutureTaxThree = AccessDataReader.GetNullableDecimal(row, "future_tax_three"),
                FutureTaxThreeEffectiveDate = AccessDataReader.GetDateTime(row, "tax_three_eff_date")
            };

            _context.TaxRates.Add(taxRate);
            count++;
        }

        await _context.SaveChangesAsync();
        ReportProgress("Tax Rates", count, count);
        return count;
    }

    private async Task<int> MigrateTaxPlansAsync(AccessDataReader reader)
    {
        ReportProgress("Tax Plans", 0, 0);

        await _context.TaxPlans.ExecuteDeleteAsync();

        // Get the global tax rate record to copy rates into each plan
        // Query directly from the database
        var taxRateCount = await _context.TaxRates.CountAsync();
        var globalTaxRate = await _context.TaxRates.FirstOrDefaultAsync();

        // Log what we found
        if (globalTaxRate == null)
        {
            ReportProgress($"Tax Plans (WARNING: No TaxRate found, count={taxRateCount})", 0, 0);
        }
        else
        {
            ReportProgress($"Tax Plans (Found TaxRate: {globalTaxRate.TaxOne}% {globalTaxRate.TaxOneDescription})", 0, 0);
        }

        var table = reader.ReadTable("taxplan");
        var count = 0;

        foreach (DataRow row in table.Rows)
        {
            var planCode = AccessDataReader.GetString(row, "plancode");
            if (string.IsNullOrEmpty(planCode)) continue;

            var taxPlan = new TaxPlan
            {
                PlanCode = planCode,
                PlanTitle = AccessDataReader.GetString(row, "plan_title"),
                Description = AccessDataReader.GetString(row, "description")
            };

            // Parse the plan code to set application settings
            taxPlan.ParsePlanCode(planCode);

            // Copy tax rates from global TaxRate record
            if (globalTaxRate != null)
            {
                taxPlan.Tax1Rate = globalTaxRate.TaxOne;
                taxPlan.Tax1Description = globalTaxRate.TaxOneDescription;
                taxPlan.FutureTax1Rate = globalTaxRate.FutureTaxOne;
                taxPlan.FutureTax1EffectiveDate = globalTaxRate.FutureTaxOneEffectiveDate;

                taxPlan.Tax2Rate = globalTaxRate.TaxTwo;
                taxPlan.Tax2Description = globalTaxRate.TaxTwoDescription;
                taxPlan.FutureTax2Rate = globalTaxRate.FutureTaxTwo;
                taxPlan.FutureTax2EffectiveDate = globalTaxRate.FutureTaxTwoEffectiveDate;

                taxPlan.Tax3Rate = globalTaxRate.TaxThree;
                taxPlan.Tax3Description = globalTaxRate.TaxThreeDescription;
                taxPlan.FutureTax3Rate = globalTaxRate.FutureTaxThree;
                taxPlan.FutureTax3EffectiveDate = globalTaxRate.FutureTaxThreeEffectiveDate;
            }

            _context.TaxPlans.Add(taxPlan);
            count++;
        }

        await _context.SaveChangesAsync();
        ReportProgress("Tax Plans", count, count);

        return count;
    }

    private async Task<int> MigrateTravelAgenciesAsync(AccessDataReader reader)
    {
        ReportProgress("Travel Agencies", 0, 0);

        await _context.TravelAgentBookings.ExecuteDeleteAsync();
        await _context.TravelAgencies.ExecuteDeleteAsync();

        // Try tamaster first, fall back to tagentbl for agency info
        DataTable table;
        try
        {
            table = reader.ReadTable("tamaster");
        }
        catch
        {
            // tamaster might not exist, agencies might be embedded in tagentbl
            return 0;
        }

        var count = 0;

        foreach (DataRow row in table.Rows)
        {
            var agency = new TravelAgency
            {
                AccountNumber = AccessDataReader.GetInt(row, "accountnum"),
                Name = AccessDataReader.GetString(row, "agencyname") ?? AccessDataReader.GetString(row, "name") ?? "Unknown",
                ContactName = AccessDataReader.GetString(row, "contactname") ?? AccessDataReader.GetString(row, "contact"),
                Address = AccessDataReader.GetString(row, "address"),
                City = AccessDataReader.GetString(row, "city"),
                State = AccessDataReader.GetString(row, "state"),
                ZipCode = AccessDataReader.GetString(row, "zipcode") ?? AccessDataReader.GetString(row, "zip"),
                Phone = AccessDataReader.GetString(row, "phone"),
                Fax = AccessDataReader.GetString(row, "fax"),
                Email = AccessDataReader.GetString(row, "email"),
                CommissionPercent = AccessDataReader.GetNullableDecimal(row, "commpercent") ?? AccessDataReader.GetNullableDecimal(row, "commission"),
                Comments = AccessDataReader.GetString(row, "comments")
            };

            _context.TravelAgencies.Add(agency);
            count++;
        }

        await _context.SaveChangesAsync();
        ReportProgress("Travel Agencies", count, count);
        return count;
    }

    private async Task<int> MigrateCarAgenciesAsync(AccessDataReader reader)
    {
        ReportProgress("Car Agencies", 0, 0);

        await _context.CarRentals.ExecuteDeleteAsync();
        await _context.CarAgencies.ExecuteDeleteAsync();

        DataTable table;
        try
        {
            table = reader.ReadTable("carmaster");
        }
        catch
        {
            return 0;
        }

        var count = 0;

        foreach (DataRow row in table.Rows)
        {
            var agency = new CarAgency
            {
                Name = AccessDataReader.GetString(row, "agencyname") ?? AccessDataReader.GetString(row, "name") ?? "Unknown",
                ContactName = AccessDataReader.GetString(row, "contactname") ?? AccessDataReader.GetString(row, "contact"),
                Address = AccessDataReader.GetString(row, "address"),
                City = AccessDataReader.GetString(row, "city"),
                State = AccessDataReader.GetString(row, "state"),
                ZipCode = AccessDataReader.GetString(row, "zipcode") ?? AccessDataReader.GetString(row, "zip"),
                Phone = AccessDataReader.GetString(row, "phone"),
                Fax = AccessDataReader.GetString(row, "fax"),
                Email = AccessDataReader.GetString(row, "email"),
                CommissionPercent = AccessDataReader.GetNullableDecimal(row, "commpercent") ?? AccessDataReader.GetNullableDecimal(row, "commission"),
                Comments = AccessDataReader.GetString(row, "comments")
            };

            _context.CarAgencies.Add(agency);
            count++;
        }

        await _context.SaveChangesAsync();
        ReportProgress("Car Agencies", count, count);
        return count;
    }

    private async Task<int> MigratePropertiesAsync(AccessDataReader reader)
    {
        ReportProgress("Properties", 0, 0);

        await _context.Database.ExecuteSqlRawAsync("DELETE FROM Accommodations");
        await _context.Database.ExecuteSqlRawAsync("DELETE FROM RoomTypes");
        await _context.Database.ExecuteSqlRawAsync("DELETE FROM Properties");

        // Clear the change tracker to avoid conflicts
        _context.ChangeTracker.Clear();

        var table = reader.ReadTable("proptbl");
        var total = table.Rows.Count;
        var count = 0;
        var seenAccountNumbers = new HashSet<int>();

        foreach (DataRow row in table.Rows)
        {
            var accountNumber = AccessDataReader.GetInt(row, "accountnum");

            // Skip duplicate account numbers
            if (seenAccountNumbers.Contains(accountNumber))
                continue;
            seenAccountNumbers.Add(accountNumber);

            var property = new Property
            {
                AccountNumber = accountNumber,
                Location = AccessDataReader.GetString(row, "location") ?? "Unknown",
                FullName = AccessDataReader.GetString(row, "fullname"),
                DBA = AccessDataReader.GetString(row, "dba"),
                PropertyAddress = AccessDataReader.GetString(row, "propaddress") ?? AccessDataReader.GetString(row, "propaddr"),
                PropertyCity = AccessDataReader.GetString(row, "propcity"),
                PropertyState = AccessDataReader.GetString(row, "propstate"),
                PropertyZipCode = AccessDataReader.GetString(row, "propzipcode") ?? AccessDataReader.GetString(row, "propzip"),
                PropertyPhone = AccessDataReader.GetString(row, "propphone"),
                PropertyFax = AccessDataReader.GetString(row, "propfax"),
                MailingAddress = AccessDataReader.GetString(row, "mailaddress") ?? AccessDataReader.GetString(row, "mailaddr"),
                MailingCity = AccessDataReader.GetString(row, "mailcity"),
                MailingState = AccessDataReader.GetString(row, "mailstate"),
                MailingZipCode = AccessDataReader.GetString(row, "mailzipcode") ?? AccessDataReader.GetString(row, "mailzip"),
                MailingPhone1 = AccessDataReader.GetString(row, "mailphone1"),
                MailingPhone2 = AccessDataReader.GetString(row, "mailphone2"),
                MailingFax = AccessDataReader.GetString(row, "mailfax"),
                Email = AccessDataReader.GetString(row, "email"),
                WebUrl = AccessDataReader.GetString(row, "weburl"),
                CheckTo = AccessDataReader.GetString(row, "check_to") ?? AccessDataReader.GetString(row, "checkto"),
                PercentToHost = AccessDataReader.GetDecimal(row, "perdirect", 0),
                FuturePercent = AccessDataReader.GetNullableDecimal(row, "futurepercent"),
                FuturePercentDate = AccessDataReader.GetDateTime(row, "futuredate"),
                GrossRatePercent = AccessDataReader.GetNullableDecimal(row, "grosratepercent") ?? AccessDataReader.GetNullableDecimal(row, "grosspercent"),
                FederalTaxId = AccessDataReader.GetString(row, "federaltaxid") ?? AccessDataReader.GetString(row, "fedtaxid"),
                TaxPlanCode = AccessDataReader.GetString(row, "tax_plan_code"),
                DepositRequired = AccessDataReader.GetString(row, "depositreq"),
                Exceptions = AccessDataReader.GetString(row, "exceptions"),
                ExceptionsDescription = AccessDataReader.GetString(row, "exceptions_desc"),
                IsObsolete = AccessDataReader.GetBool(row, "propobsolete") || AccessDataReader.GetBool(row, "obsolete"),
                SuppressFlag = AccessDataReader.GetBool(row, "suppressflag") || AccessDataReader.GetBool(row, "suppress"),
                Comments = AccessDataReader.GetString(row, "comments")
            };

            _context.Properties.Add(property);
            count++;
            ReportProgress("Properties", count, total);
        }

        await _context.SaveChangesAsync();
        return count;
    }

    private async Task<int> MigrateRoomTypesAsync(AccessDataReader reader)
    {
        ReportProgress("Room Types", 0, 0);

        // Get valid property account numbers
        var validProperties = await _context.Properties.Select(p => p.AccountNumber).ToListAsync();

        DataTable? table = null;
        bool isLinkTable = false;
        string? tableUsed = null;
        var errors = new List<string>();

        // Try HostAccount_RoomType_Link first (the actual table name used in original VB5 app)
        try
        {
            table = reader.ReadTable("HostAccount_RoomType_Link");
            isLinkTable = true;
            tableUsed = "HostAccount_RoomType_Link";
        }
        catch (Exception ex)
        {
            errors.Add($"HostAccount_RoomType_Link: {ex.Message}");
            // Fall back to other possible table names
            try
            {
                table = reader.ReadTable("roomtbl");
                tableUsed = "roomtbl";
            }
            catch (Exception ex2)
            {
                errors.Add($"roomtbl: {ex2.Message}");
                try
                {
                    table = reader.ReadTable("hostaccount_roomtype_link");
                    isLinkTable = true;
                    tableUsed = "hostaccount_roomtype_link";
                }
                catch (Exception ex3)
                {
                    errors.Add($"hostaccount_roomtype_link: {ex3.Message}");
                    // Log all errors for debugging
                    System.Diagnostics.Debug.WriteLine($"Room Types migration - no table found. Errors: {string.Join("; ", errors)}");
                    return 0;
                }
            }
        }

        if (table == null) return 0;

        System.Diagnostics.Debug.WriteLine($"Room Types migration - using table: {tableUsed}, rows: {table.Rows.Count}, columns: {string.Join(", ", table.Columns.Cast<DataColumn>().Select(c => c.ColumnName))}");

        var count = 0;
        var total = table.Rows.Count;

        foreach (DataRow row in table.Rows)
        {
            var accountNum = AccessDataReader.GetInt(row, "accountnum");
            if (!validProperties.Contains(accountNum)) continue;

            string? name;
            string? description;

            if (isLinkTable)
            {
                // HostAccount_RoomType_Link uses RoomType (integer) and RoomType_Desc columns
                var roomTypeNum = AccessDataReader.GetInt(row, "roomtype", 0);
                name = roomTypeNum > 0 ? roomTypeNum.ToString() : "Room";
                description = AccessDataReader.GetString(row, "roomtype_desc");
            }
            else
            {
                // Other table formats use unitname/roomname columns
                name = AccessDataReader.GetString(row, "unitname") ?? AccessDataReader.GetString(row, "roomname") ?? "Room";
                description = AccessDataReader.GetString(row, "description") ?? AccessDataReader.GetString(row, "unitnamedesc");
            }

            var roomType = new RoomType
            {
                PropertyAccountNumber = accountNum,
                Name = name ?? "Room",
                Description = description,
                DefaultRate = AccessDataReader.GetNullableDecimal(row, "rate") ?? AccessDataReader.GetNullableDecimal(row, "defaultrate"),
                RoomCount = 1 // Default to 1, user can adjust as needed
            };

            _context.RoomTypes.Add(roomType);
            count++;
            ReportProgress("Room Types", count, total);
        }

        await _context.SaveChangesAsync();
        return count;
    }

    private async Task<int> MigrateGuestsAsync(AccessDataReader reader)
    {
        ReportProgress("Guests", 0, 0);

        await _context.Database.ExecuteSqlRawAsync("DELETE FROM TravelAgentBookings");
        await _context.Database.ExecuteSqlRawAsync("DELETE FROM CarRentals");
        await _context.Database.ExecuteSqlRawAsync("DELETE FROM Payments");
        await _context.Database.ExecuteSqlRawAsync("DELETE FROM Checks");
        await _context.Database.ExecuteSqlRawAsync("DELETE FROM Accommodations");
        await _context.Database.ExecuteSqlRawAsync("DELETE FROM Guests");

        var table = reader.ReadTable("guesttbl");
        var total = table.Rows.Count;
        var count = 0;
        var batchSize = 100;
        var batch = new List<Guest>();

        foreach (DataRow row in table.Rows)
        {
            var guest = new Guest
            {
                ConfirmationNumber = AccessDataReader.GetLong(row, "conf"),
                FirstName = AccessDataReader.GetString(row, "f_name") ?? AccessDataReader.GetString(row, "fname") ?? "",
                LastName = AccessDataReader.GetString(row, "l_name") ?? AccessDataReader.GetString(row, "lname") ?? "",
                Address = AccessDataReader.GetString(row, "address") ?? AccessDataReader.GetString(row, "addr"),
                BusinessAddress = AccessDataReader.GetString(row, "busadd") ?? AccessDataReader.GetString(row, "busaddress"),
                City = AccessDataReader.GetString(row, "city"),
                State = AccessDataReader.GetString(row, "state"),
                ZipCode = AccessDataReader.GetString(row, "zipcode") ?? AccessDataReader.GetString(row, "zip"),
                Country = AccessDataReader.GetString(row, "country"),
                HomePhone = AccessDataReader.GetString(row, "hmphone") ?? AccessDataReader.GetString(row, "homephone"),
                BusinessPhone = AccessDataReader.GetString(row, "bsphone") ?? AccessDataReader.GetString(row, "busphone"),
                FaxNumber = AccessDataReader.GetString(row, "faxnum") ?? AccessDataReader.GetString(row, "fax"),
                Email = AccessDataReader.GetString(row, "email"),
                DateBooked = AccessDataReader.GetDateTime(row, "datebkd") ?? AccessDataReader.GetDateTime(row, "datebooked"),
                BookedBy = AccessDataReader.GetString(row, "bookedby"),
                Referral = (AccessDataReader.GetString(row, "referral")).Truncate(100),
                ReservationFee = AccessDataReader.GetNullableDecimal(row, "resfee"),
                TravelingWith = (AccessDataReader.GetString(row, "travwith") ?? AccessDataReader.GetString(row, "travelingwith")).Truncate(200),
                Comments = (AccessDataReader.GetString(row, "cmmnts") ?? AccessDataReader.GetString(row, "comments")).Truncate(2000),
                LabelFlag = AccessDataReader.GetBool(row, "lbl_flag"),
                Closure = (AccessDataReader.GetString(row, "closeure") ?? AccessDataReader.GetString(row, "closure")).Truncate(2000),
                EntryDate = AccessDataReader.GetDateTime(row, "entrydate"),
                EntryUser = AccessDataReader.GetString(row, "entryuser"),
                UpdateDate = AccessDataReader.GetDateTime(row, "updatedate"),
                UpdateUser = AccessDataReader.GetString(row, "updateuser"),
                RevisionDate = AccessDataReader.GetDateTime(row, "revdate"),
                Revision = AccessDataReader.GetInt(row, "revision", 0)
            };

            batch.Add(guest);
            count++;

            if (batch.Count >= batchSize)
            {
                _context.Guests.AddRange(batch);
                await _context.SaveChangesAsync();
                batch.Clear();
                ReportProgress("Guests", count, total);
            }
        }

        if (batch.Count > 0)
        {
            _context.Guests.AddRange(batch);
            await _context.SaveChangesAsync();
        }

        ReportProgress("Guests", count, total);
        return count;
    }

    private async Task<int> MigrateAccommodationsAsync(AccessDataReader reader)
    {
        ReportProgress("Accommodations", 0, 0);

        var validGuests = await _context.Guests.Select(g => g.ConfirmationNumber).ToListAsync();
        var validProperties = await _context.Properties.Select(p => p.AccountNumber).ToListAsync();

        var table = reader.ReadTable("bbtbl");
        var total = table.Rows.Count;
        var count = 0;
        var skipped = 0;

        foreach (DataRow row in table.Rows)
        {
            var conf = AccessDataReader.GetLong(row, "conf");
            var accountNum = AccessDataReader.GetInt(row, "accountnum");

            // Skip if foreign keys don't exist
            if (!validGuests.Contains(conf) || !validProperties.Contains(accountNum))
            {
                skipped++;
                continue;
            }

            try
            {
                var accommodation = new Accommodation
                {
                    ConfirmationNumber = conf,
                    PropertyAccountNumber = accountNum,
                    FirstName = (AccessDataReader.GetString(row, "f_name") ?? AccessDataReader.GetString(row, "fname")).Truncate(50),
                    LastName = (AccessDataReader.GetString(row, "l_name") ?? AccessDataReader.GetString(row, "lname")).Truncate(50),
                    Location = (AccessDataReader.GetString(row, "location")).Truncate(100),
                    ArrivalDate = AccessDataReader.GetDateTime(row, "arrdate") ?? DateTime.Today,
                    DepartureDate = AccessDataReader.GetDateTime(row, "depdate") ?? DateTime.Today,
                    NumberOfNights = GetIntWithFallback(row, "numnites", "numnights", 1),
                    NumberInParty = GetIntWithFallback(row, "numpty", "numinparty", 0),
                    UnitName = (AccessDataReader.GetString(row, "unitname")).Truncate(50),
                    UnitNameDescription = (AccessDataReader.GetString(row, "unitnamedesc")).Truncate(200),
                    DailyGrossRate = AccessDataReader.GetNullableDecimal(row, "grosrate") ?? AccessDataReader.GetNullableDecimal(row, "dailygrossrate"),
                    DailyNetRate = AccessDataReader.GetNullableDecimal(row, "netrate") ?? AccessDataReader.GetNullableDecimal(row, "dailynetrate"),
                    TotalGrossWithTax = AccessDataReader.GetNullableDecimal(row, "gwtax") ?? AccessDataReader.GetNullableDecimal(row, "totgrosswithtax"),
                    TotalNetWithTax = AccessDataReader.GetNullableDecimal(row, "nwtax") ?? AccessDataReader.GetNullableDecimal(row, "totnetwithtax"),
                    TotalTax = AccessDataReader.GetNullableDecimal(row, "tax") ?? AccessDataReader.GetNullableDecimal(row, "tottax"),
                    Tax1 = AccessDataReader.GetNullableDecimal(row, "tax1"),
                    Tax2 = AccessDataReader.GetNullableDecimal(row, "tax2"),
                    Tax3 = AccessDataReader.GetNullableDecimal(row, "tax3"),
                    ServiceFee = AccessDataReader.GetNullableDecimal(row, "svcharge") ?? AccessDataReader.GetNullableDecimal(row, "servicefee"),
                    Commission = AccessDataReader.GetDecimal(row, "commish", 0) + AccessDataReader.GetDecimal(row, "commission", 0),
                    CommissionPaid = AccessDataReader.GetNullableDecimal(row, "comm_paid") ?? AccessDataReader.GetNullableDecimal(row, "commissionpaid"),
                    CommissionReceived = AccessDataReader.GetNullableDecimal(row, "com_rcvd") ?? AccessDataReader.GetNullableDecimal(row, "commissionreceived"),
                    PaymentType = (AccessDataReader.GetString(row, "pymttype") ?? AccessDataReader.GetString(row, "paymenttype") ?? "Prepay").Truncate(20),
                    OverridePercentToHost = AccessDataReader.GetNullableDecimal(row, "percnt"),
                    OverrideTaxPlanCode = (AccessDataReader.GetString(row, "tax_plan_code")).Truncate(10),
                    UseManualAmounts = AccessDataReader.GetBool(row, "fillincalcamounts"),
                    Suppress = AccessDataReader.GetBool(row, "suppress"),
                    Notified = AccessDataReader.GetBool(row, "notified"),
                    Forfeit = AccessDataReader.GetBool(row, "forfeit"),
                    Comments = (AccessDataReader.GetString(row, "cmmnts") ?? AccessDataReader.GetString(row, "comments")).Truncate(2000),
                    NightNotes = (AccessDataReader.GetString(row, "nnotes") ?? AccessDataReader.GetString(row, "nightnotes")).Truncate(2000),
                    EntryDate = AccessDataReader.GetDateTime(row, "entrydate"),
                    EntryUser = (AccessDataReader.GetString(row, "entryuser")).Truncate(50),
                    UpdateDate = AccessDataReader.GetDateTime(row, "updatedate"),
                    UpdateUser = (AccessDataReader.GetString(row, "updateuser")).Truncate(50),
                    RevisionDate = AccessDataReader.GetDateTime(row, "rev_date")
                };

                _context.Accommodations.Add(accommodation);
                await _context.SaveChangesAsync();
                count++;

                if (count % 100 == 0)
                {
                    ReportProgress("Accommodations", count, total);
                }
            }
            catch (Microsoft.EntityFrameworkCore.DbUpdateException dbEx)
            {
                // Get the actual database error
                var sqliteError = dbEx.InnerException?.Message ?? dbEx.Message;

                // Get entity details if available
                var entries = dbEx.Entries.Select(e => $"{e.Entity.GetType().Name}: {e.State}").ToList();
                var entryInfo = entries.Count > 0 ? string.Join(", ", entries) : "unknown";

                throw new Exception($"Failed at conf {conf} ({entryInfo}): {sqliteError}", dbEx);
            }
            catch (Exception ex)
            {
                // Get innermost exception for actual error details
                var innerEx = ex;
                while (innerEx.InnerException != null)
                    innerEx = innerEx.InnerException;

                throw new Exception($"Failed at conf {conf}: {innerEx.Message} (Type: {innerEx.GetType().Name})", ex);
            }
        }

        ReportProgress("Accommodations", count, total);
        return count;
    }

    private async Task<int> MigratePaymentsAsync(AccessDataReader reader)
    {
        ReportProgress("Payments", 0, 0);

        var validGuests = await _context.Guests.Select(g => g.ConfirmationNumber).ToListAsync();

        var table = reader.ReadTable("paymentreceived");
        var total = table.Rows.Count;
        var count = 0;

        foreach (DataRow row in table.Rows)
        {
            var conf = AccessDataReader.GetLong(row, "conf");
            if (!validGuests.Contains(conf)) continue;

            var payment = new Payment
            {
                ConfirmationNumber = conf,
                FirstName = AccessDataReader.GetString(row, "f_name") ?? AccessDataReader.GetString(row, "fname"),
                LastName = AccessDataReader.GetString(row, "l_name") ?? AccessDataReader.GetString(row, "lname"),
                Amount = AccessDataReader.GetDecimal(row, "amountreceived", 0) + AccessDataReader.GetDecimal(row, "amount", 0),
                PaymentDate = AccessDataReader.GetDateTime(row, "datereceived") ?? AccessDataReader.GetDateTime(row, "paymentdate") ?? DateTime.Today,
                CheckNumber = AccessDataReader.GetString(row, "checknumber") ?? AccessDataReader.GetString(row, "checknum"),
                ReceivedFrom = AccessDataReader.GetString(row, "receivedfrom"),
                AppliedTo = AccessDataReader.GetString(row, "appliedto"),
                DepositDue = AccessDataReader.GetNullableDecimal(row, "depdue"),
                DepositDueDate = AccessDataReader.GetDateTime(row, "depdate"),
                PrepaymentDue = AccessDataReader.GetNullableDecimal(row, "predue"),
                PrepaymentDueDate = AccessDataReader.GetDateTime(row, "predate"),
                CancellationFee = AccessDataReader.GetNullableDecimal(row, "canclfee"),
                CancellationFeeDueDate = AccessDataReader.GetDateTime(row, "canclfeedatedue"),
                RefundOwed = AccessDataReader.GetNullableDecimal(row, "refundowed"),
                OtherCredit = AccessDataReader.GetNullableDecimal(row, "othercredit"),
                DefaultCommission = AccessDataReader.GetNullableDecimal(row, "defcom"),
                Comments = (AccessDataReader.GetString(row, "comments")).Truncate(2000)
            };

            _context.Payments.Add(payment);
            count++;

            if (count % 100 == 0)
            {
                await _context.SaveChangesAsync();
                ReportProgress("Payments", count, total);
            }
        }

        await _context.SaveChangesAsync();
        ReportProgress("Payments", count, total);
        return count;
    }

    private async Task<int> MigrateChecksAsync(AccessDataReader reader)
    {
        ReportProgress("Checks", 0, 0);

        // Build a map of accommodation IDs by conf+accountnum
        var accommodations = await _context.Accommodations
            .Select(a => new { a.Id, a.ConfirmationNumber, a.PropertyAccountNumber })
            .ToListAsync();

        DataTable table;
        try
        {
            table = reader.ReadTable("checktbl");
        }
        catch
        {
            return 0;
        }

        var count = 0;

        foreach (DataRow row in table.Rows)
        {
            var conf = AccessDataReader.GetLong(row, "conf");
            var accountNum = AccessDataReader.GetInt(row, "accountnum");

            // Find matching accommodation
            var accom = accommodations.FirstOrDefault(a =>
                a.ConfirmationNumber == conf && a.PropertyAccountNumber == accountNum);

            if (accom == null) continue;

            var check = new Check
            {
                AccommodationId = accom.Id,
                CheckNumber = AccessDataReader.GetString(row, "checknum") ?? "",
                Amount = AccessDataReader.GetDecimal(row, "amount"),
                CheckDate = AccessDataReader.GetDateTime(row, "checkdate"),
                PayableTo = AccessDataReader.GetString(row, "payableto") ?? AccessDataReader.GetString(row, "payto"),
                Memo = AccessDataReader.GetString(row, "memo"),
                IsVoid = AccessDataReader.GetBool(row, "void_chk") || AccessDataReader.GetBool(row, "voidchk"),
                Comments = AccessDataReader.GetString(row, "comments")
            };

            _context.Checks.Add(check);
            count++;
        }

        await _context.SaveChangesAsync();
        ReportProgress("Checks", count, count);
        return count;
    }

    private async Task<int> MigrateTravelAgentBookingsAsync(AccessDataReader reader)
    {
        ReportProgress("Travel Agent Bookings", 0, 0);

        var validGuests = await _context.Guests.Select(g => g.ConfirmationNumber).ToListAsync();
        var agencies = await _context.TravelAgencies.ToDictionaryAsync(a => a.AccountNumber, a => a.Id);

        DataTable table;
        try
        {
            table = reader.ReadTable("tagentbl");
        }
        catch
        {
            return 0;
        }

        var count = 0;

        foreach (DataRow row in table.Rows)
        {
            var conf = AccessDataReader.GetLong(row, "conf");
            if (!validGuests.Contains(conf)) continue;

            var agencyAccountNum = AccessDataReader.GetInt(row, "agencyaccountnum") + AccessDataReader.GetInt(row, "accountnum");
            int? agencyId = agencies.TryGetValue(agencyAccountNum, out var id) ? id : null;

            var booking = new TravelAgentBooking
            {
                ConfirmationNumber = conf,
                TravelAgencyId = agencyId,
                CommissionAmount = AccessDataReader.GetNullableDecimal(row, "commamount") ?? AccessDataReader.GetNullableDecimal(row, "commission"),
                CommissionPaid = AccessDataReader.GetNullableDecimal(row, "commpaid"),
                CommissionPaidDate = AccessDataReader.GetDateTime(row, "commpaiddate"),
                CheckNumber = AccessDataReader.GetString(row, "checknum"),
                Comments = AccessDataReader.GetString(row, "comments")
            };

            _context.TravelAgentBookings.Add(booking);
            count++;
        }

        await _context.SaveChangesAsync();
        ReportProgress("Travel Agent Bookings", count, count);
        return count;
    }

    private async Task<int> MigrateCarRentalsAsync(AccessDataReader reader)
    {
        ReportProgress("Car Rentals", 0, 0);

        var validGuests = await _context.Guests.Select(g => g.ConfirmationNumber).ToListAsync();
        var agencies = await _context.CarAgencies.ToListAsync();

        DataTable table;
        try
        {
            table = reader.ReadTable("cartbl");
        }
        catch
        {
            return 0;
        }

        var count = 0;

        foreach (DataRow row in table.Rows)
        {
            var conf = AccessDataReader.GetLong(row, "conf");
            if (!validGuests.Contains(conf)) continue;

            // Try to match car agency by name
            var agencyName = AccessDataReader.GetString(row, "carcompany") ?? AccessDataReader.GetString(row, "agency");
            var agency = agencies.FirstOrDefault(a =>
                a.Name.Equals(agencyName, StringComparison.OrdinalIgnoreCase));

            var rental = new CarRental
            {
                ConfirmationNumber = conf,
                CarAgencyId = agency?.Id,
                PickupDate = AccessDataReader.GetDateTime(row, "pudate") ?? AccessDataReader.GetDateTime(row, "pickupdate"),
                ReturnDate = AccessDataReader.GetDateTime(row, "dropdate") ?? AccessDataReader.GetDateTime(row, "returndate"),
                CarType = AccessDataReader.GetString(row, "cartype") ?? AccessDataReader.GetString(row, "carclass"),
                DailyRate = AccessDataReader.GetNullableDecimal(row, "dailyrate"),
                TotalAmount = AccessDataReader.GetNullableDecimal(row, "totalamount") ?? AccessDataReader.GetNullableDecimal(row, "total"),
                CommissionAmount = AccessDataReader.GetNullableDecimal(row, "commamount") ?? AccessDataReader.GetNullableDecimal(row, "commission"),
                CommissionPaid = AccessDataReader.GetNullableDecimal(row, "commpaid"),
                CommissionPaidDate = AccessDataReader.GetDateTime(row, "commpaiddate"),
                CheckNumber = AccessDataReader.GetString(row, "checknum"),
                Comments = AccessDataReader.GetString(row, "comments")
            };

            _context.CarRentals.Add(rental);
            count++;
        }

        await _context.SaveChangesAsync();
        ReportProgress("Car Rentals", count, count);
        return count;
    }

    /// <summary>
    /// Helper method to get an integer value with fallback column names
    /// </summary>
    private static int GetIntWithFallback(DataRow row, string primaryColumn, string fallbackColumn, int defaultValue)
    {
        if (row.Table.Columns.Contains(primaryColumn))
        {
            var val = AccessDataReader.GetInt(row, primaryColumn, int.MinValue);
            if (val != int.MinValue) return val;
        }

        if (row.Table.Columns.Contains(fallbackColumn))
        {
            return AccessDataReader.GetInt(row, fallbackColumn, defaultValue);
        }

        return defaultValue;
    }
}

/// <summary>
/// Progress report for migration
/// </summary>
public class MigrationProgress
{
    public string TableName { get; }
    public int CurrentRecord { get; }
    public int TotalRecords { get; }

    public MigrationProgress(string tableName, int currentRecord, int totalRecords)
    {
        TableName = tableName;
        CurrentRecord = currentRecord;
        TotalRecords = totalRecords;
    }
}

/// <summary>
/// Result of migration operation
/// </summary>
public class MigrationResult
{
    public bool Success { get; set; }
    public string? ErrorMessage { get; set; }

    public int TaxRates { get; set; }
    public int TaxPlans { get; set; }
    public int TravelAgencies { get; set; }
    public int CarAgencies { get; set; }
    public int Properties { get; set; }
    public int RoomTypes { get; set; }
    public int Guests { get; set; }
    public int Accommodations { get; set; }
    public int Payments { get; set; }
    public int Checks { get; set; }
    public int TravelAgentBookings { get; set; }
    public int CarRentals { get; set; }

    public int TotalRecords => TaxRates + TaxPlans + TravelAgencies + CarAgencies +
                               Properties + RoomTypes + Guests + Accommodations +
                               Payments + Checks + TravelAgentBookings + CarRentals;
}
