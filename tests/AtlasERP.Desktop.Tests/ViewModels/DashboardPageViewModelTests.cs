using AtlasERP.Desktop.ViewModels;
using FluentAssertions;
using Xunit;

namespace AtlasERP.Desktop.Tests.ViewModels;

public class DashboardPageViewModelTests
{
    [Fact]
    public void Constructor_ShouldInitializeTitle()
    {
        // Act
        var viewModel = new DashboardPageViewModel();

        // Assert
        viewModel.Title.Should().Be("Dashboard");
    }
}

