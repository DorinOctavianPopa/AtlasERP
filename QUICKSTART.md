# Quick Start Guide

Get up and running with AtlasERP in minutes!

## For Windows Users

### Step 1: Install Prerequisites

1. **Download .NET 9.0 SDK**
   - Visit: https://dotnet.microsoft.com/download/dotnet/9.0
   - Download and install the SDK for Windows

2. **Install MAUI Workload**
   ```powershell
   # Open PowerShell as Administrator
   dotnet workload install maui-windows
   ```

### Step 2: Get the Code

```powershell
# Clone the repository
git clone https://github.com/DorinOctavianPopa/AtlasERP.git
cd AtlasERP
```

### Step 3: Build and Run

```powershell
# Restore dependencies
dotnet restore

# Build the solution
dotnet build

# Run the application
cd src\AtlasERP.Desktop
dotnet build -t:Run -f net9.0-windows10.0.19041.0
```

### Step 4: Login

- Username: `admin` (or any username)
- Password: Any password

## For macOS Users

### Step 1: Install Prerequisites

1. **Install .NET 9.0 SDK**
   ```bash
   # Using Homebrew
   brew install --cask dotnet-sdk
   ```

2. **Install Xcode** (required for MAUI)
   - Download from Mac App Store
   - Run: `sudo xcode-select --switch /Applications/Xcode.app`

3. **Install MAUI Workload**
   ```bash
   dotnet workload install maui-maccatalyst
   ```

### Step 2: Get the Code

```bash
git clone https://github.com/DorinOctavianPopa/AtlasERP.git
cd AtlasERP
```

### Step 3: Build and Run

```bash
# Restore dependencies
dotnet restore

# Build the solution
dotnet build

# Run the application
cd src/AtlasERP.Desktop
dotnet build -t:Run -f net9.0-maccatalyst
```

## Using Visual Studio 2022 (Recommended for Windows)

### Step 1: Install Visual Studio 2022

1. Download from: https://visualstudio.microsoft.com/
2. During installation, select:
   - ".NET Multi-platform App UI development" workload
   - ".NET desktop development" workload

### Step 2: Open Project

1. Launch Visual Studio 2022
2. Click "Open a project or solution"
3. Navigate to the cloned repository
4. Open `AtlasERP.sln`

### Step 3: Run

1. Select "Windows Machine" from the debug dropdown
2. Press `F5` or click the green "Start" button
3. Application will build and launch

## Using Visual Studio Code

### Step 1: Install Extensions

1. Install VS Code: https://code.visualstudio.com/
2. Install extensions:
   - C# Dev Kit
   - .NET MAUI (if available)

### Step 2: Open Project

```bash
cd AtlasERP
code .
```

### Step 3: Build and Run

1. Open Terminal in VS Code (Ctrl+`)
2. Run:
   ```bash
   cd src/AtlasERP.Desktop
   dotnet build
   dotnet run
   ```

## Troubleshooting

### "Workload not installed" Error

**Problem**: NETSDK1147 error when building

**Solution**:
```bash
dotnet workload install maui-windows   # or maui-maccatalyst, maui-android
```

### Build Fails - Can't find .NET SDK

**Problem**: `dotnet: command not found`

**Solution**:
1. Install .NET SDK: https://dotnet.microsoft.com/download
2. Restart your terminal/IDE
3. Verify: `dotnet --version`

### Android Emulator Issues

**Problem**: Android emulator not starting

**Solution**:
1. Install Android Studio
2. Open Android Studio > Tools > AVD Manager
3. Create a new virtual device
4. Start the emulator
5. Run the application

### macOS - Xcode Not Found

**Problem**: Xcode command line tools not found

**Solution**:
```bash
sudo xcode-select --switch /Applications/Xcode.app
sudo xcodebuild -license accept
```

## First Time Usage

### 1. Login Screen

When you first run the application:
- Enter any username (try "admin")
- Enter any password
- Click "Sign In"

**Note**: This is a demo authentication. In production, implement secure authentication.

### 2. Explore the Dashboard

After login, you'll see:
- Sidebar with navigation menu
- Dashboard with statistics
- Module options

### 3. Try Different Pages

Click on menu items to explore:
- **Dashboard**: Overview statistics
- **User Management**: Add, edit, delete users
- **Organization Management**: Manage organizations
- **Module Management**: Enable/disable modules

### 4. User Management

1. Click "User Management" in sidebar
2. Click "➕ Add User" to add a user
3. Edit or delete users using action buttons

### 5. Organization Management

1. Click "Organization Management"
2. View existing organizations
3. Click "➕ Add Organization" to create new

### 6. Module Management

1. Click "Module Management"
2. See available modules
3. Toggle switches to enable/disable modules

## Next Steps

### Customize the Application

1. **Add Your Logo**: Replace icons in `Resources/AppIcon/`
2. **Change Colors**: Edit `Resources/Styles/Colors.xaml`
3. **Modify Styles**: Update `Resources/Styles/Styles.xaml`

### Add New Features

1. **Create New Pages**: See CONTRIBUTING.md
2. **Add Business Logic**: Implement in ViewModels
3. **Add Data Storage**: Integrate a database

### Deploy Your App

#### Windows
```bash
dotnet publish -f net9.0-windows10.0.19041.0 -c Release
```

#### macOS
```bash
dotnet publish -f net9.0-maccatalyst -c Release
```

#### Android
```bash
dotnet publish -f net9.0-android -c Release
```

## Common Tasks

### Add a New User (In App)

1. Click "User Management"
2. Click "➕ Add User" button
3. User is added with default values
4. (Note: Full edit dialog to be implemented)

### Change Theme

The app automatically follows system theme:
- **Windows**: Settings > Personalization > Colors
- **macOS**: System Preferences > General > Appearance

### Logout

Click the "Logout" button at bottom of sidebar to return to login screen.

## Getting Help

### Documentation
- [README.md](README.md) - Overview and features
- [DEVELOPMENT_SETUP.md](DEVELOPMENT_SETUP.md) - Detailed setup
- [ARCHITECTURE.md](ARCHITECTURE.md) - Technical architecture
- [UI_GUIDE.md](UI_GUIDE.md) - User interface guide
- [CONTRIBUTING.md](CONTRIBUTING.md) - How to contribute

### Online Resources
- [.NET MAUI Docs](https://learn.microsoft.com/dotnet/maui/)
- [Prism Library](https://prismlibrary.com/)
- [C# Documentation](https://learn.microsoft.com/dotnet/csharp/)

### Support
- Create an issue: https://github.com/DorinOctavianPopa/AtlasERP/issues
- Check existing issues
- Read the documentation

## Performance Tips

1. **First Run**: First build takes longer - be patient
2. **Debug vs Release**: Release builds are faster
3. **Hot Reload**: XAML changes reflect instantly while debugging

## Security Note

⚠️ **Important**: This demo uses simplified authentication. Before deploying to production:

1. Implement secure password hashing
2. Use proper authentication (JWT, OAuth2)
3. Store credentials securely
4. Enable HTTPS for API calls
5. Implement role-based access control

## What's Next?

After getting familiar with the application:

1. **Explore the Code**: Check out the source files
2. **Read Documentation**: Review architecture and design
3. **Customize**: Make it your own
4. **Contribute**: Submit improvements
5. **Build**: Create your ERP solution!

## Feedback

We'd love to hear from you!
- ⭐ Star the repository if you find it useful
- 🐛 Report bugs
- 💡 Suggest features
- 🤝 Contribute code

---

**Happy Coding with AtlasERP!** 🚀
