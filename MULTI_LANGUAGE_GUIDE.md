# Multi-Language Support Guide

## Overview

AtlasERP now includes comprehensive multi-language support, allowing users to switch between different languages on the fly. The application currently supports:

- 🇬🇧 **English** (default)
- 🇷🇴 **Romanian** (Română)
- 🇪🇸 **Spanish** (Español)

## Features

- **Dynamic Language Switching**: Change the language at runtime without restarting the application
- **Persistent Selection**: Language preference is maintained throughout the session
- **Complete UI Coverage**: All UI elements, menus, buttons, and labels are localized
- **Easy Extension**: Adding new languages requires only creating a new resource file
- **Type-Safe**: Uses strongly-typed resource files for compile-time validation

## Architecture

### Components

#### 1. ILocalizationService Interface
Located in `AtlasERP.Core/Interfaces/ILocalizationService.cs`

Provides the contract for localization functionality:
```csharp
public interface ILocalizationService
{
    CultureInfo CurrentCulture { get; }
    void SetCulture(CultureInfo culture);
    string GetString(string key);
    IEnumerable<CultureInfo> GetAvailableCultures();
}
```

#### 2. LocalizationService Implementation
Located in `AtlasERP.Core/Services/LocalizationService.cs`

Implements the localization service with:
- Culture management
- Resource string retrieval
- Culture change notifications
- System culture detection

#### 3. Resource Files
Located in `AtlasERP.Core/Resources/`

- **AppResources.resx**: Default English translations
- **AppResources.ro.resx**: Romanian translations
- **AppResources.es.resx**: Spanish translations
- **AppResources.Designer.cs**: Strongly-typed resource accessor

#### 4. LocalizeExtension (XAML Markup Extension)
Located in `AtlasERP.Desktop/Extensions/LocalizeExtension.cs`

Enables easy localization in XAML:
```xml
<Label Text="{ext:Localize WelcomeMessage}" />
```

#### 5. SettingsPage
Located in `AtlasERP.Desktop/Views/SettingsPage.xaml`

User interface for language selection with:
- Language picker
- Visual language cards
- Instant language switching

## Usage

### For Users

1. **Access Language Settings**:
   - Navigate to the main menu
   - Click on "Settings" (⚙️)

2. **Change Language**:
   - Select your preferred language from the dropdown
   - The interface will update immediately

3. **Supported Languages**:
   - English (en)
   - Romanian (ro)
   - Spanish (es)

### For Developers

#### Using Localization in XAML

1. **Add the namespace** to your XAML file:
```xml
xmlns:ext="clr-namespace:AtlasERP.Desktop.Extensions"
```

2. **Use the LocalizeExtension**:
```xml
<Label Text="{ext:Localize KeyName}" />
<Button Text="{ext:Localize ButtonText}" />
<Entry Placeholder="{ext:Localize PlaceholderText}" />
```

#### Using Localization in C# Code

1. **Direct Access**:
```csharp
using AtlasERP.Core.Resources;

string text = AppResources.WelcomeMessage;
```

2. **Via ILocalizationService**:
```csharp
private readonly ILocalizationService _localizationService;

public MyViewModel(ILocalizationService localizationService)
{
    _localizationService = localizationService;
}

public void UpdateText()
{
    string text = _localizationService.GetString("WelcomeMessage");
}
```

#### Changing Language Programmatically

```csharp
private readonly ILocalizationService _localizationService;

// Change to Romanian
_localizationService.SetCulture(new CultureInfo("ro"));

// Notify UI to update
LocalizationManager.Instance.NotifyLanguageChanged();
```

## Adding a New Language

To add support for a new language (e.g., French):

### Step 1: Create Resource File

1. Copy `AppResources.resx` to `AppResources.fr.resx` in the `AtlasERP.Core/Resources/` folder
2. Translate all `<value>` elements to French
3. Keep the `<data name>` attributes unchanged

Example:
```xml
<data name="Welcome" xml:space="preserve">
  <value>Bienvenue</value>
</data>
```

### Step 2: Update LocalizationService

Edit `AtlasERP.Core/Services/LocalizationService.cs`:

```csharp
public LocalizationService()
{
    _availableCultures = new List<CultureInfo>
    {
        new CultureInfo("en"), // English
        new CultureInfo("ro"), // Romanian
        new CultureInfo("es"), // Spanish
        new CultureInfo("fr")  // French - ADD THIS LINE
    };
    // ... rest of the constructor
}
```

### Step 3: Update SettingsPage (Optional)

Add a visual card for the new language in `SettingsPage.xaml`:

```xml
<Border Grid.Column="3" ...>
    <VerticalStackLayout Spacing="5">
        <Label Text="🇫🇷" FontSize="32" HorizontalOptions="Center"/>
        <Label Text="Français" FontSize="14" HorizontalOptions="Center" FontAttributes="Bold"/>
        <Label Text="French" FontSize="11" HorizontalOptions="Center"
               TextColor="{AppThemeBinding Light={StaticResource Gray600}, Dark={StaticResource Gray400}}"/>
    </VerticalStackLayout>
</Border>
```

### Step 4: Build and Test

```bash
dotnet build
```

The new language will appear automatically in the language picker.

## Resource Keys Reference

### Common Keys
- `AppName`: Application name
- `AppSubtitle`: Application subtitle
- `Welcome`: Generic welcome text
- `Language`: Language setting label
- `Settings`: Settings label

### Authentication
- `SignIn`: Sign in button text
- `Username`: Username field label
- `Password`: Password field label
- `EnterUsername`: Username placeholder
- `EnterPassword`: Password placeholder
- `Logout`: Logout button text

### Navigation
- `Dashboard`: Dashboard menu item
- `UserManagement`: User management menu item
- `OrganizationManagement`: Organization management menu item
- `ModuleManagement`: Module management menu item

### Common Actions
- `Save`: Save button
- `Cancel`: Cancel button
- `Close`: Close button
- `Edit`: Edit button
- `Delete`: Delete button
- `Yes`: Yes button
- `No`: No button
- `OK`: OK button

### User Management
- `UserManagementTitle`: Page title
- `UserManagementDescription`: Page description
- `AddUser`: Add user button
- `FullName`: Full name field
- `Email`: Email field
- `Role`: Role field
- `Actions`: Actions column header

### Organization Management
- `OrganizationManagementTitle`: Page title
- `OrganizationManagementDescription`: Page description
- `AddOrganization`: Add organization button
- `OrganizationName`: Organization name field
- `Address`: Address field
- `Phone`: Phone field

### Module Management
- `ModuleManagementTitle`: Page title
- `ModuleManagementDescription`: Page description
- `ModuleName`: Module name field
- `Description`: Description field
- `Status`: Status field
- `Enabled`: Enabled status
- `Disabled`: Disabled status

### Dashboard
- `DashboardTitle`: Dashboard page title
- `DashboardDescription`: Dashboard description
- `SalesOverview`: Sales overview card
- `InventoryStatus`: Inventory status card
- `ActiveEmployees`: Active employees card
- `PendingTransactions`: Pending transactions card
- `ActiveUsers`: Active users stat
- `ActiveModules`: Active modules stat
- `Organizations`: Organizations stat

## Best Practices

### 1. Always Use Resource Keys

❌ **Don't**:
```xml
<Label Text="Welcome to AtlasERP" />
```

✅ **Do**:
```xml
<Label Text="{ext:Localize WelcomeMessage}" />
```

### 2. Keep Keys Consistent

Use descriptive, consistent naming:
- Use PascalCase for keys
- Group related keys with common prefixes
- Use clear, descriptive names

### 3. Provide Context in Comments

When adding new keys, include comments in the resource file:
```xml
<!-- User Profile Section -->
<data name="ProfileTitle" xml:space="preserve">
  <value>Profile Settings</value>
  <comment>Title for the user profile settings page</comment>
</data>
```

### 4. Test All Languages

Before releasing:
- Test language switching
- Verify text fits in UI elements
- Check for missing translations
- Ensure proper text directionality

### 5. Handle Pluralization

For texts that need pluralization, create separate keys:
```xml
<data name="ItemCount" xml:space="preserve">
  <value>Items</value>
</data>
<data name="ItemCountSingular" xml:space="preserve">
  <value>Item</value>
</data>
```

## Troubleshooting

### Language Not Changing

**Issue**: UI doesn't update after language change

**Solution**:
1. Ensure `LocalizationManager.Instance.NotifyLanguageChanged()` is called
2. Verify bindings use the `LocalizeExtension`
3. Check that resource keys exist in all language files

### Missing Translations

**Issue**: Some text shows key names instead of translations

**Solution**:
1. Verify the key exists in the resource file
2. Check spelling of the key
3. Ensure the resource file is included in the project

### New Language Not Appearing

**Issue**: Added language doesn't show in the picker

**Solution**:
1. Verify the culture is added to `LocalizationService` constructor
2. Check resource file naming (must be `AppResources.{culture}.resx`)
3. Rebuild the project

## Technical Details

### How It Works

1. **Initialization**: On app start, `LocalizationService` detects system culture or defaults to English
2. **Resource Loading**: .NET automatically loads the correct resource file based on culture
3. **UI Binding**: XAML bindings through `LocalizeExtension` react to culture changes
4. **Runtime Switching**: When culture changes, `LocalizationManager` notifies all bindings to refresh

### Performance Considerations

- Resource strings are cached by .NET
- Language switching has minimal performance impact
- Resource files are embedded in the assembly
- No network calls required

### Thread Safety

- `LocalizationService` is registered as a singleton
- Culture changes are thread-safe
- Resource access is thread-safe

## Future Enhancements

Potential improvements for future versions:

1. **Right-to-Left (RTL) Support**: For languages like Arabic and Hebrew
2. **Date/Time Formatting**: Culture-specific date and time display
3. **Number Formatting**: Culture-specific number, currency formatting
4. **Pluralization Engine**: Advanced plural rules for different languages
5. **Automatic Translation**: Integration with translation services
6. **Language Packs**: Downloadable language packages
7. **User Preference Storage**: Persist language selection across sessions
8. **Translation Management**: UI for managing translations

## Contributing Translations

We welcome contributions for new languages! To contribute:

1. Fork the repository
2. Create a new resource file for your language
3. Translate all strings
4. Test the translation in the application
5. Submit a pull request

Please ensure:
- All keys are translated
- Translations are accurate and natural
- Cultural context is considered
- No machine translations (without review)

## License

The localization infrastructure and translations are part of AtlasERP and follow the same MIT License.

## Support

For issues or questions about localization:
- Open an issue on GitHub
- Check existing documentation
- Review the source code examples

---

**AtlasERP** - Building a globally accessible ERP system
