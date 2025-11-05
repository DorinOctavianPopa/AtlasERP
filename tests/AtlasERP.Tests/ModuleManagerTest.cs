using AtlasERP.Core.Interfaces;
using AtlasERP.Core.Services;
using Moq;
using Xunit;

namespace AtlasERP.Core.Services;

public class ModuleManagerTest
{
    [Fact]
    public void RegisterModule_ShouldAddModule_WhenModuleIsNew()
    {
        // Arrange
        var moduleManager = new ModuleManager();
        var mockModule = new Mock<IModule>();
        mockModule.Setup(m => m.ModuleId).Returns("module1");

        // Act
        moduleManager.RegisterModule(mockModule.Object);

        // Assert
        var modules = moduleManager.GetModules();
        Assert.Single(modules);
        Assert.Equal("module1", modules.First().ModuleId);
    }

    [Fact]
    public void RegisterModule_ShouldNotAddDuplicate_WhenModuleIdAlreadyExists()
    {
        // Arrange
        var moduleManager = new ModuleManager();
        var mockModule1 = new Mock<IModule>();
        mockModule1.Setup(m => m.ModuleId).Returns("module1");
        var mockModule2 = new Mock<IModule>();
        mockModule2.Setup(m => m.ModuleId).Returns("module1");

        // Act
        moduleManager.RegisterModule(mockModule1.Object);
        moduleManager.RegisterModule(mockModule2.Object);

        // Assert
        var modules = moduleManager.GetModules();
        Assert.Single(modules);
    }

    [Fact]
    public void GetModules_ShouldReturnEmpty_WhenNoModulesRegistered()
    {
        // Arrange
        var moduleManager = new ModuleManager();

        // Act
        var modules = moduleManager.GetModules();

        // Assert
        Assert.Empty(modules);
    }

    [Fact]
    public void GetModules_ShouldReturnModulesOrderedByDisplayOrder()
    {
        // Arrange
        var moduleManager = new ModuleManager();
        var mockModule1 = new Mock<IModule>();
        mockModule1.Setup(m => m.ModuleId).Returns("module1");
        mockModule1.Setup(m => m.DisplayOrder).Returns(2);
        
        var mockModule2 = new Mock<IModule>();
        mockModule2.Setup(m => m.ModuleId).Returns("module2");
        mockModule2.Setup(m => m.DisplayOrder).Returns(1);

        // Act
        moduleManager.RegisterModule(mockModule1.Object);
        moduleManager.RegisterModule(mockModule2.Object);
        var modules = moduleManager.GetModules().ToList();

        // Assert
        Assert.Equal(2, modules.Count);
        Assert.Equal("module2", modules[0].ModuleId);
        Assert.Equal("module1", modules[1].ModuleId);
    }

    [Fact]
    public void GetModule_ShouldReturnModule_WhenModuleExists()
    {
        // Arrange
        var moduleManager = new ModuleManager();
        var mockModule = new Mock<IModule>();
        mockModule.Setup(m => m.ModuleId).Returns("module1");
        moduleManager.RegisterModule(mockModule.Object);

        // Act
        var result = moduleManager.GetModule("module1");

        // Assert
        Assert.NotNull(result);
        Assert.Equal("module1", result.ModuleId);
    }

    [Fact]
    public void GetModule_ShouldReturnNull_WhenModuleDoesNotExist()
    {
        // Arrange
        var moduleManager = new ModuleManager();

        // Act
        var result = moduleManager.GetModule("nonexistent");

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void InitializeModules_ShouldCallInitializeOnAllModules()
    {
        // Arrange
        var moduleManager = new ModuleManager();
        var mockModule1 = new Mock<IModule>();
        mockModule1.Setup(m => m.ModuleId).Returns("module1");
        var mockModule2 = new Mock<IModule>();
        mockModule2.Setup(m => m.ModuleId).Returns("module2");

        moduleManager.RegisterModule(mockModule1.Object);
        moduleManager.RegisterModule(mockModule2.Object);

        // Act
        moduleManager.InitializeModules();

        // Assert
        mockModule1.Verify(m => m.Initialize(), Times.Once);
        mockModule2.Verify(m => m.Initialize(), Times.Once);
    }

    [Fact]
    public void InitializeModules_ShouldDoNothing_WhenNoModulesRegistered()
    {
        // Arrange
        var moduleManager = new ModuleManager();

        // Act & Assert (should not throw)
        moduleManager.InitializeModules();
    }
}