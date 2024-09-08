using CrfsdiBim.Core.Data;
using CrfsdiBim.Core.Domain.Projects;
using System;
using System.Linq;

namespace CrfsdiBim.Services.Projects;

public class RouteService : CrudService<Route, string>, IRouteService
{
    #region Fields

    private readonly IRepository<Route> _routeRepository;

    #endregion Fields

    #region Ctor

    /// <summary>
    /// Ctor
    /// </summary>
    /// <param name="routeRepository">Route repository</param>
    /// <param name="dbContext">DB context</param>
    public RouteService(IRepository<Route> routeRepository) : base(routeRepository)
    {
        _routeRepository = routeRepository;
    }

    #endregion Ctor

    #region Methods

    /// <summary>
    /// Returns a list of names of not existing routes
    /// </summary>
    /// <param name="routeNames">The nemes of the routes to check</param>
    /// <returns>List of names not existing routes</returns>
    public virtual string[] GetNotExistingNames(string[] routeNames)
    {
        if (routeNames == null)
            throw new ArgumentNullException(nameof(routeNames));

        var query = _routeRepository.Table;
        var queryFilter = routeNames.Distinct().ToArray();
        var filter = query.Select(c => c.Name).Where(c => queryFilter.Contains(c)).ToList();

        return queryFilter.Except(filter).ToArray();
    }

    #endregion Methods
}