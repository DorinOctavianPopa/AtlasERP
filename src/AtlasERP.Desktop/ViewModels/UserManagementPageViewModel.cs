using AtlasERP.Core.Models;
using Prism.Commands;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace AtlasERP.Desktop.ViewModels;

public class UserManagementPageViewModel : ViewModelBase
{
    public ObservableCollection<User> Users { get; } = new();

    private User? _selectedUser;
    public User? SelectedUser
    {
        get => _selectedUser;
        set => SetProperty(ref _selectedUser, value);
    }

    public ICommand AddUserCommand { get; }
    public ICommand EditUserCommand { get; }
    public ICommand DeleteUserCommand { get; }

    public UserManagementPageViewModel()
    {
        Title = "User Management";

        AddUserCommand = new DelegateCommand(ExecuteAddUser);
        EditUserCommand = new DelegateCommand<User>(ExecuteEditUser);
        DeleteUserCommand = new DelegateCommand<User>(ExecuteDeleteUser);

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

    private void ExecuteAddUser()
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

    private void ExecuteEditUser(User? user)
    {
        // In a real app, this would open an edit dialog
        if (user != null)
        {
            // Edit logic here
        }
    }

    private void ExecuteDeleteUser(User? user)
    {
        if (user != null)
        {
            Users.Remove(user);
        }
    }
}
