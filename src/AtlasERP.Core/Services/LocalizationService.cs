using System.Globalization;
using AtlasERP.Core.Interfaces;
using AtlasERP.Core.Resources;

namespace AtlasERP.Core.Services;

public class LocalizationService : ILocalizationService
{
    private CultureInfo _currentCulture;
    private readonly List<CultureInfo> _availableCultures;

    public event EventHandler? CultureChanged;

    public LocalizationService()
    {
        // Initialize supported cultures
        _availableCultures = new List<CultureInfo>
        {
            new CultureInfo("en"), // English
            new CultureInfo("ro"), // Romanian
            new CultureInfo("es")  // Spanish
        };

        // Set default culture to system culture if supported, otherwise English
        var systemCulture = CultureInfo.CurrentCulture;
        _currentCulture = _availableCultures.FirstOrDefault(c => c.TwoLetterISOLanguageName == systemCulture.TwoLetterISOLanguageName)
                          ?? _availableCultures[0];

        ApplyCulture(_currentCulture);
    }

    public CultureInfo CurrentCulture => _currentCulture;

    public void SetCulture(CultureInfo culture)
    {
        if (_currentCulture.Equals(culture))
            return;

        _currentCulture = culture;
        ApplyCulture(culture);
        CultureChanged?.Invoke(this, EventArgs.Empty);
    }

    public string GetString(string key)
    {
        try
        {
            var value = AppResources.ResourceManager.GetString(key, _currentCulture);
            return value ?? key;
        }
        catch
        {
            return key;
        }
    }

    public IEnumerable<CultureInfo> GetAvailableCultures()
    {
        return _availableCultures;
    }

    private void ApplyCulture(CultureInfo culture)
    {
        CultureInfo.CurrentCulture = culture;
        CultureInfo.CurrentUICulture = culture;
        CultureInfo.DefaultThreadCurrentCulture = culture;
        CultureInfo.DefaultThreadCurrentUICulture = culture;
        AppResources.Culture = culture;
    }
}
