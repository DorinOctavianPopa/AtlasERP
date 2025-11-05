using AtlasERP.Core.Models;
using FluentAssertions;
using Xunit;

namespace AtlasERP.Tests.Models;

public class OrganizationTests
{
    [Fact]
    public void Organization_Constructor_ShouldSetIdToNonEmptyGuid()
    {
        // Act
        var org = new Organization();

        // Assert
        org.Id.Should().NotBeEmpty();
    }

    [Fact]
    public void Organization_Properties_ShouldBeSettableAndGettable()
    {
        // Arrange
        var org = new Organization
        {
            Name = "Test Corp",
            Description = "A test organization",
            Address = "123 Test St",
            PhoneNumber = "555-1234",
            Email = "info@testcorp.com",
            IsActive = true,
            CreatedAt = DateTime.UtcNow
        };

        // Assert
        org.Name.Should().Be("Test Corp");
        org.Description.Should().Be("A test organization");
        org.Address.Should().Be("123 Test St");
        org.PhoneNumber.Should().Be("555-1234");
        org.Email.Should().Be("info@testcorp.com");
        org.IsActive.Should().BeTrue();
        org.CreatedAt.Should().BeCloseTo(DateTime.UtcNow, TimeSpan.FromSeconds(1));
    }

    [Fact]
    public void Organization_DefaultValues_ShouldBeCorrect()
    {
        // Act
        var org = new Organization();

        // Assert
        org.Name.Should().BeNull();
        org.Description.Should().BeNull();
        org.Address.Should().BeNull();
        org.PhoneNumber.Should().BeNull();
        org.Email.Should().BeNull();
        org.IsActive.Should().BeFalse();
    }

    [Fact]
    public void Organization_TwoInstances_ShouldHaveDifferentIds()
    {
        // Act
        var org1 = new Organization();
        var org2 = new Organization();

        // Assert
        org1.Id.Should().NotBe(org2.Id);
    }
}
