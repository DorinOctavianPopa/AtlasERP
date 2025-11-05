using AtlasERP.Core.Interfaces;

namespace AtlasERP.Core.Services;

/// <summary>
/// Module manager implementation
/// </summary>
public class ModuleManager : IModuleManager
{
    private readonly List<IModule> _modules = new();

    public void RegisterModule(IModule module)
    {
        if (!_modules.Any(m => m.ModuleId == module.ModuleId))
        {
            _modules.Add(module);
        }
    }

    public IEnumerable<IModule> GetModules()
    {
        return _modules.OrderBy(m => m.DisplayOrder);
    }

    public IModule? GetModule(string moduleId)
    {
        return _modules.FirstOrDefault(m => m.ModuleId == moduleId);
    }

    public void InitializeModules()
    {
        foreach (var module in _modules)
        {
            module.Initialize();
        }
    }
}
