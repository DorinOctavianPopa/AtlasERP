using AtlasERP.Core.Interfaces;
using Prism.Commands;
using Prism.Navigation;
using System.Windows.Input;

namespace AtlasERP.Desktop.ViewModels;

public class LoginPageViewModel : ViewModelBase, INavigatedAware
{
    private readonly IAuthenticationService _authService;
    private readonly INavigationService _navigationService;

    private string _username = string.Empty;
    public string Username
    {
        get => _username;
        set => SetProperty(ref _username, value);
    }

    private string _password = string.Empty;
    public string Password
    {
        get => _password;
        set => SetProperty(ref _password, value);
    }

    private bool _isBusy;
    public bool IsBusy
    {
        get => _isBusy;
        set => SetProperty(ref _isBusy, value);
    }

    private string? _errorMessage;
    public string? ErrorMessage
    {
        get => _errorMessage;
        set => SetProperty(ref _errorMessage, value);
    }

    public ICommand LoginCommand { get; }

    public LoginPageViewModel(IAuthenticationService authService, INavigationService navigationService)
    {
        _authService = authService;
        _navigationService = navigationService;
        Title = "AtlasERP - Login";

        LoginCommand = new DelegateCommand(async () => await ExecuteLoginCommand(), CanExecuteLogin)
            .ObservesProperty(() => Username)
            .ObservesProperty(() => Password);
    }

    private bool CanExecuteLogin()
    {
        return !string.IsNullOrWhiteSpace(Username) && !string.IsNullOrWhiteSpace(Password);
    }

    private async Task ExecuteLoginCommand()
    {
        IsBusy = true;
        ErrorMessage = null;

        try
        {
            var result = await _authService.AuthenticateAsync(Username, Password);

            if (result)
            {
                await _navigationService.NavigateAsync("/NavigationPage/MainPage");
            }
            else
            {
                ErrorMessage = "Invalid username or password";
            }
        }
        catch (Exception ex)
        {
            ErrorMessage = $"Login failed: {ex.Message}";
        }
        finally
        {
            IsBusy = false;
        }
    }

    public void OnNavigatedFrom(INavigationParameters parameters)
    {
    }

    public void OnNavigatedTo(INavigationParameters parameters)
    {
        // Reset fields when navigating to login
        Username = string.Empty;
        Password = string.Empty;
        ErrorMessage = null;
    }
}
