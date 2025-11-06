# Unit Testing Guidelines for AtlasERP

This document provides guidelines and best practices for writing unit tests in the AtlasERP project.

## Table of Contents

1. [Testing Frameworks](#testing-frameworks)
2. [Project Structure](#project-structure)
3. [Naming Conventions](#naming-conventions)
4. [Test Anatomy](#test-anatomy)
5. [Testing Best Practices](#testing-best-practices)
6. [Testing Different Components](#testing-different-components)
7. [Mocking and Dependencies](#mocking-and-dependencies)
8. [Code Coverage](#code-coverage)
9. [Running Tests](#running-tests)

---

## Testing Frameworks

### Available Test Projects

- **AtlasERP.Tests** (xUnit) - For testing Core and Module projects (business logic)
- **AtlasERP.Desktop.Tests** (xUnit) - For testing Desktop MAUI UI components
- **AtlasERP.Desktop.NUnit.Tests** (NUnit) - Alternative NUnit-based tests for Desktop

### Framework Choice

- **xUnit**: Modern, preferred by Microsoft, excellent for async testing
- **NUnit**: Mature, feature-rich, constraint-based assertions

Both are acceptable. Choose based on team preference and consistency.

---

## Project Structure

```
AtlasERP/
├── src/
│   ├── AtlasERP.Core/              # Business logic
│   ├── AtlasERP.Desktop/           # MAUI UI
│   └── AtlasERP.Modules.*/         # Domain modules
└── tests/
    ├── AtlasERP.Tests/             # Core/Module tests (xUnit)
    ├── AtlasERP.Desktop.Tests/     # Desktop UI tests (xUnit)
    └── AtlasERP.Desktop.NUnit.Tests/  # Desktop UI tests (NUnit)
```

### Test Project Targets

- **Core/Module tests**: `net9.0` (standard .NET)
- **Desktop tests**: `net9.0-windows10.0.19041.0` (MAUI-compatible)

---

## Naming Conventions

### Test Project Names
```
{ProjectName}.Tests          # For xUnit
{ProjectName}.NUnit.Tests    # For NUnit
```

### Test Class Names
```csharp
// Pattern: {ClassUnderTest}Tests
public class AuthenticationServiceTests { }
public class UserManagementPageViewModelTests { }
public class StringNotEmptyConverterTests { }
```

### Test Method Names

**xUnit Pattern:**
```csharp
// Pattern: MethodName_Scenario_ExpectedBehavior
[Fact]
public void Login_WithValidCredentials_ReturnsSuccess() { }

[Fact]
public void Validate_EmptyString_ReturnsFalse() { }
```

**NUnit Pattern:**
```csharp
// Pattern: MethodName_Scenario_ExpectedBehavior
[Test]
public void Login_WithValidCredentials_ReturnsSuccess() { }

[Test]
public void Validate_EmptyString_ReturnsFalse() { }
```

### File Organization
```
Tests/
├── Services/
│   ├── AuthenticationServiceTests.cs
│   └── LocalizationServiceTests.cs
├── ViewModels/
│   ├── LoginPageViewModelTests.cs
│   └── DashboardPageViewModelTests.cs
└── Converters/
    ├── BoolToColorConverterTests.cs
    └── StringNotEmptyConverterTests.cs
```

---

## Test Anatomy

### AAA Pattern (Arrange-Act-Assert)

**xUnit Example:**
```csharp
[Fact]
public void PropertyChanged_WhenTitleChanges_EventIsRaised()
{
    // Arrange
    var viewModel = new ViewModelBase();
    var eventRaised = false;
    viewModel.PropertyChanged += (s, e) =>
    {
        if (e.PropertyName == nameof(ViewModelBase.Title))
            eventRaised = true;
    };

    // Act
    viewModel.Title = "New Title";

    // Assert
    Assert.True(eventRaised);
    Assert.Equal("New Title", viewModel.Title);
}
```

**NUnit Example:**
```csharp
[Test]
public void PropertyChanged_WhenTitleChanges_EventIsRaised()
{
    // Arrange
    var viewModel = new ViewModelBase();
    var eventRaised = false;
    viewModel.PropertyChanged += (s, e) =>
    {
        if (e.PropertyName == nameof(ViewModelBase.Title))
            eventRaised = true;
    };

    // Act
    viewModel.Title = "New Title";

    // Assert
    Assert.That(eventRaised, Is.True);
    Assert.That(viewModel.Title, Is.EqualTo("New Title"));
}
```

---

## Testing Best Practices

### 1. One Assertion Per Test (Ideally)
```csharp
// GOOD
[Fact]
public void Username_SetProperty_UpdatesValue()
{
    var viewModel = new LoginPageViewModel();
    viewModel.Username = "testuser";
    Assert.Equal("testuser", viewModel.Username);
}

[Fact]
public void Username_SetProperty_RaisesPropertyChanged()
{
    var viewModel = new LoginPageViewModel();
    var raised = false;
    viewModel.PropertyChanged += (s, e) => raised = true;
    viewModel.Username = "testuser";
    Assert.True(raised);
}

// ACCEPTABLE (related assertions)
[Fact]
public void Initialize_LoadsUsers_SetsCollections()
{
    var viewModel = new UserManagementPageViewModel();
    Assert.NotNull(viewModel.Users);
    Assert.NotEmpty(viewModel.Users);
}
```

### 2. Test Independence
```csharp
// Each test should set up its own data
public class UserServiceTests
{
    [Fact]
    public void Test1()
    {
        var service = new UserService(); // Fresh instance
        // test logic
    }

    [Fact]
    public void Test2()
    {
        var service = new UserService(); // Fresh instance
        // test logic
    }
}
```

### 3. Use Setup Methods for Common Initialization

**xUnit:**
```csharp
public class LoginPageViewModelTests : IDisposable
{
    private readonly LoginPageViewModel _viewModel;

    public LoginPageViewModelTests()
    {
        _viewModel = new LoginPageViewModel();
    }

    public void Dispose()
    {
        // Cleanup if needed
    }

    [Fact]
    public void Test1() => Assert.NotNull(_viewModel);
}
```

**NUnit:**
```csharp
[TestFixture]
public class LoginPageViewModelTests
{
    private LoginPageViewModel _viewModel;

    [SetUp]
    public void SetUp()
    {
        _viewModel = new LoginPageViewModel();
    }

    [TearDown]
    public void TearDown()
    {
        // Cleanup if needed
    }

    [Test]
    public void Test1() => Assert.That(_viewModel, Is.Not.Null);
}
```

### 4. Test Both Happy Path and Edge Cases
```csharp
// Happy path
[Fact]
public void Convert_NonEmptyString_ReturnsTrue()
{
    var converter = new StringNotEmptyConverter();
    var result = converter.Convert("test", typeof(bool), null, null);
    Assert.True((bool)result);
}

// Edge cases
[Fact]
public void Convert_NullString_ReturnsFalse()
{
    var converter = new StringNotEmptyConverter();
    var result = converter.Convert(null, typeof(bool), null, null);
    Assert.False((bool)result);
}

[Fact]
public void Convert_EmptyString_ReturnsFalse()
{
    var converter = new StringNotEmptyConverter();
    var result = converter.Convert("", typeof(bool), null, null);
    Assert.False((bool)result);
}

[Fact]
public void Convert_WhitespaceString_ReturnsFalse()
{
    var converter = new StringNotEmptyConverter();
    var result = converter.Convert("   ", typeof(bool), null, null);
    Assert.False((bool)result);
}
```

### 5. Use Theory/TestCase for Data-Driven Tests

**xUnit:**
```csharp
[Theory]
[InlineData("", false)]
[InlineData("  ", false)]
[InlineData(null, false)]
[InlineData("test", true)]
[InlineData("Hello World", true)]
public void Convert_VariousStrings_ReturnsExpectedResult(string input, bool expected)
{
    var converter = new StringNotEmptyConverter();
    var result = (bool)converter.Convert(input, typeof(bool), null, null);
    Assert.Equal(expected, result);
}
```

**NUnit:**
```csharp
[TestCase("", false)]
[TestCase("  ", false)]
[TestCase(null, false)]
[TestCase("test", true)]
[TestCase("Hello World", true)]
public void Convert_VariousStrings_ReturnsExpectedResult(string input, bool expected)
{
    var converter = new StringNotEmptyConverter();
    var result = (bool)converter.Convert(input, typeof(bool), null, null);
    Assert.That(result, Is.EqualTo(expected));
}
```

---

## Testing Different Components

### Testing ViewModels

```csharp
public class LoginPageViewModelTests
{
    [Fact]
    public void Constructor_InitializesProperties()
    {
        // Arrange & Act
        var viewModel = new LoginPageViewModel();

        // Assert
        Assert.NotNull(viewModel.Username);
        Assert.NotNull(viewModel.Password);
        Assert.Equal(string.Empty, viewModel.Username);
        Assert.Equal(string.Empty, viewModel.Password);
    }

    [Fact]
    public void PropertyChanged_WhenUsernameChanges_EventIsRaised()
    {
        // Arrange
        var viewModel = new LoginPageViewModel();
        string? changedProperty = null;
        viewModel.PropertyChanged += (s, e) => changedProperty = e.PropertyName;

        // Act
        viewModel.Username = "newuser";

        // Assert
        Assert.Equal(nameof(LoginPageViewModel.Username), changedProperty);
    }
}
```

### Testing Services

```csharp
public class AuthenticationServiceTests
{
    [Fact]
    public async Task LoginAsync_ValidCredentials_ReturnsTrue()
    {
        // Arrange
        var service = new AuthenticationService();

        // Act
        var result = await service.LoginAsync("admin", "password");

        // Assert
        Assert.True(result);
    }

    [Fact]
    public async Task LoginAsync_InvalidCredentials_ReturnsFalse()
    {
        // Arrange
        var service = new AuthenticationService();

        // Act
        var result = await service.LoginAsync("wrong", "wrong");

        // Assert
        Assert.False(result);
    }
}
```

### Testing Converters

```csharp
public class BoolToColorConverterTests
{
    [Fact]
    public void Convert_True_ReturnsGreenColor()
    {
        // Arrange
        var converter = new BoolToColorConverter();

        // Act
        var result = converter.Convert(true, typeof(Color), null, null);

        // Assert
        Assert.IsType<Color>(result);
        Assert.Equal(Colors.Green, result);
    }

    [Fact]
    public void ConvertBack_NotSupported_ThrowsNotImplementedException()
    {
        // Arrange
        var converter = new BoolToColorConverter();

        // Act & Assert
        Assert.Throws<NotImplementedException>(() =>
            converter.ConvertBack(Colors.Green, typeof(bool), null, null));
    }
}
```

### Testing MAUI Extensions (LocalizeExtension example)

```csharp
public class LocalizationManagerTests
{
    [Fact]
    public void Instance_IsSingleton()
    {
        // Arrange & Act
        var instance1 = LocalizationManager.Instance;
        var instance2 = LocalizationManager.Instance;

        // Assert
        Assert.Same(instance1, instance2);
    }

    [Fact]
    public void Indexer_ExistingKey_ReturnsLocalizedString()
    {
        // Arrange
        var manager = LocalizationManager.Instance;

        // Act
        var result = manager["AppName"]; // Assuming "AppName" exists in resources

        // Assert
        Assert.NotNull(result);
        Assert.NotEqual("AppName", result); // Should be translated
    }

    [Fact]
    public void Indexer_NonExistingKey_ReturnsKey()
    {
        // Arrange
        var manager = LocalizationManager.Instance;

        // Act
        var result = manager["NonExistingKey"];

        // Assert
        Assert.Equal("NonExistingKey", result);
    }

    [Fact]
    public void NotifyLanguageChanged_RaisesPropertyChanged()
    {
        // Arrange
        var manager = LocalizationManager.Instance;
        var eventRaised = false;
        manager.PropertyChanged += (s, e) =>
        {
            if (e.PropertyName == "Item[]")
                eventRaised = true;
        };

        // Act
        manager.NotifyLanguageChanged();

        // Assert
        Assert.True(eventRaised);
    }
}
```

---

## Mocking and Dependencies

### Using Moq (Recommended)

```csharp
public class UserServiceTests
{
    [Fact]
    public async Task GetUserAsync_CallsRepository()
    {
        // Arrange
        var mockRepo = new Mock<IUserRepository>();
        mockRepo.Setup(r => r.GetUserByIdAsync(1))
                .ReturnsAsync(new User { Id = 1, Name = "Test" });
        
        var service = new UserService(mockRepo.Object);

        // Act
        var user = await service.GetUserAsync(1);

        // Assert
        Assert.NotNull(user);
        Assert.Equal("Test", user.Name);
        mockRepo.Verify(r => r.GetUserByIdAsync(1), Times.Once);
    }
}
```

### Testing with Dependency Injection

```csharp
public class ViewModelWithDependenciesTests
{
    [Fact]
    public void Constructor_InjectsServices()
    {
        // Arrange
        var mockAuthService = new Mock<IAuthenticationService>();
        var mockNavigationService = new Mock<INavigationService>();

        // Act
        var viewModel = new LoginPageViewModel(
            mockAuthService.Object,
            mockNavigationService.Object);

        // Assert
        Assert.NotNull(viewModel);
    }

    [Fact]
    public async Task LoginCommand_ValidCredentials_NavigatesToHome()
    {
        // Arrange
        var mockAuthService = new Mock<IAuthenticationService>();
        mockAuthService.Setup(s => s.LoginAsync(It.IsAny<string>(), It.IsAny<string>()))
                      .ReturnsAsync(true);
        
        var mockNavigationService = new Mock<INavigationService>();
        
        var viewModel = new LoginPageViewModel(
            mockAuthService.Object,
            mockNavigationService.Object);
        
        viewModel.Username = "admin";
        viewModel.Password = "password";

        // Act
        await viewModel.LoginCommand.ExecuteAsync(null);

        // Assert
        mockNavigationService.Verify(
            n => n.NavigateToAsync("//Home"),
            Times.Once);
    }
}
```

---

## Code Coverage

### Running with Coverage

```bash
# Install coverage tool
dotnet tool install --global dotnet-coverage

# Run tests with coverage
dotnet test --collect:"XPlat Code Coverage"

# Generate report
dotnet coverage collect "dotnet test" --output coverage.xml
```

### Coverage Goals

- **Minimum**: 70% code coverage
- **Target**: 80-90% code coverage
- **Focus areas**: Business logic, critical paths, edge cases

### What NOT to Test

- Auto-generated code (designers, migrations)
- Third-party libraries
- Simple getters/setters (unless they have logic)
- Configuration files

---

## Running Tests

### Command Line

```bash
# Run all tests
dotnet test

# Run specific test project
dotnet test tests/AtlasERP.Tests/AtlasERP.Tests.csproj

# Run tests with detailed output
dotnet test --logger "console;verbosity=detailed"

# Run specific test
dotnet test --filter "FullyQualifiedName~LoginPageViewModelTests"

# Run tests in parallel
dotnet test --parallel
```

### Visual Studio Code

1. Install **C# Dev Kit** extension
2. Install **Test Explorer** extensions
3. Tests appear in Test Explorer panel
4. Click ▶️ to run individual tests or test classes

### Continuous Integration

```yaml
# Example GitHub Actions workflow
name: Tests

on: [push, pull_request]

jobs:
  test:
    runs-on: windows-latest
    steps:
      - uses: actions/checkout@v3
      - name: Setup .NET
        uses: actions/setup-dotnet@v3
        with:
          dotnet-version: '9.0.x'
      
      - name: Restore dependencies
        run: dotnet restore
      
      - name: Build
        run: dotnet build --no-restore
      
      - name: Test
        run: dotnet test --no-build --verbosity normal --collect:"XPlat Code Coverage"
```

---

## Common Patterns and Anti-Patterns

### ✅ DO

- Write small, focused tests
- Test one thing per test method
- Use descriptive test names
- Mock external dependencies
- Test edge cases and error conditions
- Keep tests maintainable and readable
- Use setup/teardown appropriately
- Test public interfaces, not implementation details

### ❌ DON'T

- Test private methods directly
- Write tests dependent on execution order
- Use Thread.Sleep() for async tests
- Share state between tests
- Test framework code (MAUI, .NET)
- Over-mock (mock only what's necessary)
- Ignore failing tests
- Write tests that depend on external resources (databases, APIs) without mocking

---

## Example Test Files

### Complete ViewModel Test Example

```csharp
using AtlasERP.Desktop.ViewModels;
using Xunit;

namespace AtlasERP.Desktop.Tests.ViewModels;

public class UserManagementPageViewModelTests
{
    private readonly UserManagementPageViewModel _viewModel;

    public UserManagementPageViewModelTests()
    {
        _viewModel = new UserManagementPageViewModel();
    }

    [Fact]
    public void Constructor_InitializesCollections()
    {
        Assert.NotNull(_viewModel.Users);
        Assert.NotNull(_viewModel.Roles);
        Assert.NotNull(_viewModel.SelectedRoles);
    }

    [Fact]
    public void Users_AfterInitialization_ContainsSampleData()
    {
        Assert.NotEmpty(_viewModel.Users);
        Assert.Contains(_viewModel.Users, u => u.Username == "admin");
    }

    [Theory]
    [InlineData("admin", "Admin")]
    [InlineData("user1", "User")]
    public void Users_ContainsUser_WithExpectedRole(string username, string expectedRole)
    {
        var user = _viewModel.Users.FirstOrDefault(u => u.Username == username);
        Assert.NotNull(user);
        Assert.Contains(expectedRole, user.Role);
    }

    [Fact]
    public void AddUserCommand_CanExecute_ReturnsTrue()
    {
        Assert.True(_viewModel.AddUserCommand.CanExecute(null));
    }

    [Fact]
    public void SelectedUser_SetValue_RaisesPropertyChanged()
    {
        string? changedProperty = null;
        _viewModel.PropertyChanged += (s, e) => changedProperty = e.PropertyName;

        _viewModel.SelectedUser = _viewModel.Users.First();

        Assert.Equal(nameof(UserManagementPageViewModel.SelectedUser), changedProperty);
    }
}
```

### Complete Converter Test Example

```csharp
using AtlasERP.Desktop.Converters;
using Xunit;

namespace AtlasERP.Desktop.Tests.Converters;

public class StringNotEmptyConverterTests
{
    private readonly StringNotEmptyConverter _converter;

    public StringNotEmptyConverterTests()
    {
        _converter = new StringNotEmptyConverter();
    }

    [Theory]
    [InlineData("Hello", true)]
    [InlineData("Test String", true)]
    [InlineData("x", true)]
    public void Convert_NonEmptyString_ReturnsTrue(string input, bool expected)
    {
        var result = _converter.Convert(input, typeof(bool), null, null);
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("", false)]
    [InlineData("   ", false)]
    [InlineData(null, false)]
    public void Convert_EmptyOrNullString_ReturnsFalse(string? input, bool expected)
    {
        var result = _converter.Convert(input, typeof(bool), null, null);
        Assert.Equal(expected, result);
    }

    [Fact]
    public void ConvertBack_ThrowsNotImplementedException()
    {
        Assert.Throws<NotImplementedException>(() =>
            _converter.ConvertBack(true, typeof(string), null, null));
    }
}
```

---

## Additional Resources

- [xUnit Documentation](https://xunit.net/)
- [NUnit Documentation](https://nunit.org/)
- [Moq Documentation](https://github.com/moq/moq4)
- [.NET Testing Best Practices](https://learn.microsoft.com/en-us/dotnet/core/testing/unit-testing-best-practices)
- [MAUI Testing Guide](https://learn.microsoft.com/en-us/dotnet/maui/testing/)

---

## Conclusion

Following these guidelines will help maintain high-quality, maintainable test suites that catch bugs early and document expected behavior. Remember:

1. **Tests are documentation** - they show how code should be used
2. **Tests enable refactoring** - change code confidently
3. **Tests catch regressions** - prevent old bugs from returning
4. **Tests improve design** - hard-to-test code is often poorly designed

Keep tests simple, focused, and maintainable!