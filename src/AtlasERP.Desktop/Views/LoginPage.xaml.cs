using AtlasERP.Desktop.ViewModels;
using Microsoft.Maui.Controls;

namespace AtlasERP.Desktop.Views;

public partial class LoginPage : ContentPage
{
    public LoginPage(LoginPageViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}
