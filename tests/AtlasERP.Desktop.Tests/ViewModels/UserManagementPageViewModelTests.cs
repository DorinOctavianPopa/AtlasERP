using AtlasERP.Core.Models;
using AtlasERP.Desktop.ViewModels;
using FluentAssertions;
using Xunit;

namespace AtlasERP.Desktop.Tests.ViewModels;

public class UserManagementPageViewModelTests
{
    private readonly UserManagementPageViewModel _viewModel;

    public UserManagementPageViewModelTests()
    {
        _viewModel = new UserManagementPageViewModel();
    }

    [Fact]
    public void Constructor_ShouldInitializeTitle()
    {
        // Assert
        _viewModel.Title.Should().Be("User Management");
    }

    [Fact]
    public void Constructor_ShouldLoadSampleUsers()
    {
        // Assert
        _viewModel.Users.Should().NotBeEmpty();
        _viewModel.Users.Should().HaveCountGreaterThan(0);
    }

    [Fact]
    public void SelectedUser_ShouldUpdateProperty()
    {
        // Arrange
        var user = new User
        {
            Id = Guid.NewGuid().ToString(),
            Username = "testuser",
            FirstName = "Test",
            LastName = "User",
            Email = "test@example.com",
            Role = "User"
        };

        // Act
        _viewModel.SelectedUser = user;

        // Assert
        _viewModel.SelectedUser.Should().Be(user);
    }

    [Fact]
    public void AddUserCommand_ShouldBeCreated()
    {
        // Assert
        _viewModel.AddUserCommand.Should().NotBeNull();
    }

    [Fact]
    public void EditUserCommand_ShouldBeCreated()
    {
        // Assert
        _viewModel.EditUserCommand.Should().NotBeNull();
    }

    [Fact]
    public void DeleteUserCommand_ShouldBeCreated()
    {
        // Assert
        _viewModel.DeleteUserCommand.Should().NotBeNull();
    }

    [Fact]
    public void Users_ShouldContainAdminUser()
    {
        // Assert
        _viewModel.Users.Should().Contain(u => u.Role == "Admin");
    }

    [Fact]
    public void Users_ShouldContainManagerUser()
    {
        // Assert
        _viewModel.Users.Should().Contain(u => u.Role == "Manager");
    }

    [Fact]
    public void Users_ShouldContainRegularUsers()
    {
        // Assert
        _viewModel.Users.Should().Contain(u => u.Role == "User");
    }
}

