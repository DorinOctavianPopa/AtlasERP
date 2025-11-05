using AtlasERP.Core.Interfaces;
using AtlasERP.Core.Services;
using AtlasERP.Desktop.ViewModels;
using AtlasERP.Desktop.Views;
using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using Prism.DryIoc;
using Prism.Ioc;

namespace AtlasERP.Desktop;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .UsePrism(prism =>
            {
                prism.RegisterTypes(RegisterTypes)
                     .OnAppStart("NavigationPage/LoginPage");
            })
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

        return builder.Build();
    }

    private static void RegisterTypes(IContainerRegistry containerRegistry)
    {
        // Register Core Services
        containerRegistry.RegisterSingleton<IAuthenticationService, AuthenticationService>();
        containerRegistry.RegisterSingleton<IModuleManager, ModuleManager>();

        // Register Navigation Pages
        containerRegistry.RegisterForNavigation<NavigationPage>();
        containerRegistry.RegisterForNavigation<LoginPage, LoginPageViewModel>();
        containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>();
        containerRegistry.RegisterForNavigation<DashboardPage, DashboardPageViewModel>();
        containerRegistry.RegisterForNavigation<UserManagementPage, UserManagementPageViewModel>();
        containerRegistry.RegisterForNavigation<OrganizationManagementPage, OrganizationManagementPageViewModel>();
        containerRegistry.RegisterForNavigation<ModuleManagementPage, ModuleManagementPageViewModel>();
    }
}
