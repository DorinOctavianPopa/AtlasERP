using AtlasERP.Core.Interfaces;
using AtlasERP.Desktop.Extensions;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Globalization;

namespace AtlasERP.Desktop.ViewModels;

public partial class SettingsPageViewModel : ViewModelBase
{
    private readonly ILocalizationService _localizationService;

    [ObservableProperty]
    private CultureInfo _selectedCulture;

    public ObservableCollection<CultureInfo> AvailableCultures { get; } = new();

    public SettingsPageViewModel(ILocalizationService localizationService)
    {
        _localizationService = localizationService;
        Title = "Settings";

        // Load available cultures
        foreach (var culture in _localizationService.GetAvailableCultures())
        {
            AvailableCultures.Add(culture);
        }

        _selectedCulture = _localizationService.CurrentCulture;
    }

    partial void OnSelectedCultureChanged(CultureInfo value)
    {
        if (value != null)
        {
            _localizationService.SetCulture(value);
            LocalizationManager.Instance.NotifyLanguageChanged();
            
            // Update all page titles
            Title = Core.Resources.AppResources.Settings;
        }
    }
}
