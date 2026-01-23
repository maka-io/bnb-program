using System.Text.Json;
using BnB.Core.Models;
using BnB.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace BnB.WinForms.Services;

internal static class StringExtensions
{
    public static string? Truncate(this string? value, int maxLength)
    {
        if (string.IsNullOrEmpty(value)) return value;
        return value.Length <= maxLength ? value : value.Substring(0, maxLength);
    }
}

/// <summary>
/// Service to import data from JSON files exported by the Jackcess tool
/// </summary>
public class JsonImportService
{
    private readonly string _jsonFolderPath;
    private readonly BnBDbContext _context;
    private readonly IProgress<string>? _progress;

    public JsonImportService(string jsonFolderPath, BnBDbContext context, IProgress<string>? progress = null)
    {
        _jsonFolderPath = jsonFolderPath;
        _context = context;
        _progress = progress;
    }

    public async Task<MigrationResult> ImportAllAsync()
    {
        var result = new MigrationResult();

        try
        {
            // Import in order respecting foreign key dependencies
            result.TaxRates = await ImportTaxRatesAsync();
            result.TaxPlans = await ImportTaxPlansAsync();
            result.Properties = await ImportPropertiesAsync();
            result.RoomTypes = await ImportRoomTypesAsync();
            result.Guests = await ImportGuestsAsync();
            result.Accommodations = await ImportAccommodationsAsync();
            result.Payments = await ImportPaymentsAsync();
            result.Checks = await ImportChecksAsync();

            result.Success = true;
        }
        catch (Exception ex)
        {
            result.Success = false;
            // Get the innermost exception for actual error details
            var innerEx = ex;
            while (innerEx.InnerException != null)
                innerEx = innerEx.InnerException;
            result.ErrorMessage = $"{ex.Message}\nDetails: {innerEx.Message}";
        }

        return result;
    }

    private void Report(string message) => _progress?.Report(message);

    private async Task<List<JsonElement>> ReadJsonFileAsync(string tableName)
    {
        var filePath = Path.Combine(_jsonFolderPath, $"{tableName}.json");
        if (!File.Exists(filePath))
        {
            Report($"  {tableName}: file not found, skipping");
            return new List<JsonElement>();
        }

        var json = await File.ReadAllTextAsync(filePath);
        var items = JsonSerializer.Deserialize<List<JsonElement>>(json) ?? new List<JsonElement>();
        return items;
    }

    private static string? GetString(JsonElement el, params string[] names)
    {
        foreach (var name in names)
        {
            if (el.TryGetProperty(name, out var prop) && prop.ValueKind == JsonValueKind.String)
                return prop.GetString()?.Trim();
        }
        return null;
    }

    private static int GetInt(JsonElement el, params string[] names)
    {
        foreach (var name in names)
        {
            if (el.TryGetProperty(name, out var prop))
            {
                if (prop.ValueKind == JsonValueKind.Number)
                    return prop.GetInt32();
                if (prop.ValueKind == JsonValueKind.String && int.TryParse(prop.GetString(), out var i))
                    return i;
            }
        }
        return 0;
    }

    private static long GetLong(JsonElement el, params string[] names)
    {
        foreach (var name in names)
        {
            if (el.TryGetProperty(name, out var prop))
            {
                if (prop.ValueKind == JsonValueKind.Number)
                    return prop.GetInt64();
                if (prop.ValueKind == JsonValueKind.String && long.TryParse(prop.GetString(), out var l))
                    return l;
            }
        }
        return 0;
    }

    private static decimal GetDecimal(JsonElement el, params string[] names)
    {
        foreach (var name in names)
        {
            if (el.TryGetProperty(name, out var prop))
            {
                if (prop.ValueKind == JsonValueKind.Number)
                    return prop.GetDecimal();
                if (prop.ValueKind == JsonValueKind.String && decimal.TryParse(prop.GetString(), out var d))
                    return d;
            }
        }
        return 0;
    }

    private static decimal? GetNullableDecimal(JsonElement el, params string[] names)
    {
        foreach (var name in names)
        {
            if (el.TryGetProperty(name, out var prop))
            {
                if (prop.ValueKind == JsonValueKind.Null)
                    continue;
                if (prop.ValueKind == JsonValueKind.Number)
                    return prop.GetDecimal();
                if (prop.ValueKind == JsonValueKind.String && decimal.TryParse(prop.GetString(), out var d))
                    return d;
            }
        }
        return null;
    }

    private static DateTime? GetDateTime(JsonElement el, params string[] names)
    {
        foreach (var name in names)
        {
            if (el.TryGetProperty(name, out var prop))
            {
                if (prop.ValueKind == JsonValueKind.Null)
                    continue;
                if (prop.ValueKind == JsonValueKind.String)
                {
                    var str = prop.GetString();
                    if (DateTime.TryParse(str, out var dt))
                        return dt;
                }
            }
        }
        return null;
    }

    private static bool GetBool(JsonElement el, params string[] names)
    {
        foreach (var name in names)
        {
            if (el.TryGetProperty(name, out var prop))
            {
                if (prop.ValueKind == JsonValueKind.True) return true;
                if (prop.ValueKind == JsonValueKind.False) return false;
                if (prop.ValueKind == JsonValueKind.Number) return prop.GetInt32() != 0;
                if (prop.ValueKind == JsonValueKind.String)
                {
                    var s = prop.GetString()?.ToLower();
                    return s == "true" || s == "1" || s == "-1" || s == "yes";
                }
            }
        }
        return false;
    }

    private async Task<int> ImportTaxRatesAsync()
    {
        Report("Importing Tax Rates...");
        await _context.TaxRates.ExecuteDeleteAsync();

        var items = await ReadJsonFileAsync("taxrates");
        foreach (var el in items)
        {
            var taxRate = new TaxRate
            {
                TaxOne = GetDecimal(el, "tax_one", "TaxOne"),
                TaxOneDescription = GetString(el, "tax_one_desc", "TaxOneDescription"),
                FutureTaxOne = GetNullableDecimal(el, "future_tax_one", "FutureTaxOne"),
                FutureTaxOneEffectiveDate = GetDateTime(el, "tax_one_eff_date", "FutureTaxOneEffectiveDate"),
                TaxTwo = GetDecimal(el, "tax_two", "TaxTwo"),
                TaxTwoDescription = GetString(el, "tax_two_desc", "TaxTwoDescription"),
                FutureTaxTwo = GetNullableDecimal(el, "future_tax_two", "FutureTaxTwo"),
                FutureTaxTwoEffectiveDate = GetDateTime(el, "tax_two_eff_date", "FutureTaxTwoEffectiveDate"),
                TaxThree = GetDecimal(el, "tax_three", "TaxThree"),
                TaxThreeDescription = GetString(el, "tax_three_desc", "TaxThreeDescription"),
                FutureTaxThree = GetNullableDecimal(el, "future_tax_three", "FutureTaxThree"),
                FutureTaxThreeEffectiveDate = GetDateTime(el, "tax_three_eff_date", "FutureTaxThreeEffectiveDate")
            };
            _context.TaxRates.Add(taxRate);
        }

        await _context.SaveChangesAsync();
        Report($"  Tax Rates: {items.Count} imported");
        return items.Count;
    }

    private async Task<int> ImportTaxPlansAsync()
    {
        Report("Importing Tax Plans...");
        await _context.TaxPlans.ExecuteDeleteAsync();

        // Get the global tax rate that was just imported
        var globalTaxRate = await _context.TaxRates.FirstOrDefaultAsync();
        if (globalTaxRate != null)
        {
            Report($"  Found TaxRate: {globalTaxRate.TaxOne}% {globalTaxRate.TaxOneDescription}");
        }
        else
        {
            Report($"  WARNING: No TaxRate found to copy to TaxPlans");
        }

        var items = await ReadJsonFileAsync("taxplan");
        foreach (var el in items)
        {
            var planCode = GetString(el, "plancode", "PlanCode");
            if (string.IsNullOrEmpty(planCode)) continue;

            var taxPlan = new TaxPlan
            {
                PlanCode = planCode,
                PlanTitle = GetString(el, "plan_title", "PlanTitle"),
                Description = GetString(el, "description", "Description")
            };

            // Parse the plan code to set tax application settings
            taxPlan.ParsePlanCode(planCode);

            // Copy tax rates from the global TaxRate record
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
        }

        await _context.SaveChangesAsync();
        Report($"  Tax Plans: {items.Count} imported");
        return items.Count;
    }

    private async Task<int> ImportPropertiesAsync()
    {
        Report("Importing Properties...");
        // Delete in order to respect foreign key constraints
        await _context.Checks.ExecuteDeleteAsync();
        await _context.Accommodations.ExecuteDeleteAsync();
        await _context.RoomTypes.ExecuteDeleteAsync();
        await _context.Properties.ExecuteDeleteAsync();

        var propertyTaxCodes = new HashSet<string>();
        var items = await ReadJsonFileAsync("proptbl");
        foreach (var el in items)
        {
            var taxPlanCode = GetString(el, "tax_plan_code", "TaxPlanCode");
            if (!string.IsNullOrEmpty(taxPlanCode))
                propertyTaxCodes.Add(taxPlanCode);

            var property = new Property
            {
                AccountNumber = GetInt(el, "accountnum", "AccountNumber"),
                Location = GetString(el, "location", "Location") ?? "Unknown",
                FullName = GetString(el, "fullname", "FullName"),
                DBA = GetString(el, "dba", "DBA"),
                PropertyAddress = GetString(el, "propaddress", "propaddr", "PropertyAddress"),
                PropertyCity = GetString(el, "propcity", "PropertyCity"),
                PropertyState = GetString(el, "propstate", "PropertyState"),
                PropertyZipCode = GetString(el, "propzipcode", "propzip", "PropertyZipCode"),
                PropertyPhone = GetString(el, "propphone", "PropertyPhone"),
                PropertyFax = GetString(el, "propfax", "PropertyFax"),
                MailingAddress = GetString(el, "mailaddress", "mailaddr", "MailingAddress"),
                MailingCity = GetString(el, "mailcity", "MailingCity"),
                MailingState = GetString(el, "mailstate", "MailingState"),
                MailingZipCode = GetString(el, "mailzipcode", "mailzip", "MailingZipCode"),
                MailingPhone1 = GetString(el, "mailphone1", "MailingPhone1"),
                MailingPhone2 = GetString(el, "mailphone2", "MailingPhone2"),
                MailingFax = GetString(el, "mailfax", "MailingFax"),
                Email = GetString(el, "email", "Email"),
                WebUrl = GetString(el, "weburl", "WebUrl"),
                CheckTo = GetString(el, "check_to", "checkto", "CheckTo"),
                PercentToHost = GetDecimal(el, "perdirect", "PercentToHost"),
                FuturePercent = GetNullableDecimal(el, "futurepercent", "FuturePercent"),
                FuturePercentDate = GetDateTime(el, "futuredate", "FuturePercentDate"),
                GrossRatePercent = GetNullableDecimal(el, "grosratepercent", "grosspercent", "GrossRatePercent"),
                FederalTaxId = GetString(el, "federaltaxid", "fedtaxid", "FederalTaxId"),
                TaxPlanCode = taxPlanCode,
                DepositRequired = GetString(el, "depositreq", "DepositRequired"),
                Exceptions = GetString(el, "exceptions", "Exceptions"),
                ExceptionsDescription = GetString(el, "exceptions_desc", "ExceptionsDescription"),
                IsObsolete = GetBool(el, "propobsolete", "obsolete", "IsObsolete"),
                SuppressFlag = GetBool(el, "suppressflag", "suppress", "SuppressFlag"),
                Comments = GetString(el, "comments", "Comments")
            };
            _context.Properties.Add(property);
        }

        await _context.SaveChangesAsync();

        // Create missing tax plans for any property tax codes that don't exist
        await CreateMissingTaxPlansAsync(propertyTaxCodes);

        Report($"  Properties: {items.Count} imported");
        return items.Count;
    }

    private async Task CreateMissingTaxPlansAsync(HashSet<string> requiredCodes)
    {
        if (requiredCodes.Count == 0) return;

        var existingCodes = await _context.TaxPlans.Select(tp => tp.PlanCode).ToListAsync();
        var missingCodes = requiredCodes.Where(c => !existingCodes.Contains(c)).ToList();

        if (missingCodes.Count == 0) return;

        // Get an existing tax plan to copy rates from
        var templatePlan = await _context.TaxPlans.FirstOrDefaultAsync();
        if (templatePlan == null)
        {
            Report($"  WARNING: Cannot create missing tax plans - no template plan exists");
            return;
        }

        foreach (var code in missingCodes)
        {
            var newPlan = new TaxPlan
            {
                PlanCode = code,
                PlanTitle = $"Auto-created for code {code}",
                Tax1Rate = templatePlan.Tax1Rate,
                Tax1Description = templatePlan.Tax1Description,
                FutureTax1Rate = templatePlan.FutureTax1Rate,
                FutureTax1EffectiveDate = templatePlan.FutureTax1EffectiveDate,
                Tax2Rate = templatePlan.Tax2Rate,
                Tax2Description = templatePlan.Tax2Description,
                FutureTax2Rate = templatePlan.FutureTax2Rate,
                FutureTax2EffectiveDate = templatePlan.FutureTax2EffectiveDate,
                Tax3Rate = templatePlan.Tax3Rate,
                Tax3Description = templatePlan.Tax3Description,
                FutureTax3Rate = templatePlan.FutureTax3Rate,
                FutureTax3EffectiveDate = templatePlan.FutureTax3EffectiveDate
            };
            // Parse the code to set application settings (Net/Gross/N/A)
            newPlan.ParsePlanCode(code);
            _context.TaxPlans.Add(newPlan);
        }

        await _context.SaveChangesAsync();
        Report($"  Created {missingCodes.Count} missing tax plan(s): {string.Join(", ", missingCodes)}");
    }

    private async Task<int> ImportRoomTypesAsync()
    {
        Report("Importing Room Types...");
        var validProperties = await _context.Properties.Select(p => p.AccountNumber).ToListAsync();

        // Try roomtbl first
        var items = await ReadJsonFileAsync("roomtbl");
        bool isLinkTable = false;

        if (items.Count == 0)
        {
            // Try HostAccount_RoomType_Link table (actual table name used in original VB5 app)
            items = await ReadJsonFileAsync("hostaccount_roomtype_link");
            isLinkTable = true;
        }

        var count = 0;
        foreach (var el in items)
        {
            var accountNum = GetInt(el, "accountnum", "AccountNum", "AccountNumber");
            if (!validProperties.Contains(accountNum)) continue;

            string name;
            string? description;

            if (isLinkTable)
            {
                // HostAccount_RoomType_Link uses RoomType (integer) and RoomType_Desc columns
                var roomTypeNum = GetInt(el, "RoomType", "roomtype");
                name = roomTypeNum > 0 ? roomTypeNum.ToString() : "Room";
                description = GetString(el, "RoomType_Desc", "roomtype_desc", "Description");
            }
            else
            {
                // Other table formats use unitname/roomname columns
                name = GetString(el, "unitname", "roomname", "Name") ?? "Room";
                description = GetString(el, "description", "unitnamedesc", "Description");
            }

            var roomType = new RoomType
            {
                PropertyAccountNumber = accountNum,
                Name = name,
                Description = description,
                DefaultRate = GetNullableDecimal(el, "rate", "defaultrate", "DefaultRate")
            };
            _context.RoomTypes.Add(roomType);
            count++;
        }

        await _context.SaveChangesAsync();
        Report($"  Room Types: {count} imported");
        return count;
    }

    // Maps legacy confirmation number to new Guest.Id for use by dependent tables
    private Dictionary<long, int> _legacyConfToGuestId = new();

    private async Task<int> ImportGuestsAsync()
    {
        Report("Importing Guests...");
        _legacyConfToGuestId.Clear();

        // Delete in order to respect foreign key constraints
        await _context.Payments.ExecuteDeleteAsync();
        await _context.Checks.ExecuteDeleteAsync();
        await _context.Accommodations.ExecuteDeleteAsync();
        await _context.Guests.ExecuteDeleteAsync();

        var items = await ReadJsonFileAsync("guesttbl");
        var count = 0;

        foreach (var el in items)
        {
            var legacyConf = GetLong(el, "conf", "ConfirmationNumber");

            var guest = new Guest
            {
                // Id is auto-generated - no ConfirmationNumber on Guest anymore
                FirstName = GetString(el, "f_name", "fname", "FirstName") ?? "",
                LastName = GetString(el, "l_name", "lname", "LastName") ?? "",
                Address = GetString(el, "address", "addr", "Address"),
                BusinessAddress = GetString(el, "busadd", "busaddress", "BusinessAddress"),
                City = GetString(el, "city", "City"),
                State = GetString(el, "state", "State"),
                ZipCode = GetString(el, "zipcode", "zip", "ZipCode"),
                Country = GetString(el, "country", "Country"),
                HomePhone = GetString(el, "hmphone", "homephone", "HomePhone"),
                BusinessPhone = GetString(el, "bsphone", "busphone", "BusinessPhone"),
                FaxNumber = GetString(el, "faxnum", "fax", "FaxNumber"),
                Email = GetString(el, "email", "Email"),
                BookedBy = GetString(el, "bookedby", "BookedBy"),
                Referral = GetString(el, "referral", "Referral")?.Truncate(100),
                // ReservationFee moved to Accommodation
                TravelingWith = GetString(el, "travwith", "travelingwith", "TravelingWith")?.Truncate(200),
                Comments = GetString(el, "cmmnts", "comments", "Comments")?.Truncate(2000),
                LabelFlag = GetBool(el, "lbl_flag", "LabelFlag"),
                Closure = GetString(el, "closeure", "closure", "Closure")?.Truncate(2000),
                EntryDate = GetDateTime(el, "entrydate", "EntryDate"),
                EntryUser = GetString(el, "entryuser", "EntryUser"),
                UpdateDate = GetDateTime(el, "updatedate", "UpdateDate"),
                UpdateUser = GetString(el, "updateuser", "UpdateUser"),
                RevisionDate = GetDateTime(el, "revdate", "RevisionDate"),
                Revision = GetInt(el, "revision", "Revision")
            };
            _context.Guests.Add(guest);
            await _context.SaveChangesAsync();

            // Map the legacy confirmation number to the new Guest.Id
            _legacyConfToGuestId[legacyConf] = guest.Id;

            count++;

            if (count % 100 == 0)
            {
                Report($"  Guests: {count} imported...");
            }
        }

        Report($"  Guests: {count} imported");
        return count;
    }

    private async Task<int> ImportAccommodationsAsync()
    {
        Report("Importing Accommodations...");
        var validProperties = await _context.Properties.Select(p => p.AccountNumber).ToListAsync();

        var items = await ReadJsonFileAsync("bbtbl");
        var count = 0;
        var skipped = 0;

        foreach (var el in items)
        {
            var conf = GetLong(el, "conf", "ConfirmationNumber");
            var accountNum = GetInt(el, "accountnum", "AccountNumber");

            // Skip if foreign keys don't exist - use the legacy conf to guest id mapping
            if (!_legacyConfToGuestId.TryGetValue(conf, out var guestId))
            {
                skipped++;
                continue;
            }
            if (!validProperties.Contains(accountNum))
            {
                skipped++;
                continue;
            }

            try
            {
                var accommodation = new Accommodation
                {
                    ConfirmationNumber = conf,  // This is now the booking/reservation number
                    GuestId = guestId,  // FK to Guest.Id
                    PropertyAccountNumber = accountNum,
                    FirstName = GetString(el, "f_name", "fname", "FirstName")?.Truncate(50),
                    LastName = GetString(el, "l_name", "lname", "LastName")?.Truncate(50),
                    Location = GetString(el, "location", "Location")?.Truncate(100),
                    ArrivalDate = GetDateTime(el, "arrdate", "ArrivalDate") ?? DateTime.Today,
                    DepartureDate = GetDateTime(el, "depdate", "DepartureDate") ?? DateTime.Today,
                    NumberOfNights = GetInt(el, "numnites", "numnights", "NumberOfNights"),
                    NumberInParty = GetInt(el, "numpty", "numinparty", "NumberInParty"),
                    UnitName = GetString(el, "unitname", "UnitName")?.Truncate(50),
                    UnitNameDescription = GetString(el, "unitnamedesc", "UnitNameDescription")?.Truncate(200),
                    DailyGrossRate = GetNullableDecimal(el, "grosrate", "dailygrossrate", "DailyGrossRate"),
                    DailyNetRate = GetNullableDecimal(el, "netrate", "dailynetrate", "DailyNetRate"),
                    TotalGrossWithTax = GetNullableDecimal(el, "gwtax", "totgrosswithtax", "TotalGrossWithTax"),
                    TotalNetWithTax = GetNullableDecimal(el, "nwtax", "totnetwithtax", "TotalNetWithTax"),
                    TotalTax = GetNullableDecimal(el, "tax", "tottax", "TotalTax"),
                    Tax1 = GetNullableDecimal(el, "tax1", "Tax1"),
                    Tax2 = GetNullableDecimal(el, "tax2", "Tax2"),
                    Tax3 = GetNullableDecimal(el, "tax3", "Tax3"),
                    ServiceFee = GetNullableDecimal(el, "svcharge", "servicefee", "ServiceFee"),
                    Commission = GetDecimal(el, "commish", "commission", "Commission"),
                    CommissionPaid = GetNullableDecimal(el, "comm_paid", "commissionpaid", "CommissionPaid"),
                    CommissionReceived = GetNullableDecimal(el, "com_rcvd", "commissionreceived", "CommissionReceived"),
                    PaymentType = GetString(el, "pymttype", "paymenttype", "PaymentType")?.Truncate(20) ?? "Prepay",
                    OverridePercentToHost = GetNullableDecimal(el, "percnt", "OverridePercentToHost"),
                    OverrideTaxPlanCode = GetString(el, "tax_plan_code", "OverrideTaxPlanCode")?.Truncate(10),
                    UseManualAmounts = GetBool(el, "fillincalcamounts", "UseManualAmounts"),
                    Suppress = GetBool(el, "suppress", "Suppress"),
                    Notified = GetBool(el, "notified", "Notified"),
                    Forfeit = GetBool(el, "forfeit", "Forfeit"),
                    Comments = GetString(el, "cmmnts", "comments", "Comments")?.Truncate(2000),
                    NightNotes = GetString(el, "nnotes", "nightnotes", "NightNotes")?.Truncate(2000),
                    EntryDate = GetDateTime(el, "entrydate", "EntryDate"),
                    EntryUser = GetString(el, "entryuser", "EntryUser")?.Truncate(50),
                    UpdateDate = GetDateTime(el, "updatedate", "UpdateDate"),
                    UpdateUser = GetString(el, "updateuser", "UpdateUser")?.Truncate(50),
                    RevisionDate = GetDateTime(el, "rev_date", "RevisionDate")
                };
                _context.Accommodations.Add(accommodation);
                await _context.SaveChangesAsync();
                count++;

                if (count % 100 == 0)
                {
                    Report($"  Accommodations: {count} imported...");
                }
            }
            catch (Microsoft.EntityFrameworkCore.DbUpdateException dbEx)
            {
                var sqliteError = dbEx.InnerException?.Message ?? dbEx.Message;
                throw new Exception($"Failed at conf {conf}: {sqliteError}", dbEx);
            }
            catch (Exception ex)
            {
                var innerEx = ex;
                while (innerEx.InnerException != null)
                    innerEx = innerEx.InnerException;
                throw new Exception($"Failed at conf {conf}: {innerEx.Message} (Type: {innerEx.GetType().Name})", ex);
            }
        }

        Report($"  Accommodations: {count} imported, {skipped} skipped (no matching guest/property)");
        return count;
    }

    private async Task<int> ImportPaymentsAsync()
    {
        Report("Importing Payments...");

        // First, read payment due information from payment.json (one record per guest)
        var paymentDues = new Dictionary<long, JsonElement>();
        var dueItems = await ReadJsonFileAsync("payment");
        foreach (var el in dueItems)
        {
            var conf = GetLong(el, "conf", "ConfirmationNumber");
            if (_legacyConfToGuestId.ContainsKey(conf))
            {
                paymentDues[conf] = el;
            }
        }
        Report($"  Payment dues loaded: {paymentDues.Count}");

        // Now read actual payments received from paymentreceived.json
        var items = await ReadJsonFileAsync("paymentreceived");
        var count = 0;
        var processedConfs = new HashSet<long>();

        foreach (var el in items)
        {
            var conf = GetLong(el, "conf", "ConfirmationNumber");
            // Skip if no matching guest exists
            if (!_legacyConfToGuestId.TryGetValue(conf, out var guestId)) continue;

            // Get due info for this guest (if available and not yet added)
            decimal? depositDue = null, prepaymentDue = null, cancellationFee = null, refundOwed = null, otherCredit = null, defaultComm = null;
            DateTime? depositDueDate = null, prepaymentDueDate = null, cancellationFeeDueDate = null;
            string? dueComments = null;

            // Only add due info to the first payment record for each guest
            if (!processedConfs.Contains(conf) && paymentDues.TryGetValue(conf, out var dueEl))
            {
                depositDue = GetNullableDecimal(dueEl, "depdue", "DepositDue");
                depositDueDate = GetDateTime(dueEl, "depdate", "DepositDueDate");
                prepaymentDue = GetNullableDecimal(dueEl, "predue", "PrepaymentDue");
                prepaymentDueDate = GetDateTime(dueEl, "predate", "PrepaymentDueDate");
                cancellationFee = GetNullableDecimal(dueEl, "canclfee", "CancellationFee");
                cancellationFeeDueDate = GetDateTime(dueEl, "canclfeedatedue", "CancellationFeeDueDate");
                refundOwed = GetNullableDecimal(dueEl, "RefundOwed", "refundowed");
                otherCredit = GetNullableDecimal(dueEl, "OtherCredit", "othercredit");
                defaultComm = GetNullableDecimal(dueEl, "defcom", "DefaultCommission");
                dueComments = GetString(dueEl, "cmmnts", "comments", "Comments");
                processedConfs.Add(conf);
            }

            var payment = new Payment
            {
                GuestId = guestId,  // FK to Guest.Id
                ConfirmationNumber = conf,  // The booking/reservation number
                FirstName = GetString(el, "f_name", "fname", "FirstName"),
                LastName = GetString(el, "l_name", "lname", "LastName"),
                Amount = GetDecimal(el, "AmountReceived", "amountreceived", "amount", "Amount"),
                // Use deposit due date as fallback, or a historical sentinel date for unknown dates
                PaymentDate = GetDateTime(el, "DateReceived", "datereceived", "paymentdate", "PaymentDate")
                    ?? depositDueDate
                    ?? new DateTime(2000, 1, 1),
                CheckNumber = GetString(el, "CheckNumber", "checknumber", "checknum"),
                ReceivedFrom = GetString(el, "ReceivedFrom", "receivedfrom"),
                AppliedTo = GetString(el, "AppliedTo", "appliedto"),
                DepositDue = depositDue,
                DepositDueDate = depositDueDate,
                PrepaymentDue = prepaymentDue,
                PrepaymentDueDate = prepaymentDueDate,
                CancellationFee = cancellationFee,
                CancellationFeeDueDate = cancellationFeeDueDate,
                RefundOwed = refundOwed,
                OtherCredit = otherCredit,
                DefaultCommission = defaultComm,
                Comments = GetString(el, "Comments", "comments") ?? dueComments
            };
            _context.Payments.Add(payment);
            count++;
        }

        await _context.SaveChangesAsync();
        Report($"  Payments: {count} imported");
        return count;
    }

    private async Task<int> ImportChecksAsync()
    {
        Report("Importing Checks...");
        var accommodations = await _context.Accommodations
            .Select(a => new { a.Id, a.ConfirmationNumber, a.PropertyAccountNumber })
            .ToListAsync();

        var items = await ReadJsonFileAsync("checktbl");
        var count = 0;

        foreach (var el in items)
        {
            var conf = GetLong(el, "conf", "ConfirmationNumber");
            var accountNum = GetInt(el, "accountnum", "AccountNumber");

            var accom = accommodations.FirstOrDefault(a =>
                a.ConfirmationNumber == conf && a.PropertyAccountNumber == accountNum);

            if (accom == null) continue;

            var check = new Check
            {
                AccommodationId = accom.Id,
                CheckNumber = GetString(el, "checknum", "CheckNumber") ?? "",
                Amount = GetDecimal(el, "amount", "Amount"),
                CheckDate = GetDateTime(el, "checkdate", "CheckDate"),
                PayableTo = GetString(el, "payableto", "payto", "PayableTo"),
                Memo = GetString(el, "memo", "Memo"),
                IsVoid = GetBool(el, "void_chk", "voidchk", "IsVoid"),
                Comments = GetString(el, "comments", "Comments")
            };
            _context.Checks.Add(check);
            count++;
        }

        await _context.SaveChangesAsync();
        Report($"  Checks: {count} imported");
        return count;
    }
}
