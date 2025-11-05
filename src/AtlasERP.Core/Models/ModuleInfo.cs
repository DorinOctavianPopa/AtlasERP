namespace AtlasERP.Core.Models;

/// <summary>
/// Module information
/// </summary>
public class ModuleInfo
{
    public string Id { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Icon { get; set; } = string.Empty;
    public int DisplayOrder { get; set; }
    public bool IsEnabled { get; set; } = true;
}
