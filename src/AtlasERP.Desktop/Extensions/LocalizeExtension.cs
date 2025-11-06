using AtlasERP.Core.Resources;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Xaml;
using System;
using System.ComponentModel;

namespace AtlasERP.Desktop.Extensions;

[ContentProperty(nameof(Key))]
public class LocalizeExtension : IMarkupExtension<BindingBase>
{
    public string Key { get; set; } = string.Empty;

    public BindingBase ProvideValue(IServiceProvider serviceProvider)
    {
        var binding = new Binding
        {
            Mode = BindingMode.OneWay,
            Path = string.IsNullOrEmpty(Key) ? "[_]" : $"[{Key}]",
            Source = LocalizationManager.Instance
        };
        return binding;
    }

    object IMarkupExtension.ProvideValue(IServiceProvider serviceProvider)
    {
        return ProvideValue(serviceProvider);
    }
}

public class LocalizationManager : INotifyPropertyChanged
{
    private static LocalizationManager? _instance;
    
    public static LocalizationManager Instance => _instance ??= new LocalizationManager();

    public event PropertyChangedEventHandler? PropertyChanged;

    private LocalizationManager()
    {
    }

    public string this[string key]
    {
        get
        {
            if (key == null)
                return null;
            
            if (string.IsNullOrEmpty(key))
                return key;
                
            var value = AppResources.ResourceManager.GetString(key, AppResources.Culture);
            return value ?? key;
        }
    }

    public void NotifyLanguageChanged()
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Item[]"));
    }
}
