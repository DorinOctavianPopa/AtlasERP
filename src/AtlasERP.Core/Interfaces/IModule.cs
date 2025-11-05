namespace AtlasERP.Core.Interfaces;

/// <summary>
/// Interface for modular components in the AtlasERP system
/// </summary>
public interface IModule
{
    /// <summary>
    /// Unique identifier for the module
    /// </summary>
    string ModuleId { get; }

    /// <summary>
    /// Display name of the module
    /// </summary>
    string ModuleName { get; }

    /// <summary>
    /// Description of the module's functionality
    /// </summary>
    string Description { get; }

    /// <summary>
    /// Icon identifier for the module
    /// </summary>
    string Icon { get; }

    /// <summary>
    /// Order for module display
    /// </summary>
    int DisplayOrder { get; }

    /// <summary>
    /// Initialize the module
    /// </summary>
    void Initialize();

    /// <summary>
    /// Get the main view for this module
    /// </summary>
    Type GetMainViewType();
}
