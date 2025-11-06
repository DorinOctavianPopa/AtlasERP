using System.Globalization;
using AtlasERP.Desktop.Converters;
using FluentAssertions;
using Xunit;

namespace AtlasERP.Desktop.Tests.Converters;

public class BoolToTextConverterTests
{
    private readonly BoolToTextConverter _converter;

    public BoolToTextConverterTests()
    {
        _converter = new BoolToTextConverter();
    }

    [Fact]
    public void Convert_ShouldReturnEnabled_WhenValueIsTrue()
    {
        // Act
        var result = _converter.Convert(true, typeof(string), null, CultureInfo.InvariantCulture);

        // Assert
        result.Should().Be("Enabled");
    }

    [Fact]
    public void Convert_ShouldReturnDisabled_WhenValueIsFalse()
    {
        // Act
        var result = _converter.Convert(false, typeof(string), null, CultureInfo.InvariantCulture);

        // Assert
        result.Should().Be("Disabled");
    }

    [Fact]
    public void Convert_ShouldReturnDisabled_WhenValueIsNull()
    {
        // Act
        var result = _converter.Convert(null, typeof(string), null, CultureInfo.InvariantCulture);

        // Assert
        result.Should().Be("Disabled");
    }

    [Fact]
    public void Convert_ShouldReturnDisabled_WhenValueIsNotBoolean()
    {
        // Arrange
        var value = "not a boolean";

        // Act
        var result = _converter.Convert(value, typeof(string), null, CultureInfo.InvariantCulture);

        // Assert
        result.Should().Be("Disabled");
    }

    [Fact]
    public void ConvertBack_ShouldThrowNotImplementedException()
    {
        // Act
        Action act = () => _converter.ConvertBack("Enabled", typeof(bool), null, CultureInfo.InvariantCulture);

        // Assert
        act.Should().Throw<NotImplementedException>();
    }
}
