using AtlasERP.Core.Interfaces;
using AtlasERP.Core.Services;
using AtlasERP.Desktop.ViewModels;
using AtlasERP.Desktop.Views;
using CommunityToolkit.Maui;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Maui.Controls.Hosting;
using Microsoft.Maui.Hosting;

namespace AtlasERP.Desktop;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .UseMauiCommunityToolkit()
            .ConfigureFonts(fonts =>
            {
                // Using default system fonts instead of custom fonts for now
                // fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                // fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

#if DEBUG
        builder.Logging.AddDebug();
#endif

        // Register Core Services
        builder.Services.AddSingleton<IAuthenticationService>(sp => new AuthenticationService());
        builder.Services.AddSingleton<IModuleManager>(sp => new ModuleManager());
        builder.Services.AddSingleton<ILocalizationService>(sp => new LocalizationService());

        // Register Views
        builder.Services.AddTransient<LoginPage>();
        builder.Services.AddTransient<MainPage>();
        builder.Services.AddTransient<DashboardPage>();
        builder.Services.AddTransient<UserManagementPage>();
        builder.Services.AddTransient<OrganizationManagementPage>();
        builder.Services.AddTransient<ModuleManagementPage>();
        builder.Services.AddTransient<SettingsPage>();

        // Register ViewModels
        builder.Services.AddTransient<LoginPageViewModel>();
        builder.Services.AddTransient<MainPageViewModel>();
        builder.Services.AddTransient<DashboardPageViewModel>();
        builder.Services.AddTransient<UserManagementPageViewModel>();
        builder.Services.AddTransient<OrganizationManagementPageViewModel>();
        builder.Services.AddTransient<ModuleManagementPageViewModel>();
        builder.Services.AddTransient<SettingsPageViewModel>();

        return builder.Build();
    }
}
