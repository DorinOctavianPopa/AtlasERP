using System.Globalization;
using AtlasERP.Core.Services;
using Xunit;

namespace AtlasERP.Core.Services;

public class LocalizationServiceTest
{
    [Fact]
    public void Constructor_InitializesWithDefaultCulture()
    {
        // Arrange & Act
        var service = new LocalizationService();

        // Assert
        Assert.NotNull(service.CurrentCulture);
        Assert.Contains(service.CurrentCulture, service.GetAvailableCultures());
    }

    [Fact]
    public void GetAvailableCultures_ReturnsThreeCultures()
    {
        // Arrange
        var service = new LocalizationService();

        // Act
        var cultures = service.GetAvailableCultures().ToList();

        // Assert
        Assert.Equal(3, cultures.Count);
        Assert.Contains(cultures, c => c.TwoLetterISOLanguageName == "en");
        Assert.Contains(cultures, c => c.TwoLetterISOLanguageName == "ro");
        Assert.Contains(cultures, c => c.TwoLetterISOLanguageName == "es");
    }

    [Fact]
    public void SetCulture_UpdatesCurrentCulture()
    {
        // Arrange
        var service = new LocalizationService();
        var newCulture = new CultureInfo("ro");

        // Act
        service.SetCulture(newCulture);

        // Assert
        Assert.Equal("ro", service.CurrentCulture.TwoLetterISOLanguageName);
    }

    [Fact]
    public void SetCulture_RaisesCultureChangedEvent()
    {
        // Arrange
        var service = new LocalizationService();
        var eventRaised = false;
        service.CultureChanged += (sender, args) => eventRaised = true;
        var newCulture = new CultureInfo("es");

        // Act
        service.SetCulture(newCulture);

        // Assert
        Assert.True(eventRaised);
    }

    [Fact]
    public void SetCulture_DoesNotRaiseEventWhenSameCulture()
    {
        // Arrange
        var service = new LocalizationService();
        var currentCulture = service.CurrentCulture;
        var eventRaised = false;
        service.CultureChanged += (sender, args) => eventRaised = true;

        // Act
        service.SetCulture(currentCulture);

        // Assert
        Assert.False(eventRaised);
    }

    [Fact]
    public void SetCulture_AppliesCultureToThreadContext()
    {
        // Arrange
        var service = new LocalizationService();
        var newCulture = new CultureInfo("es");

        // Act
        service.SetCulture(newCulture);

        // Assert
        Assert.Equal("es", CultureInfo.CurrentCulture.TwoLetterISOLanguageName);
        Assert.Equal("es", CultureInfo.CurrentUICulture.TwoLetterISOLanguageName);
    }

    [Fact]
    public void GetString_ReturnsKeyWhenResourceNotFound()
    {
        // Arrange
        var service = new LocalizationService();
        var nonExistentKey = "NonExistentKey_12345";

        // Act
        var result = service.GetString(nonExistentKey);

        // Assert
        Assert.Equal(nonExistentKey, result);
    }

    [Fact]
    public void GetString_ReturnsKeyOnException()
    {
        // Arrange
        var service = new LocalizationService();
        var invalidKey = "";

        // Act
        var result = service.GetString(invalidKey);

        // Assert
        Assert.Equal(invalidKey, result);
    }

    [Fact]
    public void CurrentCulture_ReturnsSetCulture()
    {
        // Arrange
        var service = new LocalizationService();
        var expectedCulture = new CultureInfo("ro");

        // Act
        service.SetCulture(expectedCulture);

        // Assert
        Assert.Equal(expectedCulture.TwoLetterISOLanguageName, service.CurrentCulture.TwoLetterISOLanguageName);
    }

    
}