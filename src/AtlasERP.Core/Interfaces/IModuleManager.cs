namespace AtlasERP.Core.Interfaces;

/// <summary>
/// Service for managing modules
/// </summary>
public interface IModuleManager
{
    /// <summary>
    /// Register a module
    /// </summary>
    void RegisterModule(IModule module);

    /// <summary>
    /// Get all registered modules
    /// </summary>
    IEnumerable<IModule> GetModules();

    /// <summary>
    /// Get a module by its ID
    /// </summary>
    IModule? GetModule(string moduleId);

    /// <summary>
    /// Initialize all modules
    /// </summary>
    void InitializeModules();
}
