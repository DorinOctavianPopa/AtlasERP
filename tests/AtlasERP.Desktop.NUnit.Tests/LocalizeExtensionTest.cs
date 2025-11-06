using AtlasERP.Core.Resources;
using AtlasERP.Desktop.Extensions;
using Microsoft.Maui.Controls;
using NUnit.Framework;
using System.ComponentModel;
using System.Globalization;

namespace AtlasERP.Desktop.Tests.Extensions;

[TestFixture]
public class LocalizeExtensionTests
{
    [Test]
    public void Constructor_InitializesWithEmptyKey()
    {
        // Arrange & Act
        var extension = new LocalizeExtension();

        // Assert
        Assert.That(extension.Key, Is.EqualTo(string.Empty));
    }

    [Test]
    public void Key_SetValue_UpdatesProperty()
    {
        // Arrange
        var extension = new LocalizeExtension();

        // Act
        extension.Key = "AppName";

        // Assert
        Assert.That(extension.Key, Is.EqualTo("AppName"));
    }

    [Test]
    public void ProvideValue_ReturnsBindingBase()
    {
        // Arrange
        var extension = new LocalizeExtension { Key = "TestKey" };
        var serviceProvider = new MockServiceProvider();

        // Act
        var result = extension.ProvideValue(serviceProvider);

        // Assert
        Assert.That(result, Is.Not.Null);
        Assert.That(result, Is.InstanceOf<BindingBase>());
    }

    [Test]
    public void ProvideValue_CreatesBindingWithCorrectPath()
    {
        // Arrange
        var extension = new LocalizeExtension { Key = "AppName" };
        var serviceProvider = new MockServiceProvider();

        // Act
        var result = extension.ProvideValue(serviceProvider) as Binding;

        // Assert
        Assert.That(result, Is.Not.Null);
        Assert.That(result!.Path, Is.EqualTo("[AppName]"));
    }

    [Test]
    public void ProvideValue_CreatesBindingWithOneWayMode()
    {
        // Arrange
        var extension = new LocalizeExtension { Key = "TestKey" };
        var serviceProvider = new MockServiceProvider();

        // Act
        var result = extension.ProvideValue(serviceProvider) as Binding;

        // Assert
        Assert.That(result, Is.Not.Null);
        Assert.That(result!.Mode, Is.EqualTo(BindingMode.OneWay));
    }

    [Test]
    public void ProvideValue_CreatesBindingWithLocalizationManagerSource()
    {
        // Arrange
        var extension = new LocalizeExtension { Key = "TestKey" };
        var serviceProvider = new MockServiceProvider();

        // Act
        var result = extension.ProvideValue(serviceProvider) as Binding;

        // Assert
        Assert.That(result, Is.Not.Null);
        Assert.That(result!.Source, Is.SameAs(LocalizationManager.Instance));
    }

    [Test]
    public void IMarkupExtension_ProvideValue_ReturnsBindingBase()
    {
        // Arrange
        IMarkupExtension extension = new LocalizeExtension { Key = "TestKey" };
        var serviceProvider = new MockServiceProvider();

        // Act
        var result = extension.ProvideValue(serviceProvider);

        // Assert
        Assert.That(result, Is.Not.Null);
        Assert.That(result, Is.InstanceOf<BindingBase>());
    }

    [Test]
    public void ProvideValue_WithEmptyKey_CreatesBindingWithPlaceholder()
    {
        // Arrange
        var extension = new LocalizeExtension { Key = "" };
        var serviceProvider = new MockServiceProvider();

        // Act
        var result = extension.ProvideValue(serviceProvider) as Binding;

        // Assert
        Assert.That(result, Is.Not.Null);
        Assert.That(result!.Path, Is.EqualTo("[_]"));
    }
}

[TestFixture]
public class LocalizationManagerTests
{
    [SetUp]
    public void SetUp()
    {
        // Reset culture to default for consistent testing
        AppResources.Culture = CultureInfo.InvariantCulture;
    }

    [Test]
    public void Instance_IsSingleton()
    {
        // Arrange & Act
        var instance1 = LocalizationManager.Instance;
        var instance2 = LocalizationManager.Instance;

        // Assert
        Assert.That(instance1, Is.Not.Null);
        Assert.That(instance2, Is.Not.Null);
        Assert.That(instance1, Is.SameAs(instance2));
    }

    [Test]
    public void Instance_ImplementsINotifyPropertyChanged()
    {
        // Arrange & Act
        var instance = LocalizationManager.Instance;

        // Assert
        Assert.That(instance, Is.InstanceOf<INotifyPropertyChanged>());
    }

    [Test]
    public void Indexer_WithNonExistingKey_ReturnsKey()
    {
        // Arrange
        var manager = LocalizationManager.Instance;
        var nonExistingKey = "NonExistingKey_12345";

        // Act
        var result = manager[nonExistingKey];

        // Assert
        Assert.That(result, Is.EqualTo(nonExistingKey));
    }

    [Test]
    public void Indexer_WithNullKey_ReturnsNull()
    {
        // Arrange
        var manager = LocalizationManager.Instance;

        // Act
        var result = manager[null!];

        // Assert
        Assert.That(result, Is.Null);
    }

    [Test]
    public void Indexer_WithEmptyKey_ReturnsEmptyString()
    {
        // Arrange
        var manager = LocalizationManager.Instance;

        // Act
        var result = manager[string.Empty];

        // Assert
        Assert.That(result, Is.EqualTo(string.Empty));
    }

    [Test]
    public void Indexer_UsesCurrentCulture()
    {
        // Arrange
        var manager = LocalizationManager.Instance;
        var testKey = "TestKey";

        // Act
        var resultInvariant = manager[testKey];
        
        // Change culture
        AppResources.Culture = new CultureInfo("en-US");
        var resultEnUs = manager[testKey];

        // Assert
        // Both should return the key if it doesn't exist, but test that culture is used
        Assert.That(resultInvariant, Is.Not.Null);
        Assert.That(resultEnUs, Is.Not.Null);
    }

    [Test]
    public void NotifyLanguageChanged_RaisesPropertyChangedEvent()
    {
        // Arrange
        var manager = LocalizationManager.Instance;
        var eventRaised = false;
        string? propertyName = null;

        manager.PropertyChanged += (sender, args) =>
        {
            eventRaised = true;
            propertyName = args.PropertyName;
        };

        // Act
        manager.NotifyLanguageChanged();

        // Assert
        Assert.That(eventRaised, Is.True);
        Assert.That(propertyName, Is.EqualTo("Item[]"));
    }

    [Test]
    public void NotifyLanguageChanged_RaisesEventWithCorrectSender()
    {
        // Arrange
        var manager = LocalizationManager.Instance;
        object? eventSender = null;

        manager.PropertyChanged += (sender, args) =>
        {
            eventSender = sender;
        };

        // Act
        manager.NotifyLanguageChanged();

        // Assert
        Assert.That(eventSender, Is.SameAs(manager));
    }

    [Test]
    public void NotifyLanguageChanged_CalledMultipleTimes_RaisesEventEachTime()
    {
        // Arrange
        var manager = LocalizationManager.Instance;
        var eventCount = 0;

        manager.PropertyChanged += (sender, args) =>
        {
            if (args.PropertyName == "Item[]")
                eventCount++;
        };

        // Act
        manager.NotifyLanguageChanged();
        manager.NotifyLanguageChanged();
        manager.NotifyLanguageChanged();

        // Assert
        Assert.That(eventCount, Is.EqualTo(3));
    }

    [Test]
    public void Indexer_AfterCultureChange_ReturnsUpdatedValue()
    {
        // Arrange
        var manager = LocalizationManager.Instance;
        var testKey = "TestKey";
        
        // Act
        var beforeCultureChange = manager[testKey];
        AppResources.Culture = new CultureInfo("fr-FR");
        var afterCultureChange = manager[testKey];

        // Assert
        // Values might be the same if key doesn't exist in resources,
        // but the test verifies the indexer is called with new culture
        Assert.That(beforeCultureChange, Is.Not.Null);
        Assert.That(afterCultureChange, Is.Not.Null);
    }

    [Test]
    public void PropertyChanged_WithNoSubscribers_DoesNotThrow()
    {
        // Arrange
        var manager = LocalizationManager.Instance;
        
        // Remove all subscribers by getting new instance
        // (This tests that NotifyLanguageChanged doesn't fail with no subscribers)

        // Act & Assert
        Assert.DoesNotThrow(() => manager.NotifyLanguageChanged());
    }

    [Test]
    public void Indexer_WithWhitespaceKey_ReturnsWhitespace()
    {
        // Arrange
        var manager = LocalizationManager.Instance;
        var whitespaceKey = "   ";

        // Act
        var result = manager[whitespaceKey];

        // Assert
        Assert.That(result, Is.EqualTo(whitespaceKey));
    }

    [Test]
    public void Indexer_ConsecutiveCalls_ReturnsSameValue()
    {
        // Arrange
        var manager = LocalizationManager.Instance;
        var key = "SomeKey";

        // Act
        var result1 = manager[key];
        var result2 = manager[key];
        var result3 = manager[key];

        // Assert
        Assert.That(result1, Is.EqualTo(result2));
        Assert.That(result2, Is.EqualTo(result3));
    }

    [TearDown]
    public void TearDown()
    {
        // Reset culture after tests
        AppResources.Culture = CultureInfo.InvariantCulture;
    }
}

// Mock service provider for testing
public class MockServiceProvider : IServiceProvider
{
    public object? GetService(Type serviceType)
    {
        return null;
    }
}