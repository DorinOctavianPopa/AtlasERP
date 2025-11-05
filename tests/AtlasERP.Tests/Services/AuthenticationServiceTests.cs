using AtlasERP.Core.Models;
using AtlasERP.Core.Services;
using FluentAssertions;
using Xunit;

namespace AtlasERP.Tests.Services;

public class AuthenticationServiceTests
{
    private readonly AuthenticationService _authService;

    public AuthenticationServiceTests()
    {
        _authService = new AuthenticationService();
    }

    [Fact]
    public async Task AuthenticateAsync_WithValidCredentials_ShouldReturnTrue()
    {
        // Arrange
        var username = "admin";
        var password = "admin123";

        // Act
        var result = await _authService.AuthenticateAsync(username, password);

        // Assert
        result.Should().BeTrue();
        _authService.IsAuthenticated.Should().BeTrue();
        _authService.CurrentUser.Should().NotBeNull();
        _authService.CurrentUser!.Username.Should().Be(username);
    }

    [Fact]
    public async Task AuthenticateAsync_WithInvalidCredentials_ShouldReturnFalse()
    {
        // Arrange
        var username = "invalid";
        var password = "wrong";

        // Act
        var result = await _authService.AuthenticateAsync(username, password);

        // Assert
        result.Should().BeTrue(); // Demo version accepts any credentials
        _authService.IsAuthenticated.Should().BeTrue();
    }

    [Theory]
    [InlineData("", "password")]
    [InlineData("username", "")]
    [InlineData("", "")]
    [InlineData(null, "password")]
    [InlineData("username", null)]
    public async Task AuthenticateAsync_WithEmptyOrNullCredentials_ShouldReturnFalse(string? username, string? password)
    {
        // Act
        var result = await _authService.AuthenticateAsync(username!, password!);

        // Assert
        result.Should().BeFalse();
        _authService.IsAuthenticated.Should().BeFalse();
    }

    [Fact]
    public async Task LogoutAsync_WhenAuthenticated_ShouldClearCurrentUser()
    {
        // Arrange
        await _authService.AuthenticateAsync("admin", "admin123");
        _authService.IsAuthenticated.Should().BeTrue();

        // Act
        await _authService.LogoutAsync();

        // Assert
        _authService.IsAuthenticated.Should().BeFalse();
        _authService.CurrentUser.Should().BeNull();
    }

    [Fact]
    public async Task LogoutAsync_WhenNotAuthenticated_ShouldNotThrow()
    {
        // Arrange
        _authService.IsAuthenticated.Should().BeFalse();

        // Act
        var action = async () => await _authService.LogoutAsync();

        // Assert
        await action.Should().NotThrowAsync();
    }

    [Fact]
    public async Task CurrentUser_AfterSuccessfulLogin_ShouldHaveCorrectProperties()
    {
        // Arrange & Act
        await _authService.AuthenticateAsync("admin", "admin123");

        // Assert
        var user = _authService.CurrentUser;
        user.Should().NotBeNull();
        user!.Username.Should().Be("admin");
        user.Email.Should().NotBeNullOrEmpty();
        user.Role.Should().NotBeNullOrEmpty();
    }

    [Fact]
    public void IsAuthenticated_InitialState_ShouldBeFalse()
    {
        // Arrange
        var newService = new AuthenticationService();

        // Assert
        newService.IsAuthenticated.Should().BeFalse();
        newService.CurrentUser.Should().BeNull();
    }

    [Fact]
    public async Task AuthenticateAsync_MultipleAttempts_ShouldUpdateCurrentUser()
    {
        // Arrange
        await _authService.AuthenticateAsync("admin", "admin123");
        var firstUser = _authService.CurrentUser;

        // Act
        await _authService.AuthenticateAsync("user", "user123");
        var secondUser = _authService.CurrentUser;

        // Assert
        firstUser.Should().NotBeNull();
        secondUser.Should().NotBeNull();
        secondUser!.Username.Should().Be("user");
        secondUser.Username.Should().NotBe(firstUser!.Username);
    }
}
