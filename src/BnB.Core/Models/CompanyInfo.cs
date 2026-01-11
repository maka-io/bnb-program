namespace BnB.Core.Models;

/// <summary>
/// Company information - maps to usercompanyinfo table in legacy database
/// Stores the BnB company's own information for reports/letterhead
/// </summary>
public class CompanyInfo
{
    public int Id { get; set; }
    public string? CompanyName { get; set; }
    public string? Address { get; set; }
    public string? City { get; set; }
    public string? State { get; set; }
    public string? ZipCode { get; set; }
    public string? Phone { get; set; }
    public string? Fax { get; set; }
    public string? Email { get; set; }
    public string? WebUrl { get; set; }
}
