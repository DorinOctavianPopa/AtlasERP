using AtlasERP.Desktop.ViewModels;

namespace AtlasERP.Desktop.Views;

public partial class DashboardPage : ContentPage
{
    public DashboardPage(DashboardPageViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}
