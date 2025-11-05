namespace AtlasERP.Desktop;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();
    }

    protected override Window CreateWindow(IActivationState? activationState)
    {
        var loginPage = MauiProgram.Services.GetService<Views.LoginPage>();
        return new Window(new NavigationPage(loginPage!));
    }
}
