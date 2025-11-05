using AtlasERP.Core.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace AtlasERP.Desktop.ViewModels;

public partial class UserManagementPageViewModel : ViewModelBase
{
    public ObservableCollection<User> Users { get; } = new();

    [ObservableProperty]
    private User? _selectedUser;

    public UserManagementPageViewModel()
    {
        Title = "User Management";
        LoadSampleData();
    }

    private void LoadSampleData()
    {
        Users.Add(new User
        {
            Username = "admin",
            Email = "admin@atlasrep.com",
            FirstName = "Admin",
            LastName = "User",
            Role = "Admin",
            IsActive = true
        });

        Users.Add(new User
        {
            Username = "john.doe",
            Email = "john.doe@atlasrep.com",
            FirstName = "John",
            LastName = "Doe",
            Role = "User",
            IsActive = true
        });

        Users.Add(new User
        {
            Username = "jane.smith",
            Email = "jane.smith@atlasrep.com",
            FirstName = "Jane",
            LastName = "Smith",
            Role = "User",
            IsActive = true
        });
    }

    [RelayCommand]
    private void AddUser()
    {
        // In a real app, this would open a dialog or navigate to an add user page
        var newUser = new User
        {
            Username = $"user{Users.Count + 1}",
            Email = $"user{Users.Count + 1}@atlasrep.com",
            FirstName = "New",
            LastName = "User",
            Role = "User"
        };
        Users.Add(newUser);
    }

    [RelayCommand]
    private void EditUser(User? user)
    {
        // In a real app, this would open an edit dialog
        if (user != null)
        {
            // Edit logic here
        }
    }

    [RelayCommand]
    private void DeleteUser(User? user)
    {
        if (user != null)
        {
            Users.Remove(user);
        }
    }
}
