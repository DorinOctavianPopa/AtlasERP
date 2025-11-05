using AtlasERP.Desktop.ViewModels;
using Microsoft.Maui.Controls;

namespace AtlasERP.Desktop.Views;

public partial class DashboardPage : ContentPage
{
    public DashboardPage(DashboardPageViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}
