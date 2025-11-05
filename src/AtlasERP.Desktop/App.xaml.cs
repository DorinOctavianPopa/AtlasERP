using Prism.Ioc;

namespace AtlasERP.Desktop;

public partial class App : Microsoft.Maui.Controls.Application
{
    public App(IContainerProvider container) : base(container)
    {
        InitializeComponent();
    }
}
