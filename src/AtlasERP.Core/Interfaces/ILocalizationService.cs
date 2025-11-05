using System.Globalization;

namespace AtlasERP.Core.Interfaces;

public interface ILocalizationService
{
    /// <summary>
    /// Gets the current culture info
    /// </summary>
    CultureInfo CurrentCulture { get; }

    /// <summary>
    /// Sets the current culture
    /// </summary>
    /// <param name="culture">Culture to set</param>
    void SetCulture(CultureInfo culture);

    /// <summary>
    /// Gets a localized string by key
    /// </summary>
    /// <param name="key">Resource key</param>
    /// <returns>Localized string</returns>
    string GetString(string key);

    /// <summary>
    /// Gets all available cultures
    /// </summary>
    /// <returns>List of supported cultures</returns>
    IEnumerable<CultureInfo> GetAvailableCultures();
}
