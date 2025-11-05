using AtlasERP.Core;

namespace AtlasERP.Modules.Sales;

public class SalesModule : ModuleBase
{
    public override string ModuleId => "sales";
    public override string ModuleName => "Sales";
    public override string Description => "Track sales, orders, and customer relationships";
    public override string Icon => "💰";
    public override int DisplayOrder => 2;

    public override Type GetMainViewType()
    {
        return typeof(SalesModule);
    }
}
