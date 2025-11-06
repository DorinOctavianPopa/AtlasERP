using AtlasERP.Desktop.Converters;
using System.Globalization;

namespace AtlasERP.Desktop.NUnit.Tests.Converters;

[TestFixture]
public class BoolToTextConverterTests
{
    private BoolToTextConverter _converter;

    [SetUp]
    public void Setup()
    {
        _converter = new BoolToTextConverter();
    }

    [Test]
    public void Convert_ShouldReturnString_WhenValueIsTrue()
    {
        // Act
        var result = _converter.Convert(true, typeof(string), null, CultureInfo.InvariantCulture);

        // Assert
        Assert.That(result, Is.InstanceOf<string>());
        Assert.That(result, Is.Not.Null);
    }

    [Test]
    public void Convert_ShouldReturnString_WhenValueIsFalse()
    {
        // Act
        var result = _converter.Convert(false, typeof(string), null, CultureInfo.InvariantCulture);

        // Assert
        Assert.That(result, Is.InstanceOf<string>());
        Assert.That(result, Is.Not.Null);
    }

    [Test]
    public void Convert_ShouldReturnString_WhenValueIsNull()
    {
        // Act
        var result = _converter.Convert(null, typeof(string), null, CultureInfo.InvariantCulture);

        // Assert
        Assert.That(result, Is.InstanceOf<string>());
    }
}
