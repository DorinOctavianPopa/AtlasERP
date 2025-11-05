# AtlasERP - Enterprise Resource Planning System

![AtlasERP Logo](https://img.shields.io/badge/AtlasERP-v1.0-blue)
![.NET MAUI](https://img.shields.io/badge/.NET%20MAUI-9.0-purple)
![CommunityToolkit.Mvvm](https://img.shields.io/badge/CommunityToolkit.Mvvm-8.4-green)

A powerful, modular Enterprise Resource Planning (ERP) desktop application built with .NET MAUI framework and CommunityToolkit.Mvvm for MVVM architecture.

## Features

- 🔐 **User Authentication** - Secure login system with role-based access
- 👥 **User Management** - Comprehensive user administration
- 🏢 **Organization Management** - Multi-organization support
- ⚙️ **Module Management** - Dynamic module loading and configuration
- 📊 **Dashboard** - Business overview at a glance
- 🎨 **Modern UI** - Clean, responsive design with light/dark theme support
- 🔧 **Modular Architecture** - Extensible plugin-based module system

## Modules

AtlasERP comes with four core modules:

1. **Inventory Module** 📦 - Manage inventory, stock levels, and warehouses
2. **Sales Module** 💰 - Track sales, orders, and customer relationships
3. **Accounting Module** 📊 - Financial management and reporting
4. **HR Module** 👥 - Employee management, payroll, and benefits

## Architecture

The application follows a clean, modular architecture:

```
AtlasERP/
├── src/
│   ├── AtlasERP.Desktop/          # Main MAUI application
│   ├── AtlasERP.Core/             # Core interfaces and models
│   ├── AtlasERP.Modules.Inventory/  # Inventory module
│   ├── AtlasERP.Modules.Sales/      # Sales module
│   ├── AtlasERP.Modules.Accounting/ # Accounting module
│   └── AtlasERP.Modules.HR/         # HR module
```

### Technology Stack

- **.NET 9.0** - Latest .NET framework
- **.NET MAUI** - Cross-platform UI framework
- **CommunityToolkit.Mvvm** - Modern MVVM framework with source generators
- **.NET Dependency Injection** - Built-in MAUI DI container
- **CommunityToolkit.Maui** - Additional MAUI components
- **C#** - Primary programming language

## Prerequisites

To build and run AtlasERP, you need:

- [.NET 9.0 SDK](https://dotnet.microsoft.com/download/dotnet/9.0) or later
- [.NET MAUI workload](https://learn.microsoft.com/en-us/dotnet/maui/get-started/installation)
- Visual Studio Code with C# extensions (recommended) or Visual Studio 2022 17.8+

### Installing .NET MAUI Workload

```bash
# For Windows development
dotnet workload install maui-windows

# For Android development
dotnet workload install maui-android

# For iOS/MacCatalyst development (macOS only)
dotnet workload install maui-ios maui-maccatalyst
```

## Getting Started

### Clone the Repository

```bash
git clone https://github.com/DorinOctavianPopa/AtlasERP.git
cd AtlasERP
```

### Restore Dependencies

```bash
dotnet restore
```

### Build the Solution

```bash
dotnet build
```

### Run the Application

```bash
cd src/AtlasERP.Desktop
dotnet run
```

Or run for a specific platform:

```bash
# Windows
dotnet build -t:Run -f net9.0-windows10.0.19041.0

# Android (requires emulator or device)
dotnet build -t:Run -f net9.0-android

# iOS (macOS only, requires simulator or device)
dotnet build -t:Run -f net9.0-ios
```

## Demo Login

The application includes a demo authentication system:

- **Username**: Any username (use `admin` for admin role)
- **Password**: Any password

This is for demonstration purposes only. In production, implement proper authentication.

## Project Structure

### AtlasERP.Core

Contains shared interfaces, models, and services:

- `IModule` - Interface for all modules
- `IAuthenticationService` - Authentication service interface
- `IModuleManager` - Module management interface
- `User`, `Organization`, `ModuleInfo` models

### AtlasERP.Desktop

Main MAUI application with:

- **Views** - XAML pages for UI
- **ViewModels** - MVVM view models
- **Converters** - Value converters for XAML bindings
- **Resources** - Styles, colors, and assets

### Module Projects

Each module implements the `IModule` interface and can contain:

- Views specific to the module
- ViewModels for module functionality
- Services and business logic
- Data models

## Adding New Modules

To create a new module:

1. Create a new class library project
2. Reference `AtlasERP.Core`
3. Implement `ModuleBase` class
4. Register the module in `MauiProgram.cs`

Example:

```csharp
public class CustomModule : ModuleBase
{
    public override string ModuleId => "custom";
    public override string ModuleName => "Custom Module";
    public override string Description => "Custom functionality";
    public override string Icon => "🔧";
    public override int DisplayOrder => 5;

    public override Type GetMainViewType()
    {
        return typeof(CustomModuleView);
    }
}
```

## Development with Visual Studio Code

### Recommended Extensions

- C# Dev Kit
- .NET MAUI Extension
- XAML Language Support

### Debug Configuration

The project includes VS Code debug configurations for building and running on different platforms.

## Customization

### Theming

The application supports light and dark themes. Customize colors in:
- `Resources/Styles/Colors.xaml`
- `Resources/Styles/Styles.xaml`

### Adding Features

The modular architecture makes it easy to add new features:

1. Create views in the `Views` folder
2. Create corresponding ViewModels
3. Register in `MauiProgram.cs`
4. Add navigation from existing pages

## Contributing

Contributions are welcome! Please feel free to submit a Pull Request.

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## Support

For issues and questions:
- Create an issue on GitHub
- Check the documentation
- Review existing issues

## Roadmap

- [ ] Add database integration
- [ ] Implement real authentication system
- [ ] Add more module functionality
- [ ] Create mobile-optimized layouts
- [ ] Add reporting and analytics
- [ ] Implement multi-language support
- [ ] Add unit and integration tests
- [ ] Create deployment packages

## Acknowledgments

- Built with [.NET MAUI](https://dotnet.microsoft.com/apps/maui)
- MVVM with [CommunityToolkit.Mvvm](https://learn.microsoft.com/dotnet/communitytoolkit/mvvm/)
- UI components from [.NET MAUI Community Toolkit](https://github.com/CommunityToolkit/Maui)

---

**AtlasERP** - Powerful, supportive, foundational ERP application on .NET MAUI Framework (C#)
