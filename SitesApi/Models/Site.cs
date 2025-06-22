namespace SitesApi.Models;

public class Site
{
    public int SiteId { get; set; }
    public string SiteCode { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int? SupplierId { get; set; }
    public string? ShiftStatus { get; set; }
    public bool IsActive { get; set; }
}
