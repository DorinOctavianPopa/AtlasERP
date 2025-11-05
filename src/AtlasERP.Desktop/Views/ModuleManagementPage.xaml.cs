using AtlasERP.Desktop.ViewModels;
using Microsoft.Maui.Controls;

namespace AtlasERP.Desktop.Views;

public partial class ModuleManagementPage : ContentPage
{
    public ModuleManagementPage(ModuleManagementPageViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}
