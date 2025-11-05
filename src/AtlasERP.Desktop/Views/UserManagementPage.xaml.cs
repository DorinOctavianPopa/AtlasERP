using AtlasERP.Desktop.ViewModels;
using Microsoft.Maui.Controls;

namespace AtlasERP.Desktop.Views;

public partial class UserManagementPage : ContentPage
{
    public UserManagementPage(UserManagementPageViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}
