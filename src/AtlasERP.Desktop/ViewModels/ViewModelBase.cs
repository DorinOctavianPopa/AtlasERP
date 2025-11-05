using Prism.Mvvm;
using Prism.Navigation;

namespace AtlasERP.Desktop.ViewModels;

public class ViewModelBase : BindableBase, IDestructible
{
    private string? _title;
    public string? Title
    {
        get => _title;
        set => SetProperty(ref _title, value);
    }

    public virtual void Destroy()
    {
        // Cleanup logic
    }
}
