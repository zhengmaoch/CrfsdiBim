using CrfsdiBim.Core.Data;
using CrfsdiBim.Core.Domain;
using CrfsdiBim.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrfsdiBim.Services
{
    public class RouteService : IRouteService
    {
        #region Fields

        private readonly IRepository<Route> _routeRepository;
        private readonly IDbContext _dbContext;

        #endregion

        #region Ctor

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="routeRepository">Route repository</param>
        /// <param name="dbContext">DB context</param>
        public RouteService(IRepository<Route> routeRepository,
            IDbContext dbContext)
        {
            this._routeRepository = routeRepository;
            this._dbContext = dbContext;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Delete route
        /// </summary>
        /// <param name="route">Route</param>
        public virtual void DeleteRoute(Route route)
        {
            if (route == null)
                throw new ArgumentNullException(nameof(route));

            route.Deleted = true;
            UpdateRoute(route);
        }

        /// <summary>
        /// Gets a route
        /// </summary>
        /// <param name="routeId">Route identifier</param>
        /// <returns>Route</returns>
        public virtual Route GetRouteById(string routeId)
        {
            if (string.IsNullOrEmpty(routeId))
                return null;

            return _routeRepository.GetById(routeId);
        }

        /// <summary>
        /// Inserts route
        /// </summary>
        /// <param name="route">Route</param>
        public virtual void InsertRoute(Route route)
        {
            if (route == null)
                throw new ArgumentNullException(nameof(route));

            _routeRepository.Insert(route);
        }

        /// <summary>
        /// Updates the route
        /// </summary>
        /// <param name="route">Route</param>
        public virtual void UpdateRoute(Route route)
        {
            if (route == null)
                throw new ArgumentNullException(nameof(route));

            _routeRepository.Update(route);
        }

        /// <summary>
        /// Returns a list of names of not existing routes
        /// </summary>
        /// <param name="routeNames">The nemes of the routes to check</param>
        /// <returns>List of names not existing routes</returns>
        public virtual string[] GetNotExistingRoutes(string[] routeNames)
        {
            if (routeNames == null)
                throw new ArgumentNullException(nameof(routeNames));

            var query = _routeRepository.Table;
            var queryFilter = routeNames.Distinct().ToArray();
            var filter = query.Select(c => c.Name).Where(c => queryFilter.Contains(c)).ToList();

            return queryFilter.Except(filter).ToArray();
        }

        /// <summary>
        /// Gets routes by identifier
        /// </summary>
        /// <param name="routeIds">Route identifiers</param>
        /// <returns>Routes</returns>
        public virtual List<Route> GetRoutesByIds(string[] routeIds)
        {
            if (routeIds == null || routeIds.Length == 0)
                return new List<Route>();

            var query = from p in _routeRepository.Table
                        where routeIds.Contains(p.Id) && !p.Deleted
                        select p;

            return query.ToList();
        }

        #endregion
    }
}
