using AtlasERP.Core.Models;
using CommunityToolkit.Mvvm.Input;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace AtlasERP.Desktop.ViewModels;

public partial class OrganizationManagementPageViewModel : ViewModelBase
{
    public ObservableCollection<Organization> Organizations { get; } = new();

    public OrganizationManagementPageViewModel()
    {
        Title = "Organization Management";
        LoadSampleData();
    }

    private void LoadSampleData()
    {
        Organizations.Add(new Organization
        {
            Name = "Atlas Corporation",
            Description = "Main organization",
            Address = "123 Business St, City, State 12345",
            PhoneNumber = "+1-555-0100",
            Email = "contact@atlascorp.com",
            IsActive = true,
            EnabledModules = new List<string> { "Inventory", "Sales", "Accounting", "HR" }
        });

        Organizations.Add(new Organization
        {
            Name = "Beta Industries",
            Description = "Partner organization",
            Address = "456 Commerce Ave, City, State 12346",
            PhoneNumber = "+1-555-0200",
            Email = "info@betaindustries.com",
            IsActive = true,
            EnabledModules = new List<string> { "Inventory", "Sales" }
        });
    }

    [RelayCommand]
    private void AddOrganization()
    {
        var newOrg = new Organization
        {
            Name = $"Organization {Organizations.Count + 1}",
            Description = "New organization",
            IsActive = true
        };
        Organizations.Add(newOrg);
    }

    [RelayCommand]
    private void EditOrganization(Organization? org)
    {
        if (org != null)
        {
            // Edit logic here
        }
    }

    [RelayCommand]
    private void DeleteOrganization(Organization? org)
    {
        if (org != null)
        {
            Organizations.Remove(org);
        }
    }
}
