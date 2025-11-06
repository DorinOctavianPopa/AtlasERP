using AtlasERP.Desktop.ViewModels;
using FluentAssertions;
using Xunit;

namespace AtlasERP.Desktop.Tests.ViewModels;

public class ViewModelBaseTests
{
    private class TestViewModel : ViewModelBase
    {
        public TestViewModel()
        {
            Title = "Test";
        }
    }

    [Fact]
    public void Title_ShouldBeSettable()
    {
        // Arrange
        var viewModel = new TestViewModel();
        var title = "New Title";

        // Act
        viewModel.Title = title;

        // Assert
        viewModel.Title.Should().Be(title);
    }

    [Fact]
    public void Title_ShouldRaisePropertyChanged()
    {
        // Arrange
        var viewModel = new TestViewModel();
        var eventRaised = false;
        viewModel.PropertyChanged += (s, e) =>
        {
            if (e.PropertyName == nameof(ViewModelBase.Title))
                eventRaised = true;
        };

        // Act
        viewModel.Title = "Changed";

        // Assert
        eventRaised.Should().BeTrue();
    }

    [Fact]
    public void Constructor_ShouldSetDefaultTitle()
    {
        // Act
        var viewModel = new TestViewModel();

        // Assert
        viewModel.Title.Should().Be("Test");
    }
}
