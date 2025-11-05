using AtlasERP.Core;

namespace AtlasERP.Modules.HR;

public class HRModule : ModuleBase
{
    public override string ModuleId => "hr";
    public override string ModuleName => "Human Resources";
    public override string Description => "Employee management, payroll, and benefits";
    public override string Icon => "👥";
    public override int DisplayOrder => 4;

    public override Type GetMainViewType()
    {
        return typeof(HRModule);
    }
}
