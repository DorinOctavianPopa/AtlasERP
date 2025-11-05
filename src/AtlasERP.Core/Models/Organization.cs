namespace AtlasERP.Core.Models;

/// <summary>
/// Represents an organization in the system
/// </summary>
public class Organization
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string? Name { get; set; }
    public string? Description { get; set; }
    public string? Address { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Email { get; set; }
    public bool IsActive { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public List<string> EnabledModules { get; set; } = new();
}
