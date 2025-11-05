using AtlasERP.Core.Interfaces;
using Prism.Commands;
using Prism.Navigation;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace AtlasERP.Desktop.ViewModels;

public class MainPageViewModel : ViewModelBase, INavigatedAware
{
    private readonly IAuthenticationService _authService;
    private readonly IModuleManager _moduleManager;
    private readonly INavigationService _navigationService;

    private string _welcomeMessage = string.Empty;
    public string WelcomeMessage
    {
        get => _welcomeMessage;
        set => SetProperty(ref _welcomeMessage, value);
    }

    public ObservableCollection<MenuItem> MenuItems { get; } = new();

    public ICommand NavigateCommand { get; }
    public ICommand LogoutCommand { get; }

    public MainPageViewModel(
        IAuthenticationService authService,
        IModuleManager moduleManager,
        INavigationService navigationService)
    {
        _authService = authService;
        _moduleManager = moduleManager;
        _navigationService = navigationService;
        Title = "AtlasERP - Main";

        NavigateCommand = new DelegateCommand<string>(async (page) => await ExecuteNavigateCommand(page));
        LogoutCommand = new DelegateCommand(async () => await ExecuteLogoutCommand());

        InitializeMenu();
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

    private async Task ExecuteNavigateCommand(string? page)
    {
        if (!string.IsNullOrEmpty(page))
        {
            await _navigationService.NavigateAsync(page);
        }
    }

    private async Task ExecuteLogoutCommand()
    {
        await _authService.LogoutAsync();
        await _navigationService.NavigateAsync("/NavigationPage/LoginPage");
    }

    public void OnNavigatedFrom(INavigationParameters parameters)
    {
    }

    public void OnNavigatedTo(INavigationParameters parameters)
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
