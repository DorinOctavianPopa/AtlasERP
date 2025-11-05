using AtlasERP.Core.Interfaces;
using AtlasERP.Core.Models;
using Prism.Commands;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace AtlasERP.Desktop.ViewModels;

public class ModuleManagementPageViewModel : ViewModelBase
{
    private readonly IModuleManager _moduleManager;

    public ObservableCollection<ModuleInfo> Modules { get; } = new();

    public ICommand ToggleModuleCommand { get; }

    public ModuleManagementPageViewModel(IModuleManager moduleManager)
    {
        _moduleManager = moduleManager;
        Title = "Module Management";

        ToggleModuleCommand = new DelegateCommand<ModuleInfo>(ExecuteToggleModule);

        LoadModules();
    }

    private void LoadModules()
    {
        var registeredModules = _moduleManager.GetModules();

        foreach (var module in registeredModules)
        {
            Modules.Add(new ModuleInfo
            {
                Id = module.ModuleId,
                Name = module.ModuleName,
                Description = module.Description,
                Icon = module.Icon,
                DisplayOrder = module.DisplayOrder,
                IsEnabled = true
            });
        }

        // Add some placeholder modules
        if (Modules.Count == 0)
        {
            Modules.Add(new ModuleInfo
            {
                Id = "inventory",
                Name = "Inventory",
                Description = "Manage your inventory, stock levels, and warehouses",
                Icon = "📦",
                DisplayOrder = 1,
                IsEnabled = true
            });

            Modules.Add(new ModuleInfo
            {
                Id = "sales",
                Name = "Sales",
                Description = "Track sales, orders, and customer relationships",
                Icon = "💰",
                DisplayOrder = 2,
                IsEnabled = true
            });

            Modules.Add(new ModuleInfo
            {
                Id = "accounting",
                Name = "Accounting",
                Description = "Financial management and reporting",
                Icon = "📊",
                DisplayOrder = 3,
                IsEnabled = true
            });

            Modules.Add(new ModuleInfo
            {
                Id = "hr",
                Name = "Human Resources",
                Description = "Employee management, payroll, and benefits",
                Icon = "👥",
                DisplayOrder = 4,
                IsEnabled = true
            });
        }
    }

    private void ExecuteToggleModule(ModuleInfo? module)
    {
        if (module != null)
        {
            module.IsEnabled = !module.IsEnabled;
        }
    }
}
