# AtlasERP Architecture

## Overview

AtlasERP follows a modular, layered architecture built on .NET MAUI with CommunityToolkit.Mvvm for MVVM pattern and built-in .NET Dependency Injection.

## Architecture Diagram

```
┌─────────────────────────────────────────────────────────────────┐
│                        Presentation Layer                        │
│                     (AtlasERP.Desktop - MAUI)                    │
├──────────────────┬──────────────────┬──────────────────┬─────────┤
│     Views        │   ViewModels     │   Converters     │Resources│
│   (XAML Pages)   │  (MVVM Logic)    │  (Bindings)      │(Styles) │
└──────────────────┴──────────────────┴──────────────────┴─────────┘
                              │
                              │ Uses
                              ▼
┌─────────────────────────────────────────────────────────────────┐
│                      Core Library Layer                          │
│                      (AtlasERP.Core)                             │
├──────────────────┬──────────────────┬──────────────────┐         │
│   Interfaces     │     Models       │    Services      │         │
│  IModule         │     User         │  AuthService     │         │
│  IAuthService    │  Organization    │  ModuleManager   │         │
│  IModuleManager  │   ModuleInfo     │                  │         │
└──────────────────┴──────────────────┴──────────────────┘         │
                              │
                              │ Implements
                              ▼
┌─────────────────────────────────────────────────────────────────┐
│                      Module Layer                                │
├──────────────────┬──────────────────┬──────────────────┬─────────┤
│    Inventory     │      Sales       │   Accounting     │   HR    │
│     Module       │     Module       │     Module       │  Module │
└──────────────────┴──────────────────┴──────────────────┴─────────┘
```

## Layer Descriptions

### 1. Presentation Layer (AtlasERP.Desktop)

**Responsibility**: User interface and user interaction

**Components**:
- **Views**: XAML pages defining the UI structure
  - `LoginPage`: Authentication interface
  - `MainPage`: Main navigation shell
  - `DashboardPage`: Overview dashboard
  - `UserManagementPage`: User administration
  - `OrganizationManagementPage`: Organization setup
  - `ModuleManagementPage`: Module configuration

- **ViewModels**: Business logic for views (MVVM pattern)
  - Handles user input
  - Manages view state
  - Interacts with services
  - Implements INotifyPropertyChanged

- **Converters**: Value converters for data binding
  - `StringNotEmptyConverter`: Visibility based on string content
  - `BoolToColorConverter`: Color based on boolean value
  - `BoolToTextConverter`: Text based on boolean value

- **Resources**: UI resources
  - Colors.xaml: Color palette
  - Styles.xaml: Reusable styles
  - Icons and images

**Technologies**:
- .NET MAUI 9.0
- CommunityToolkit.Mvvm 8.4 (MVVM with source generators)
- CommunityToolkit.Maui 11.0
- Microsoft.Extensions.DependencyInjection (Built-in DI)

### 2. Core Library Layer (AtlasERP.Core)

**Responsibility**: Shared contracts, models, and core services

**Components**:
- **Interfaces**: Service contracts
  - `IModule`: Base interface for all modules
  - `IAuthenticationService`: Authentication operations
  - `IModuleManager`: Module lifecycle management

- **Models**: Domain entities
  - `User`: User account information
  - `Organization`: Company/organization data
  - `ModuleInfo`: Module metadata

- **Services**: Core business logic
  - `AuthenticationService`: User authentication
  - `ModuleManager`: Module registration and lifecycle

- **Base Classes**:
  - `ModuleBase`: Base implementation for modules

**Technologies**:
- .NET 9.0 Class Library
- No external dependencies (pure C#)

### 3. Module Layer

**Responsibility**: Pluggable business modules

**Modules**:
1. **Inventory Module** (AtlasERP.Modules.Inventory)
   - Stock management
   - Warehouse operations
   - Inventory tracking

2. **Sales Module** (AtlasERP.Modules.Sales)
   - Order management
   - Customer relationships
   - Sales tracking

3. **Accounting Module** (AtlasERP.Modules.Accounting)
   - Financial management
   - Reporting
   - Ledger operations

4. **HR Module** (AtlasERP.Modules.HR)
   - Employee management
   - Payroll
   - Benefits administration

**Module Structure**:
Each module follows this pattern:
```
AtlasERP.Modules.{Name}/
├── {Name}Module.cs         # Module definition
├── Views/                  # Module-specific views
├── ViewModels/             # Module-specific view models
├── Models/                 # Module-specific data models
└── Services/               # Module-specific services
```

## Design Patterns

### 1. MVVM (Model-View-ViewModel)

**Purpose**: Separation of concerns between UI and business logic

**Implementation**:
- **Model**: Data entities (Core/Models)
- **View**: XAML pages (Desktop/Views)
- **ViewModel**: Logic layer (Desktop/ViewModels)

**Benefits**:
- Testable business logic
- Reusable view models
- Data binding support
- Clean separation of concerns

### 2. Dependency Injection

**Purpose**: Loose coupling and testability

**Implementation**: Using .NET MAUI's built-in Dependency Injection

```csharp
// Registration in MauiProgram.cs
builder.Services.AddSingleton<IAuthenticationService, AuthenticationService>();
builder.Services.AddTransient<LoginPage>();
builder.Services.AddTransient<LoginPageViewModel>();

// Injection
public LoginPageViewModel(IAuthenticationService authService)
{
    _authService = authService;
}
```

**Benefits**:
- Loose coupling
- Easy testing with mocks
- Flexible service implementation
- Lifecycle management
- Standard .NET pattern

### 3. Module Pattern

**Purpose**: Extensible plugin architecture

**Implementation**:
```csharp
public class InventoryModule : ModuleBase
{
    public override string ModuleId => "inventory";
    public override string ModuleName => "Inventory";
    // ... other properties
    
    public override Type GetMainViewType()
    {
        return typeof(InventoryMainView);
    }
}
```

**Benefits**:
- Easy to add new modules
- Isolated module logic
- Dynamic loading support
- Independent deployment

### 4. Repository Pattern (Future)

**Purpose**: Data access abstraction

**Planned Implementation**:
```csharp
public interface IRepository<T>
{
    Task<T> GetByIdAsync(string id);
    Task<IEnumerable<T>> GetAllAsync();
    Task AddAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(string id);
}
```

## Data Flow

### Authentication Flow
```
┌──────┐      ┌─────────────┐      ┌─────────────────┐      ┌──────────┐
│ User │─────▶│  LoginPage  │─────▶│LoginPageViewModel│─────▶│AuthService│
└──────┘      └─────────────┘      └─────────────────┘      └──────────┘
                                             │                      │
                                             ▼                      ▼
                                    ┌─────────────────┐    ┌──────────┐
                                    │  Navigation     │    │ValidateUser│
                                    │  to MainPage    │◀───│   Data    │
                                    └─────────────────┘    └──────────┘
```

### Module Navigation Flow
```
┌──────┐      ┌──────────┐      ┌──────────────┐      ┌───────────┐
│ User │─────▶│ MainPage │─────▶│ModuleManager │─────▶│  Module   │
└──────┘      └──────────┘      └──────────────┘      └───────────┘
   │              │                     │                    │
   │              │                     ▼                    ▼
   │              │            ┌──────────────┐    ┌────────────────┐
   │              └───────────▶│  Navigation  │───▶│  Module View   │
   └──────────────────────────▶│   Service    │    └────────────────┘
                               └──────────────┘
```

## Technology Stack

### Frontend
- **Framework**: .NET MAUI 9.0
- **Language**: C# 12 with nullable reference types
- **UI**: XAML with data binding
- **MVVM**: CommunityToolkit.Mvvm 8.4 with source generators
- **Toolkit**: CommunityToolkit.Maui 11.0

### Backend (Future)
- **API**: ASP.NET Core Web API
- **Database**: SQL Server / PostgreSQL / SQLite
- **ORM**: Entity Framework Core
- **Authentication**: JWT / OAuth2

### Cross-Cutting
- **Logging**: Microsoft.Extensions.Logging
- **DI Container**: Microsoft.Extensions.DependencyInjection (Built-in MAUI DI)
- **Navigation**: .NET MAUI Navigation

## Security Considerations

### Current (Demo)
- Simple authentication for demonstration
- No password hashing
- No secure storage

### Planned
- Secure password hashing (BCrypt/PBKDF2)
- JWT token authentication
- Secure storage (MAUI SecureStorage)
- Role-based access control
- Data encryption at rest
- HTTPS for API communication

## Performance Considerations

### Current
- In-memory data storage
- Synchronous operations where appropriate
- Async/await for I/O operations

### Planned
- Database caching
- Lazy loading for large datasets
- Background data synchronization
- Image optimization
- Bundle size optimization

## Extensibility Points

1. **New Modules**: Implement `ModuleBase`
2. **Custom Services**: Implement service interfaces
3. **Custom Views**: Create XAML pages and ViewModels
4. **Value Converters**: Implement `IValueConverter`
5. **Custom Themes**: Extend resource dictionaries

## Future Architecture Enhancements

1. **Backend API Integration**
   - RESTful API for data operations
   - SignalR for real-time updates
   - Offline-first architecture

2. **Database Layer**
   - Entity Framework Core
   - Repository pattern
   - Unit of Work pattern

3. **Caching Layer**
   - In-memory caching
   - Distributed caching
   - Cache invalidation strategies

4. **Testing Infrastructure**
   - Unit tests for services
   - Integration tests for modules
   - UI automation tests

5. **CI/CD Pipeline**
   - Automated builds
   - Automated testing
   - Deployment automation

## References

- [.NET MAUI Documentation](https://learn.microsoft.com/dotnet/maui/)
- [CommunityToolkit.Mvvm Documentation](https://learn.microsoft.com/dotnet/communitytoolkit/mvvm/)
- [MVVM Pattern](https://learn.microsoft.com/dotnet/architecture/maui/mvvm)
- [Dependency Injection](https://learn.microsoft.com/dotnet/core/extensions/dependency-injection)
