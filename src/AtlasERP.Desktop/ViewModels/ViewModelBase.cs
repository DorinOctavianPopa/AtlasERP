using CommunityToolkit.Mvvm.ComponentModel;

namespace AtlasERP.Desktop.ViewModels;

public partial class ViewModelBase : ObservableObject
{
    [ObservableProperty]
    private string? _title;
}
