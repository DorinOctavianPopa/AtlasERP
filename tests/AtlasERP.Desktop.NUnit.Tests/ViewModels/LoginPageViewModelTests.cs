namespace AtlasERP.Desktop.NUnit.Tests.ViewModels;

[TestFixture]
public class LoginPageViewModelTests
{
    private Mock<IAuthenticationService> _authServiceMock;
    private Mock<IServiceProvider> _serviceProviderMock;
    private LoginPageViewModel _viewModel;

    [SetUp]
    public void Setup()
    {
        _authServiceMock = new Mock<IAuthenticationService>();
        _serviceProviderMock = new Mock<IServiceProvider>();
        _viewModel = new LoginPageViewModel(_authServiceMock.Object, _serviceProviderMock.Object);
    }

    [Test]
    public void Constructor_ShouldInitializeProperties()
    {
        // Assert
        Assert.That(_viewModel.Title, Is.EqualTo("AtlasERP - Login"));
        Assert.That(_viewModel.Username, Is.Empty);
        Assert.That(_viewModel.Password, Is.Empty);
        Assert.That(_viewModel.IsBusy, Is.False);
        Assert.That(_viewModel.ErrorMessage, Is.Null);
    }

    [Test]
    public void Username_ShouldUpdateProperty()
    {
        // Arrange
        var username = "testuser";

        // Act
        _viewModel.Username = username;

        // Assert
        Assert.That(_viewModel.Username, Is.EqualTo(username));
    }

    [Test]
    public void Password_ShouldUpdateProperty()
    {
        // Arrange
        var password = "testpass";

        // Act
        _viewModel.Password = password;

        // Assert
        Assert.That(_viewModel.Password, Is.EqualTo(password));
    }

    [Test]
    public void ErrorMessage_ShouldUpdateProperty()
    {
        // Arrange
        var error = "Invalid credentials";

        // Act
        _viewModel.ErrorMessage = error;

        // Assert
        Assert.That(_viewModel.ErrorMessage, Is.EqualTo(error));
    }

    [Test]
    public void IsBusy_ShouldUpdateProperty()
    {
        // Act
        _viewModel.IsBusy = true;

        // Assert
        Assert.That(_viewModel.IsBusy, Is.True);
    }
}
