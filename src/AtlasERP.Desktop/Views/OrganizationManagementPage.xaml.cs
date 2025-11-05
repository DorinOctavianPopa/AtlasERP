using AtlasERP.Desktop.ViewModels;
using Microsoft.Maui.Controls;

namespace AtlasERP.Desktop.Views;

public partial class OrganizationManagementPage : ContentPage
{
    public OrganizationManagementPage(OrganizationManagementPageViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}
