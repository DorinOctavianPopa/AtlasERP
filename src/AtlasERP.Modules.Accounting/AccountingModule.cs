using AtlasERP.Core;

namespace AtlasERP.Modules.Accounting;

public class AccountingModule : ModuleBase
{
    public override string ModuleId => "accounting";
    public override string ModuleName => "Accounting";
    public override string Description => "Financial management and reporting";
    public override string Icon => "📊";
    public override int DisplayOrder => 3;

    public override Type GetMainViewType()
    {
        return typeof(AccountingModule);
    }
}
