using CrfsdiBim.Core.Domain;
using System.Collections.Generic;

namespace CrfsdiBim.Services
{
    /// <summary>
    /// Route service interface
    /// </summary>
    public partial interface IRouteService
    {
        /// <summary>
        /// Delete route
        /// </summary>
        /// <param name="route">Route</param>
        void DeleteRoute(Route route);

        /// <summary>
        /// Gets a route
        /// </summary>
        /// <param name="routeId">Route identifier</param>
        /// <returns>Route</returns>
        Route GetRouteById(string routeId);

        /// <summary>
        /// Inserts route
        /// </summary>
        /// <param name="route">Route</param>
        void InsertRoute(Route route);

        /// <summary>
        /// Updates the route
        /// </summary>
        /// <param name="route">Route</param>
        void UpdateRoute(Route route);

        /// <summary>
        /// Returns a list of names of not existing routes
        /// </summary>
        /// <param name="routeNames">The nemes of the routes to check</param>
        /// <returns>List of names not existing routes</returns>
        string[] GetNotExistingRoutes(string[] routeNames);

        /// <summary>
        /// Gets routes by identifier
        /// </summary>
        /// <param name="routeIds">Route identifiers</param>
        /// <returns>Routes</returns>
        List<Route> GetRoutesByIds(string[] routeIds);
    }
}