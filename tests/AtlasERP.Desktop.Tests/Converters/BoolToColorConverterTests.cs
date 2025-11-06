using System.Globalization;
using AtlasERP.Desktop.Converters;
using FluentAssertions;
using Xunit;

namespace AtlasERP.Desktop.Tests.Converters;

public class BoolToColorConverterTests
{
    private readonly BoolToColorConverter _converter;

    public BoolToColorConverterTests()
    {
        _converter = new BoolToColorConverter();
    }

    [Fact]
    public void Convert_ShouldReturnGreen_WhenValueIsTrue()
    {
        // Act
        var result = _converter.Convert(true, typeof(Color), null, CultureInfo.InvariantCulture);

        // Assert
        result.Should().Be(Colors.Green);
    }

    [Fact]
    public void Convert_ShouldReturnRed_WhenValueIsFalse()
    {
        // Act
        var result = _converter.Convert(false, typeof(Color), null, CultureInfo.InvariantCulture);

        // Assert
        result.Should().Be(Colors.Red);
    }

    [Fact]
    public void Convert_ShouldReturnGray_WhenValueIsNull()
    {
        // Act
        var result = _converter.Convert(null, typeof(Color), null, CultureInfo.InvariantCulture);

        // Assert
        result.Should().Be(Colors.Gray);
    }

    [Fact]
    public void Convert_ShouldReturnGray_WhenValueIsNotBoolean()
    {
        // Arrange
        var value = "not a boolean";

        // Act
        var result = _converter.Convert(value, typeof(Color), null, CultureInfo.InvariantCulture);

        // Assert
        result.Should().Be(Colors.Gray);
    }

    [Fact]
    public void ConvertBack_ShouldThrowNotImplementedException()
    {
        // Act
        Action act = () => _converter.ConvertBack(Colors.Green, typeof(bool), null, CultureInfo.InvariantCulture);

        // Assert
        act.Should().Throw<NotImplementedException>();
    }
}
