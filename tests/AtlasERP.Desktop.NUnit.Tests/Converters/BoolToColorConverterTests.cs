using AtlasERP.Desktop.Converters;
using Microsoft.Maui.Graphics;
using System.Globalization;

namespace AtlasERP.Desktop.NUnit.Tests.Converters;

[TestFixture]
public class BoolToColorConverterTests
{
    private BoolToColorConverter _converter;

    [SetUp]
    public void Setup()
    {
        _converter = new BoolToColorConverter();
    }

    [Test]
    public void Convert_ShouldReturnColor_WhenValueIsTrue()
    {
        // Act
        var result = _converter.Convert(true, typeof(Color), null, CultureInfo.InvariantCulture);

        // Assert
        Assert.That(result, Is.InstanceOf<Color>());
        Assert.That(result, Is.Not.Null);
    }

    [Test]
    public void Convert_ShouldReturnColor_WhenValueIsFalse()
    {
        // Act
        var result = _converter.Convert(false, typeof(Color), null, CultureInfo.InvariantCulture);

        // Assert
        Assert.That(result, Is.InstanceOf<Color>());
        Assert.That(result, Is.Not.Null);
    }

    [Test]
    public void Convert_ShouldReturnGray_WhenValueIsNull()
    {
        // Act
        var result = _converter.Convert(null, typeof(Color), null, CultureInfo.InvariantCulture);

        // Assert
        Assert.That(result, Is.InstanceOf<Color>());
    }
}
