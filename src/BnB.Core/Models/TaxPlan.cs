namespace BnB.Core.Models;

/// <summary>
/// Tax plan configuration - maps to taxplan table in legacy database
/// </summary>
public class TaxPlan
{
    public int Id { get; set; }
    public string PlanCode { get; set; } = string.Empty;  // plancode
    public string? PlanTitle { get; set; }  // plan_title
    public string? Description { get; set; }
}
