using AtlasERP.Core.Models;
using FluentAssertions;
using Xunit;

namespace AtlasERP.Tests.Models;

public class UserTests
{
    [Fact]
    public void User_Constructor_ShouldSetIdToNonEmptyGuid()
    {
        // Act
        var user = new User();

        // Assert
        user.Id.Should().NotBeEmpty();
    }

    [Fact]
    public void User_Properties_ShouldBeSettableAndGettable()
    {
        // Arrange
        var user = new User
        {
            Username = "testuser",
            Email = "test@example.com",
            FirstName = "Test",
            LastName = "User",
            Role = "Admin",
            IsActive = true,
            CreatedAt = DateTime.UtcNow
        };

        // Assert
        user.Username.Should().Be("testuser");
        user.Email.Should().Be("test@example.com");
        user.FirstName.Should().Be("Test");
        user.LastName.Should().Be("User");
        user.Role.Should().Be("Admin");
        user.IsActive.Should().BeTrue();
        user.CreatedAt.Should().BeCloseTo(DateTime.UtcNow, TimeSpan.FromSeconds(1));
    }

    [Fact]
    public void User_DefaultValues_ShouldBeCorrect()
    {
        // Act
        var user = new User();

        // Assert
        user.Username.Should().BeNull();
        user.Email.Should().BeNull();
        user.FirstName.Should().BeNull();
        user.LastName.Should().BeNull();
        user.Role.Should().BeNull();
        user.IsActive.Should().BeFalse();
        user.OrganizationId.Should().BeNull();
    }

    [Fact]
    public void User_TwoInstances_ShouldHaveDifferentIds()
    {
        // Act
        var user1 = new User();
        var user2 = new User();

        // Assert
        user1.Id.Should().NotBe(user2.Id);
    }
}
