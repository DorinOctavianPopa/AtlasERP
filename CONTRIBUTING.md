# Contributing to AtlasERP

Thank you for your interest in contributing to AtlasERP! This document provides guidelines and instructions for contributing to the project.

## Code of Conduct

Be respectful and inclusive. We welcome contributions from everyone.

## How to Contribute

### Reporting Bugs

If you find a bug, please create an issue with:
- Clear description of the problem
- Steps to reproduce
- Expected vs actual behavior
- Screenshots if applicable
- Environment details (OS, .NET version, etc.)

### Suggesting Enhancements

Enhancement suggestions are welcome! Please create an issue with:
- Clear description of the enhancement
- Use cases and benefits
- Potential implementation approach

### Pull Requests

1. **Fork the Repository**
   ```bash
   # Click "Fork" on GitHub, then clone your fork
   git clone https://github.com/YOUR_USERNAME/AtlasERP.git
   cd AtlasERP
   ```

2. **Create a Branch**
   ```bash
   git checkout -b feature/your-feature-name
   # or
   git checkout -b fix/your-bug-fix
   ```

3. **Make Your Changes**
   - Follow the coding standards below
   - Write clean, readable code
   - Add comments for complex logic
   - Update documentation if needed

4. **Test Your Changes**
   - Ensure the solution builds without errors
   - Test on target platforms
   - Verify existing functionality still works

5. **Commit Your Changes**
   ```bash
   git add .
   git commit -m "Brief description of changes"
   ```
   
   Commit message format:
   - Use present tense ("Add feature" not "Added feature")
   - First line: brief summary (50 chars or less)
   - Blank line, then detailed description if needed

6. **Push to Your Fork**
   ```bash
   git push origin feature/your-feature-name
   ```

7. **Create Pull Request**
   - Go to the original repository on GitHub
   - Click "New Pull Request"
   - Select your fork and branch
   - Provide clear description of changes
   - Link related issues

## Coding Standards

### C# Style Guidelines

- Follow [Microsoft C# Coding Conventions](https://docs.microsoft.com/en-us/dotnet/csharp/fundamentals/coding-style/coding-conventions)
- Use meaningful variable and method names
- Keep methods small and focused (Single Responsibility Principle)
- Use async/await for asynchronous operations
- Enable nullable reference types and handle nulls appropriately

### XAML Guidelines

- Use proper indentation (4 spaces)
- Group related properties
- Use data binding over code-behind when possible
- Follow MVVM pattern consistently
- Use resource dictionaries for reusable styles

### File Organization

```
Module/
├── Views/              # XAML views
├── ViewModels/         # View models
├── Models/             # Data models
├── Services/           # Business logic
└── ModuleDefinition.cs # Module entry point
```

### Naming Conventions

- **Classes**: PascalCase (e.g., `UserManagementPage`)
- **Interfaces**: IPascalCase (e.g., `IAuthenticationService`)
- **Methods**: PascalCase (e.g., `AuthenticateAsync`)
- **Properties**: PascalCase (e.g., `Username`)
- **Fields**: _camelCase (e.g., `_authService`)
- **Parameters**: camelCase (e.g., `userName`)
- **Constants**: PascalCase (e.g., `MaxRetries`)

## Project-Specific Guidelines

### Creating New Modules

When adding a new module:

1. Create a new class library project
2. Reference `AtlasERP.Core`
3. Implement `ModuleBase` abstract class
4. Create Views and ViewModels
5. Register in `MauiProgram.cs`
6. Update documentation

Example structure:
```csharp
public class NewModule : ModuleBase
{
    public override string ModuleId => "new-module";
    public override string ModuleName => "New Module";
    public override string Description => "Description";
    public override string Icon => "🆕";
    public override int DisplayOrder => 5;

    public override Type GetMainViewType()
    {
        return typeof(NewModuleMainView);
    }
}
```

### Adding New Pages

1. Create XAML page in `Views/` folder
2. Create corresponding ViewModel in `ViewModels/`
3. Register for navigation in `MauiProgram.cs`:
   ```csharp
   containerRegistry.RegisterForNavigation<YourPage, YourPageViewModel>();
   ```

### Adding Services

1. Define interface in `AtlasERP.Core/Interfaces/`
2. Implement in `AtlasERP.Core/Services/` or module
3. Register in `MauiProgram.cs`:
   ```csharp
   containerRegistry.RegisterSingleton<IYourService, YourService>();
   ```

### UI/UX Guidelines

- Follow Material Design or Fluent Design principles
- Ensure responsive layouts work on different screen sizes
- Support both light and dark themes
- Use consistent spacing and alignment
- Provide loading indicators for async operations
- Show appropriate error messages

### Performance

- Use async/await for I/O operations
- Avoid blocking the UI thread
- Implement proper disposal of resources
- Use ObservableCollection for dynamic lists
- Consider lazy loading for large datasets

## Testing

Currently, the project doesn't have automated tests. If you'd like to contribute:

- Add unit tests for core services
- Add integration tests for modules
- Use xUnit or NUnit framework
- Follow AAA pattern (Arrange, Act, Assert)

## Documentation

- Update README.md for major features
- Add XML documentation comments to public APIs
- Update DEVELOPMENT_SETUP.md for setup changes
- Create wiki pages for complex features

## Questions?

If you have questions about contributing:
- Check existing issues and discussions
- Create a new issue with the "question" label
- Reach out to maintainers

## Recognition

Contributors will be recognized in:
- CONTRIBUTORS.md file (to be created)
- Release notes
- GitHub contributors page

Thank you for contributing to AtlasERP! 🎉
