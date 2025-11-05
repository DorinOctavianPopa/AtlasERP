using AtlasERP.Core.Models;
using Prism.Commands;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace AtlasERP.Desktop.ViewModels;

public class OrganizationManagementPageViewModel : ViewModelBase
{
    public ObservableCollection<Organization> Organizations { get; } = new();

    public ICommand AddOrganizationCommand { get; }
    public ICommand EditOrganizationCommand { get; }
    public ICommand DeleteOrganizationCommand { get; }

    public OrganizationManagementPageViewModel()
    {
        Title = "Organization Management";

        AddOrganizationCommand = new DelegateCommand(ExecuteAddOrganization);
        EditOrganizationCommand = new DelegateCommand<Organization>(ExecuteEditOrganization);
        DeleteOrganizationCommand = new DelegateCommand<Organization>(ExecuteDeleteOrganization);

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

    private void ExecuteAddOrganization()
    {
        var newOrg = new Organization
        {
            Name = $"Organization {Organizations.Count + 1}",
            Description = "New organization",
            IsActive = true
        };
        Organizations.Add(newOrg);
    }

    private void ExecuteEditOrganization(Organization? org)
    {
        if (org != null)
        {
            // Edit logic here
        }
    }

    private void ExecuteDeleteOrganization(Organization? org)
    {
        if (org != null)
        {
            Organizations.Remove(org);
        }
    }
}
