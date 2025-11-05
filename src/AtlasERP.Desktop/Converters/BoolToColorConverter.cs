using System;
using System.Globalization;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;

namespace AtlasERP.Desktop.Converters;

public class BoolToColorConverter : IValueConverter
{
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value is bool boolValue && parameter is string colorNames)
        {
            var colors = colorNames.Split('|');
            if (colors.Length == 2)
            {
                var colorName = boolValue ? colors[0] : colors[1];
                
                // Try to get the color from resources
                if (Application.Current?.Resources.TryGetValue(colorName, out var colorResource) == true)
                {
                    return colorResource as Color;
                }
                
                // Fallback to parsing the color
                return Color.FromArgb(colorName);
            }
        }
        return Colors.Gray;
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
