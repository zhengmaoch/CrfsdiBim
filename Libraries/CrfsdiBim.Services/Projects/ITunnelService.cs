using CrfsdiBim.Core.Domain.Projects;

namespace CrfsdiBim.Services.Projects;

/// <summary>
/// Tunnel service interface
/// </summary>
public partial interface ITunnelService : ICrudService<Tunnel, string>
{
    /// <summary>
    /// Returns a list of names of not existing tunnels
    /// </summary>
    /// <param name="tunnelNames">The nemes of the tunnels to check</param>
    /// <returns>List of names not existing tunnels</returns>
    string[] GetNotExistingNames(string[] tunnelNames);
}