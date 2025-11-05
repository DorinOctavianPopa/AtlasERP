using AtlasERP.Core.Models;
using FluentAssertions;
using Xunit;

namespace AtlasERP.Tests.Models;

public class ModuleInfoTests
{
    [Fact]
    public void ModuleInfo_Properties_ShouldBeSettableAndGettable()
    {
        // Arrange
        var moduleInfo = new ModuleInfo
        {
            Id = "inventory",
            Name = "Inventory",
            Description = "Inventory management module",
            Icon = "📦",
            DisplayOrder = 1,
            IsEnabled = true
        };

        // Assert
        moduleInfo.Id.Should().Be("inventory");
        moduleInfo.Name.Should().Be("Inventory");
        moduleInfo.Description.Should().Be("Inventory management module");
        moduleInfo.Icon.Should().Be("📦");
        moduleInfo.DisplayOrder.Should().Be(1);
        moduleInfo.IsEnabled.Should().BeTrue();
    }

    [Fact]
    public void ModuleInfo_DefaultValues_ShouldBeCorrect()
    {
        // Act
        var moduleInfo = new ModuleInfo();

        // Assert
        moduleInfo.Id.Should().BeNull();
        moduleInfo.Name.Should().BeNull();
        moduleInfo.Description.Should().BeNull();
        moduleInfo.Icon.Should().BeNull();
        moduleInfo.DisplayOrder.Should().Be(0);
        moduleInfo.IsEnabled.Should().BeFalse();
    }

    [Fact]
    public void ModuleInfo_IsEnabled_ShouldBeToggleable()
    {
        // Arrange
        var moduleInfo = new ModuleInfo { IsEnabled = false };

        // Act
        moduleInfo.IsEnabled = true;

        // Assert
        moduleInfo.IsEnabled.Should().BeTrue();

        // Act again
        moduleInfo.IsEnabled = false;

        // Assert
        moduleInfo.IsEnabled.Should().BeFalse();
    }
}
