using AtlasERP.Desktop.Converters;
using System.Globalization;

namespace AtlasERP.Desktop.NUnit.Tests.Converters;

[TestFixture]
public class StringNotEmptyConverterTests
{
    private StringNotEmptyConverter _converter;

    [SetUp]
    public void Setup()
    {
        _converter = new StringNotEmptyConverter();
    }

    [Test]
    public void Convert_ShouldReturnTrue_WhenValueIsNotEmptyString()
    {
        // Arrange
        var value = "test";

        // Act
        var result = _converter.Convert(value, typeof(bool), null, CultureInfo.InvariantCulture);

        // Assert
        Assert.That(result, Is.True);
    }

    [Test]
    public void Convert_ShouldReturnFalse_WhenValueIsEmptyString()
    {
        // Arrange
        var value = string.Empty;

        // Act
        var result = _converter.Convert(value, typeof(bool), null, CultureInfo.InvariantCulture);

        // Assert
        Assert.That(result, Is.False);
    }

    [Test]
    public void Convert_ShouldReturnFalse_WhenValueIsNull()
    {
        // Act
        var result = _converter.Convert(null, typeof(bool), null, CultureInfo.InvariantCulture);

        // Assert
        Assert.That(result, Is.False);
    }

    [Test]
    public void Convert_ShouldReturnFalse_WhenValueIsWhitespace()
    {
        // Arrange
        var value = "   ";

        // Act
        var result = _converter.Convert(value, typeof(bool), null, CultureInfo.InvariantCulture);

        // Assert
        Assert.That(result, Is.False);
    }
}
