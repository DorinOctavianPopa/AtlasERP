using AtlasERP.Core.Interfaces;
using AtlasERP.Core.Services;
using FluentAssertions;
using Moq;
using Xunit;

namespace AtlasERP.Tests.Services;

public class ModuleManagerTests
{
    private readonly ModuleManager _moduleManager;

    public ModuleManagerTests()
    {
        _moduleManager = new ModuleManager();
    }

    [Fact]
    public void RegisterModule_WithValidModule_ShouldAddToModuleList()
    {
        // Arrange
        var mockModule = new Mock<IModule>();
        mockModule.Setup(m => m.ModuleId).Returns("TestModule");
        mockModule.Setup(m => m.ModuleName).Returns("Test Module");
        mockModule.Setup(m => m.Description).Returns("Test Description");
        mockModule.Setup(m => m.Icon).Returns("🧪");
        mockModule.Setup(m => m.DisplayOrder).Returns(1);

        // Act
        _moduleManager.RegisterModule(mockModule.Object);
        var modules = _moduleManager.GetModules();

        // Assert
        modules.Should().HaveCount(1);
        modules.First().ModuleId.Should().Be("TestModule");
    }

    [Fact]
    public void RegisterModule_WithDuplicateModuleId_ShouldNotAddDuplicate()
    {
        // Arrange
        var mockModule1 = new Mock<IModule>();
        mockModule1.Setup(m => m.ModuleId).Returns("DuplicateModule");
        mockModule1.Setup(m => m.ModuleName).Returns("Module 1");

        var mockModule2 = new Mock<IModule>();
        mockModule2.Setup(m => m.ModuleId).Returns("DuplicateModule");
        mockModule2.Setup(m => m.ModuleName).Returns("Module 2");

        // Act
        _moduleManager.RegisterModule(mockModule1.Object);
        _moduleManager.RegisterModule(mockModule2.Object);
        var modules = _moduleManager.GetModules();

        // Assert
        modules.Should().HaveCount(1);
    }

    [Fact]
    public void GetModules_InitialState_ShouldReturnEmptyCollection()
    {
        // Act
        var modules = _moduleManager.GetModules();

        // Assert
        modules.Should().NotBeNull();
        modules.Should().BeEmpty();
    }

    [Fact]
    public void GetModules_WithMultipleModules_ShouldReturnAllModules()
    {
        // Arrange
        var modules = new[]
        {
            CreateMockModule("Module1", "First Module", 1),
            CreateMockModule("Module2", "Second Module", 2),
            CreateMockModule("Module3", "Third Module", 3)
        };

        foreach (var module in modules)
        {
            _moduleManager.RegisterModule(module.Object);
        }

        // Act
        var result = _moduleManager.GetModules();

        // Assert
        result.Should().HaveCount(3);
    }

    [Fact]
    public void GetModules_ShouldReturnModulesOrderedByDisplayOrder()
    {
        // Arrange
        _moduleManager.RegisterModule(CreateMockModule("C", "Module C", 3).Object);
        _moduleManager.RegisterModule(CreateMockModule("A", "Module A", 1).Object);
        _moduleManager.RegisterModule(CreateMockModule("B", "Module B", 2).Object);

        // Act
        var modules = _moduleManager.GetModules().ToList();

        // Assert
        modules[0].DisplayOrder.Should().Be(1);
        modules[1].DisplayOrder.Should().Be(2);
        modules[2].DisplayOrder.Should().Be(3);
    }

    [Fact]
    public void RegisterModule_ShouldCallInitializeOnModule()
    {
        // Arrange
        var mockModule = new Mock<IModule>();
        mockModule.Setup(m => m.ModuleId).Returns("InitTest");
        mockModule.Setup(m => m.ModuleName).Returns("Init Test Module");

        // Act
        _moduleManager.RegisterModule(mockModule.Object);

        // Assert
        mockModule.Verify(m => m.Initialize(), Times.Once);
    }

    private Mock<IModule> CreateMockModule(string id, string name, int displayOrder)
    {
        var mock = new Mock<IModule>();
        mock.Setup(m => m.ModuleId).Returns(id);
        mock.Setup(m => m.ModuleName).Returns(name);
        mock.Setup(m => m.Description).Returns($"Description for {name}");
        mock.Setup(m => m.Icon).Returns("📦");
        mock.Setup(m => m.DisplayOrder).Returns(displayOrder);
        return mock;
    }
}
