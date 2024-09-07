using CrfsdiBim.Core.Data;
using CrfsdiBim.Core.Domain;
using CrfsdiBim.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CrfsdiBim.Services
{
    public class TunnelService : ITunnelService
    {
        #region Fields

        private readonly IRepository<Tunnel> _tunnelRepository;
        //private readonly IDbContext _dbContext;

        #endregion Fields

        #region Ctor

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="tunnelRepository">Tunnel repository</param>
        /// <param name="dbContext">DB context</param>
        public TunnelService(IRepository<Tunnel> tunnelRepository,
            IDbContext dbContext)
        {
            this._tunnelRepository = tunnelRepository;
            //this._dbContext = dbContext;
        }

        #endregion Ctor

        #region Methods

        /// <summary>
        /// Delete tunnel
        /// </summary>
        /// <param name="tunnel">Tunnel</param>
        public virtual void DeleteTunnel(Tunnel tunnel)
        {
            if (tunnel == null)
                throw new ArgumentNullException(nameof(tunnel));

            tunnel.Deleted = true;
            UpdateTunnel(tunnel);
        }

        /// <summary>
        /// Gets a tunnel
        /// </summary>
        /// <param name="tunnelId">Tunnel identifier</param>
        /// <returns>Tunnel</returns>
        public virtual Tunnel GetTunnelById(string tunnelId)
        {
            if (string.IsNullOrEmpty(tunnelId))
                return null;

            return _tunnelRepository.GetById(tunnelId);
        }

        /// <summary>
        /// Inserts tunnel
        /// </summary>
        /// <param name="tunnel">Tunnel</param>
        public virtual void InsertTunnel(Tunnel tunnel)
        {
            if (tunnel == null)
                throw new ArgumentNullException(nameof(tunnel));

            _tunnelRepository.Insert(tunnel);
        }

        /// <summary>
        /// Updates the tunnel
        /// </summary>
        /// <param name="tunnel">Tunnel</param>
        public virtual void UpdateTunnel(Tunnel tunnel)
        {
            if (tunnel == null)
                throw new ArgumentNullException(nameof(tunnel));

            _tunnelRepository.Update(tunnel);
        }

        /// <summary>
        /// Returns a list of names of not existing tunnels
        /// </summary>
        /// <param name="tunnelNames">The nemes of the tunnels to check</param>
        /// <returns>List of names not existing tunnels</returns>
        public virtual string[] GetNotExistingTunnels(string[] tunnelNames)
        {
            if (tunnelNames == null)
                throw new ArgumentNullException(nameof(tunnelNames));

            var query = _tunnelRepository.Table;
            var queryFilter = tunnelNames.Distinct().ToArray();
            var filter = query.Select(c => c.Name).Where(c => queryFilter.Contains(c)).ToList();

            return queryFilter.Except(filter).ToArray();
        }

        /// <summary>
        /// Gets tunnels by identifier
        /// </summary>
        /// <param name="tunnelIds">Tunnel identifiers</param>
        /// <returns>Tunnels</returns>
        public virtual List<Tunnel> GetTunnelsByIds(string[] tunnelIds)
        {
            if (tunnelIds == null || tunnelIds.Length == 0)
                return new List<Tunnel>();

            var query = from p in _tunnelRepository.Table
                        where tunnelIds.Contains(p.Id) && !p.Deleted
                        select p;

            return query.ToList();
        }

        #endregion Methods
    }
}