namespace AtlasERP.Desktop.NUnit.Tests.ViewModels;

[TestFixture]
public class UserManagementPageViewModelTests
{
    private UserManagementPageViewModel _viewModel;

    [SetUp]
    public void Setup()
    {
        _viewModel = new UserManagementPageViewModel();
    }

    [Test]
    public void Constructor_ShouldInitializeTitle()
    {
        // Assert
        Assert.That(_viewModel.Title, Is.EqualTo("User Management"));
    }

    [Test]
    public void Constructor_ShouldLoadSampleUsers()
    {
        // Assert
        Assert.That(_viewModel.Users, Is.Not.Empty);
        Assert.That(_viewModel.Users.Count, Is.GreaterThan(0));
    }

    [Test]
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
        Assert.That(_viewModel.SelectedUser, Is.EqualTo(user));
    }

    [Test]
    public void AddUserCommand_ShouldBeCreated()
    {
        // Assert
        Assert.That(_viewModel.AddUserCommand, Is.Not.Null);
    }

    [Test]
    public void EditUserCommand_ShouldBeCreated()
    {
        // Assert
        Assert.That(_viewModel.EditUserCommand, Is.Not.Null);
    }

    [Test]
    public void DeleteUserCommand_ShouldBeCreated()
    {
        // Assert
        Assert.That(_viewModel.DeleteUserCommand, Is.Not.Null);
    }

    [Test]
    public void Users_ShouldContainAdminUser()
    {
        // Assert
        Assert.That(_viewModel.Users, Has.Some.Property("Role").EqualTo("Admin"));
    }

    [Test]
    public void Users_ShouldContainRegularUsers()
    {
        // Assert
        Assert.That(_viewModel.Users, Has.Some.Property("Role").EqualTo("User"));
    }
}
