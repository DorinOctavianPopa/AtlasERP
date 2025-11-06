namespace AtlasERP.Desktop.NUnit.Tests.ViewModels;

[TestFixture]
public class ViewModelBaseTests
{
    private ViewModelBase _viewModel;

    [SetUp]
    public void Setup()
    {
        _viewModel = new TestViewModel();
    }

    [Test]
    public void Title_ShouldUpdateProperty()
    {
        // Arrange
        var title = "Test Title";

        // Act
        _viewModel.Title = title;

        // Assert
        Assert.That(_viewModel.Title, Is.EqualTo(title));
    }

    [Test]
    public void Title_ShouldRaisePropertyChanged()
    {
        // Arrange
        var propertyChangedRaised = false;
        _viewModel.PropertyChanged += (sender, args) =>
        {
            if (args.PropertyName == nameof(ViewModelBase.Title))
                propertyChangedRaised = true;
        };

        // Act
        _viewModel.Title = "New Title";

        // Assert
        Assert.That(propertyChangedRaised, Is.True);
    }

    private class TestViewModel : ViewModelBase
    {
    }
}
