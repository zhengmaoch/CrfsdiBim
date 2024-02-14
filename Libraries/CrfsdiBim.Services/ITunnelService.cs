using CrfsdiBim.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrfsdiBim.Services
{
    /// <summary>
    /// Tunnel service interface
    /// </summary>
    public partial interface ITunnelService
    {
        /// <summary>
        /// Delete tunnel
        /// </summary>
        /// <param name="tunnel">Tunnel</param>
        void DeleteTunnel(Tunnel tunnel);

        /// <summary>
        /// Gets a tunnel
        /// </summary>
        /// <param name="tunnelId">Tunnel identifier</param>
        /// <returns>Tunnel</returns>
        Tunnel GetTunnelById(string tunnelId);

        /// <summary>
        /// Inserts tunnel
        /// </summary>
        /// <param name="tunnel">Tunnel</param>
        void InsertTunnel(Tunnel tunnel);

        /// <summary>
        /// Updates the tunnel
        /// </summary>
        /// <param name="tunnel">Tunnel</param>
        void UpdateTunnel(Tunnel tunnel);

        /// <summary>
        /// Returns a list of names of not existing tunnels
        /// </summary>
        /// <param name="tunnelNames">The nemes of the tunnels to check</param>
        /// <returns>List of names not existing tunnels</returns>
        string[] GetNotExistingTunnels(string[] tunnelNames);

        /// <summary>
        /// Gets tunnels by identifier
        /// </summary>
        /// <param name="tunnelIds">Tunnel identifiers</param>
        /// <returns>Tunnels</returns>
        List<Tunnel> GetTunnelsByIds(string[] tunnelIds);
    }
}
