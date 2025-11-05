namespace AtlasERP.Core.Models;

/// <summary>
/// Module information
/// </summary>
public class ModuleInfo
{
    public string? Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public string? Icon { get; set; }
    public int DisplayOrder { get; set; }
    public bool IsEnabled { get; set; }
}
