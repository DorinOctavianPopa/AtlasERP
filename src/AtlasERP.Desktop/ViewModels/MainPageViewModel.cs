using AtlasERP.Core.Interfaces;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace AtlasERP.Desktop.ViewModels;

public partial class MainPageViewModel : ViewModelBase
{
    private readonly IAuthenticationService _authService;
    private readonly IModuleManager _moduleManager;
    private readonly IServiceProvider _serviceProvider;

    [ObservableProperty]
    private string _welcomeMessage = string.Empty;

    public ObservableCollection<MenuItem> MenuItems { get; } = new();

    public MainPageViewModel(
        IAuthenticationService authService,
        IModuleManager moduleManager,
        IServiceProvider serviceProvider)
    {
        _authService = authService;
        _moduleManager = moduleManager;
        _serviceProvider = serviceProvider;
        Title = "AtlasERP - Main";

        InitializeMenu();
        UpdateWelcomeMessage();
    }

    private void InitializeMenu()
    {
        MenuItems.Clear();

        // Management Section
        MenuItems.Add(new MenuItem
        {
            Title = "Dashboard",
            Icon = "📊",
            NavigationPage = "DashboardPage",
            Section = "Overview"
        });

        MenuItems.Add(new MenuItem
        {
            Title = "User Management",
            Icon = "👥",
            NavigationPage = "UserManagementPage",
            Section = "Administration"
        });

        MenuItems.Add(new MenuItem
        {
            Title = "Organization Management",
            Icon = "🏢",
            NavigationPage = "OrganizationManagementPage",
            Section = "Administration"
        });

        MenuItems.Add(new MenuItem
        {
            Title = "Module Management",
            Icon = "⚙️",
            NavigationPage = "ModuleManagementPage",
            Section = "Administration"
        });

        // Modules Section - Dynamic based on registered modules
        var modules = _moduleManager.GetModules();
        foreach (var module in modules)
        {
            MenuItems.Add(new MenuItem
            {
                Title = module.ModuleName,
                Icon = module.Icon,
                NavigationPage = module.GetMainViewType().Name,
                Section = "Modules"
            });
        }
    }

    [RelayCommand]
    private async Task NavigateAsync(string? page)
    {
        if (!string.IsNullOrEmpty(page) && Application.Current?.Windows[0].Page?.Navigation != null)
        {
            var pageType = Type.GetType($"AtlasERP.Desktop.Views.{page}, AtlasERP.Desktop");
            if (pageType != null)
            {
                var pageInstance = _serviceProvider.GetService(pageType) as Page;
                if (pageInstance != null)
                {
                    await Application.Current.Windows[0].Page.Navigation.PushAsync(pageInstance);
                }
            }
        }
    }

    [RelayCommand]
    private async Task LogoutAsync()
    {
        await _authService.LogoutAsync();
        
        if (Application.Current?.Windows.FirstOrDefault()?.Page is NavigationPage navPage)
        {
            await navPage.PopToRootAsync();
        }
    }

    private void UpdateWelcomeMessage()
    {
        if (_authService.CurrentUser != null)
        {
            WelcomeMessage = $"Welcome, {_authService.CurrentUser.FullName}!";
        }
    }
}

public class MenuItem
{
    public string Title { get; set; } = string.Empty;
    public string Icon { get; set; } = string.Empty;
    public string NavigationPage { get; set; } = string.Empty;
    public string Section { get; set; } = string.Empty;
}
