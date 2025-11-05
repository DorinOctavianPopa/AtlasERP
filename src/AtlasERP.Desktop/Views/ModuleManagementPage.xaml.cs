using AtlasERP.Desktop.ViewModels;

namespace AtlasERP.Desktop.Views;

public partial class ModuleManagementPage : ContentPage
{
    public ModuleManagementPage(ModuleManagementPageViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}
