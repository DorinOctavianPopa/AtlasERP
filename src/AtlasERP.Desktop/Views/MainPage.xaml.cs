using AtlasERP.Desktop.ViewModels;
using Microsoft.Maui;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;

namespace AtlasERP.Desktop.Views;

public partial class MainPage : ContentPage
{
    public MainPage(MainPageViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }

    private void OnPointerEntered(object sender, PointerEventArgs e)
    {
        if (sender is Grid grid)
        {
            grid.BackgroundColor = Application.Current?.RequestedTheme == Microsoft.Maui.ApplicationModel.AppTheme.Dark
                ? Color.FromRgba("#2A2A2A")
                : Color.FromRgba("#F5F5F5");
        }
    }

    private void OnPointerExited(object sender, PointerEventArgs e)
    {
        if (sender is Grid grid)
        {
            grid.BackgroundColor = Colors.Transparent;
        }
    }
}
