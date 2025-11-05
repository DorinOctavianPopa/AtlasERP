# Development Setup Guide

## Prerequisites

### Required Software

1. **.NET 9.0 SDK** or later
   - Download from: https://dotnet.microsoft.com/download/dotnet/9.0
   - Verify installation: `dotnet --version`

2. **.NET MAUI Workload**
   - Required for building MAUI applications
   - Installation commands below

3. **IDE** (Choose one)
   - **Visual Studio 2022** (17.8 or later) - Recommended for Windows
     - Install ".NET Multi-platform App UI development" workload
   - **Visual Studio Code** with extensions:
     - C# Dev Kit
     - .NET MAUI Extension (if available)

### Platform-Specific Requirements

#### Windows Development
```bash
# Install MAUI workload for Windows
dotnet workload install maui-windows

# Optional: Install Android workload
dotnet workload install maui-android
```

Requirements:
- Windows 10 version 1809 or higher
- Windows 11 for best experience

#### macOS Development
```bash
# Install MAUI workloads for macOS
dotnet workload install maui-ios
dotnet workload install maui-maccatalyst

# Optional: Install Android workload
dotnet workload install maui-android
```

Requirements:
- macOS 12 (Monterey) or later
- Xcode 14 or later

#### Android Development (Any Platform)
```bash
# Install Android workload
dotnet workload install maui-android
```

Requirements:
- Android SDK (installed with Visual Studio or Android Studio)
- Android Emulator or physical device

## Installation Steps

### 1. Clone the Repository

```bash
git clone https://github.com/DorinOctavianPopa/AtlasERP.git
cd AtlasERP
```

### 2. Install MAUI Workloads

Choose the workload based on your target platform:

```bash
# For Windows apps
dotnet workload install maui-windows

# For Android apps
dotnet workload install maui-android

# For iOS/Mac apps (macOS only)
dotnet workload install maui-ios maui-maccatalyst
```

Or install all available workloads:
```bash
dotnet workload restore
```

### 3. Restore NuGet Packages

```bash
dotnet restore
```

### 4. Build the Solution

```bash
dotnet build
```

If you encounter errors about missing workloads, install them as shown in step 2.

## Running the Application

### Using .NET CLI

Navigate to the Desktop project directory:
```bash
cd src/AtlasERP.Desktop
```

#### Run on Windows
```bash
dotnet build -t:Run -f net9.0-windows10.0.19041.0
```

#### Run on Android
```bash
# Start an emulator first, then:
dotnet build -t:Run -f net9.0-android
```

#### Run on iOS (macOS only)
```bash
# Start a simulator first, then:
dotnet build -t:Run -f net9.0-ios
```

#### Run on Mac Catalyst (macOS only)
```bash
dotnet build -t:Run -f net9.0-maccatalyst
```

### Using Visual Studio 2022

1. Open `AtlasERP.sln` in Visual Studio
2. Select your target platform from the toolbar
3. Press F5 or click "Start Debugging"

### Using Visual Studio Code

1. Open the repository folder in VS Code
2. Install recommended extensions when prompted
3. Use the "Run and Debug" panel (Ctrl+Shift+D)
4. Select your target platform and click "Start Debugging"

## Troubleshooting

### Common Issues

#### 1. Workload Not Installed
**Error**: `NETSDK1147: To build this project, the following workloads must be installed`

**Solution**: Install the required workload:
```bash
dotnet workload install [workload-name]
```

#### 2. Android SDK Not Found
**Error**: Android SDK location not found

**Solution**:
- Install Android Studio or
- Set ANDROID_HOME environment variable
- In Visual Studio: Tools > Options > Xamarin > Android Settings

#### 3. Xcode Not Found (macOS)
**Error**: Xcode not found or not properly configured

**Solution**:
- Install Xcode from Mac App Store
- Run: `sudo xcode-select --switch /Applications/Xcode.app`
- Accept license: `sudo xcodebuild -license accept`

#### 4. Build Fails on Linux
**Note**: Full MAUI workload support on Linux is limited. Consider:
- Using Windows or macOS for development
- Using Windows Subsystem for Linux (WSL2) with Windows host
- Contributing to .NET MAUI Linux support

### Verify Installation

Check installed workloads:
```bash
dotnet workload list
```

Expected output should include:
```
Installed Workload Id      Manifest Version
--------------------------------------------------------------------
maui-windows               9.0.*/...
```

Check .NET version:
```bash
dotnet --version
```

Should be 9.0.x or later.

## Project Structure

After successful setup, you should see:

```
AtlasERP/
├── AtlasERP.sln                    # Solution file
├── README.md                        # Main documentation
├── DEVELOPMENT_SETUP.md             # This file
├── .gitignore                       # Git ignore rules
└── src/
    ├── AtlasERP.Desktop/            # Main MAUI application
    ├── AtlasERP.Core/               # Core library
    ├── AtlasERP.Modules.Inventory/  # Inventory module
    ├── AtlasERP.Modules.Sales/      # Sales module
    ├── AtlasERP.Modules.Accounting/ # Accounting module
    └── AtlasERP.Modules.HR/         # HR module
```

## Next Steps

1. Run the application following the instructions above
2. Log in with any username/password (demo mode)
3. Explore the different modules and management pages
4. Start customizing for your needs!

## Development Tips

### Hot Reload
MAUI supports XAML Hot Reload. Changes to XAML files will be reflected immediately while debugging.

### Debugging
- Set breakpoints in your C# code
- Use the Debug Console to inspect variables
- Check the Output window for logs and errors

### Adding New Modules
See the main README.md for instructions on creating custom modules.

## Getting Help

- **Documentation**: See README.md
- **Issues**: Create an issue on GitHub
- **.NET MAUI Docs**: https://learn.microsoft.com/dotnet/maui/
- **Prism Docs**: https://prismlibrary.com/

## System Requirements Summary

| Platform | Minimum | Recommended |
|----------|---------|-------------|
| Windows  | Windows 10 (1809+) | Windows 11 |
| macOS    | macOS 12 (Monterey) | macOS 13+ |
| Android  | Android 5.0 (API 21) | Android 10+ |
| iOS      | iOS 11 | iOS 14+ |

**Development Machine**:
- RAM: 8GB minimum, 16GB+ recommended
- Disk Space: 10GB+ free space
- Internet: Required for initial setup and package restore
