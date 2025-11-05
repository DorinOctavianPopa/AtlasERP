using AtlasERP.Core.Interfaces;
using AtlasERP.Core.Models;

namespace AtlasERP.Core.Services;

/// <summary>
/// Simple authentication service implementation
/// In production, this should connect to a proper authentication backend
/// </summary>
public class AuthenticationService : IAuthenticationService
{
    private User? _currentUser;

    public bool IsAuthenticated => _currentUser != null;

    public User? CurrentUser => _currentUser;

    public Task<bool> AuthenticateAsync(string username, string password)
    {
        // Simple demo authentication - in production use proper authentication
        // For demo purposes, accept any username/password combination
        if (!string.IsNullOrWhiteSpace(username) && !string.IsNullOrWhiteSpace(password))
        {
            _currentUser = new User
            {
                Username = username,
                Email = $"{username}@atlasrep.com",
                FirstName = username,
                LastName = "User",
                Role = username.ToLower() == "admin" ? "Admin" : "User",
                LastLoginAt = DateTime.UtcNow
            };
            return Task.FromResult(true);
        }

        return Task.FromResult(false);
    }

    public Task LogoutAsync()
    {
        _currentUser = null;
        return Task.CompletedTask;
    }
}
