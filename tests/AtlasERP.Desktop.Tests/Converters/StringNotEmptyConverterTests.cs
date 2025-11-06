using System.Globalization;
using AtlasERP.Desktop.Converters;
using FluentAssertions;
using Xunit;

namespace AtlasERP.Desktop.Tests.Converters;

public class StringNotEmptyConverterTests
{
    private readonly StringNotEmptyConverter _converter;

    public StringNotEmptyConverterTests()
    {
        _converter = new StringNotEmptyConverter();
    }

    [Fact]
    public void Convert_ShouldReturnTrue_WhenValueIsNonEmptyString()
    {
        // Arrange
        var value = "test string";

        // Act
        var result = _converter.Convert(value, typeof(bool), null, CultureInfo.InvariantCulture);

        // Assert
        result.Should().Be(true);
    }

    [Fact]
    public void Convert_ShouldReturnFalse_WhenValueIsNull()
    {
        // Act
        var result = _converter.Convert(null, typeof(bool), null, CultureInfo.InvariantCulture);

        // Assert
        result.Should().Be(false);
    }

    [Fact]
    public void Convert_ShouldReturnFalse_WhenValueIsEmptyString()
    {
        // Arrange
        var value = string.Empty;

        // Act
        var result = _converter.Convert(value, typeof(bool), null, CultureInfo.InvariantCulture);

        // Assert
        result.Should().Be(false);
    }

    [Fact]
    public void Convert_ShouldReturnFalse_WhenValueIsWhitespace()
    {
        // Arrange
        var value = "   ";

        // Act
        var result = _converter.Convert(value, typeof(bool), null, CultureInfo.InvariantCulture);

        // Assert
        result.Should().Be(false);
    }

    [Fact]
    public void Convert_ShouldReturnTrue_WhenValueHasContent()
    {
        // Arrange
        var value = "  content  ";

        // Act
        var result = _converter.Convert(value, typeof(bool), null, CultureInfo.InvariantCulture);

        // Assert
        result.Should().Be(true);
    }

    [Fact]
    public void ConvertBack_ShouldThrowNotImplementedException()
    {
        // Act
        Action act = () => _converter.ConvertBack(true, typeof(string), null, CultureInfo.InvariantCulture);

        // Assert
        act.Should().Throw<NotImplementedException>();
    }
}
