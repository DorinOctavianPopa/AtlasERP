using AtlasERP.Core.Interfaces;
using AtlasERP.Core.Models;
using AtlasERP.Desktop.ViewModels;
using FluentAssertions;
using Moq;
using Xunit;

namespace AtlasERP.Desktop.Tests.ViewModels;

public class LoginPageViewModelTests
{
    private readonly Mock<IAuthenticationService> _authServiceMock;
    private readonly Mock<IServiceProvider> _serviceProviderMock;
    private readonly LoginPageViewModel _viewModel;

    public LoginPageViewModelTests()
    {
        _authServiceMock = new Mock<IAuthenticationService>();
        _serviceProviderMock = new Mock<IServiceProvider>();
        _viewModel = new LoginPageViewModel(_authServiceMock.Object, _serviceProviderMock.Object);
    }

    [Fact]
    public void Constructor_ShouldInitializeProperties()
    {
        // Assert
        _viewModel.Title.Should().Be("AtlasERP - Login");
        _viewModel.Username.Should().BeEmpty();
        _viewModel.Password.Should().BeEmpty();
        _viewModel.IsBusy.Should().BeFalse();
        _viewModel.ErrorMessage.Should().BeNull();
    }

    [Fact]
    public void Username_ShouldUpdateProperty()
    {
        // Arrange
        var username = "testuser";

        // Act
        _viewModel.Username = username;

        // Assert
        _viewModel.Username.Should().Be(username);
    }

    [Fact]
    public void Password_ShouldUpdateProperty()
    {
        // Arrange
        var password = "testpass";

        // Act
        _viewModel.Password = password;

        // Assert
        _viewModel.Password.Should().Be(password);
    }

    [Fact]
    public void ErrorMessage_ShouldUpdateProperty()
    {
        // Arrange
        var error = "Invalid credentials";

        // Act
        _viewModel.ErrorMessage = error;

        // Assert
        _viewModel.ErrorMessage.Should().Be(error);
    }

    [Fact]
    public void IsBusy_ShouldUpdateProperty()
    {
        // Act
        _viewModel.IsBusy = true;

        // Assert
        _viewModel.IsBusy.Should().BeTrue();
    }
}

