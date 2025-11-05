using AtlasERP.Core;

namespace AtlasERP.Modules.Inventory;

public class InventoryModule : ModuleBase
{
    public override string ModuleId => "inventory";
    public override string ModuleName => "Inventory";
    public override string Description => "Manage your inventory, stock levels, and warehouses";
    public override string Icon => "📦";
    public override int DisplayOrder => 1;

    public override Type GetMainViewType()
    {
        // In a real implementation, this would return the actual view type
        // For now, return a placeholder type
        return typeof(InventoryModule);
    }
}
