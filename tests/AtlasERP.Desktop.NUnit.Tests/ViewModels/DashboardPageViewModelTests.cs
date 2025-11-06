namespace AtlasERP.Desktop.NUnit.Tests.ViewModels;

[TestFixture]
public class DashboardPageViewModelTests
{
    [Test]
    public void Constructor_ShouldInitializeTitle()
    {
        // Act
        var viewModel = new DashboardPageViewModel();

        // Assert
        Assert.That(viewModel.Title, Is.EqualTo("Dashboard"));
    }
}
