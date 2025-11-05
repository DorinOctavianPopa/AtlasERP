namespace AtlasERP.Core.Interfaces;

/// <summary>
/// Service for handling user authentication
/// </summary>
public interface IAuthenticationService
{
    /// <summary>
    /// Authenticate a user with username and password
    /// </summary>
    Task<bool> AuthenticateAsync(string username, string password);

    /// <summary>
    /// Log out the current user
    /// </summary>
    Task LogoutAsync();

    /// <summary>
    /// Check if a user is currently authenticated
    /// </summary>
    bool IsAuthenticated { get; }

    /// <summary>
    /// Get the current authenticated user
    /// </summary>
    Models.User? CurrentUser { get; }
}
