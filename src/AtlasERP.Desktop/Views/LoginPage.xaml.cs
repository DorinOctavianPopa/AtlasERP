using AtlasERP.Desktop.ViewModels;

namespace AtlasERP.Desktop.Views;

public partial class LoginPage : ContentPage
{
    public LoginPage(LoginPageViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}
