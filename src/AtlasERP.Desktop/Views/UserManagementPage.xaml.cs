using AtlasERP.Desktop.ViewModels;

namespace AtlasERP.Desktop.Views;

public partial class UserManagementPage : ContentPage
{
    public UserManagementPage(UserManagementPageViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}
