using CrfsdiBim.Core.Domain.Projects;

namespace CrfsdiBim.Services.Projects;

/// <summary>
/// Route service interface
/// </summary>
public partial interface IRouteService : ICrudService<Route, string>
{
    /// <summary>
    /// Returns a list of names of not existing routes
    /// </summary>
    /// <param name="routeNames">The nemes of the routes to check</param>
    /// <returns>List of names not existing routes</returns>
    string[] GetNotExistingNames(string[] routeNames);
}