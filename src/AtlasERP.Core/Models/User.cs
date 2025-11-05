namespace AtlasERP.Core.Models;

/// <summary>
/// Represents a user in the system
/// </summary>
public class User
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string? Username { get; set; }
    public string? Email { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string FullName => $"{FirstName} {LastName}";
    public string? Role { get; set; }
    public bool IsActive { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? LastLoginAt { get; set; }
    public string? OrganizationId { get; set; }
}
