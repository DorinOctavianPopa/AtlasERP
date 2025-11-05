using System;
using System.Globalization;
using Microsoft.Maui.Controls;

namespace AtlasERP.Desktop.Converters;

public class BoolToTextConverter : IValueConverter
{
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value is bool boolValue && parameter is string texts)
        {
            var textOptions = texts.Split('|');
            if (textOptions.Length == 2)
            {
                return boolValue ? textOptions[0] : textOptions[1];
            }
        }
        return string.Empty;
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
