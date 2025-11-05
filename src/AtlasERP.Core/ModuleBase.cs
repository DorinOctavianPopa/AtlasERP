using AtlasERP.Core.Interfaces;

namespace AtlasERP.Core;

/// <summary>
/// Base implementation for modules
/// </summary>
public abstract class ModuleBase : IModule
{
    public abstract string ModuleId { get; }
    public abstract string ModuleName { get; }
    public abstract string Description { get; }
    public abstract string Icon { get; }
    public abstract int DisplayOrder { get; }

    public virtual void Initialize()
    {
        // Base initialization logic
    }

    public abstract Type GetMainViewType();
}
