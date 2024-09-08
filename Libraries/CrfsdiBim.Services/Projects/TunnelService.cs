using CrfsdiBim.Core.Data;
using CrfsdiBim.Core.Domain.Projects;
using System;
using System.Linq;

namespace CrfsdiBim.Services.Projects;

public class TunnelService : CrudService<Tunnel, string>, ITunnelService
{
    #region Fields

    private readonly IRepository<Tunnel> _tunnelRepository;

    #endregion Fields

    #region Ctor

    /// <summary>
    /// Ctor
    /// </summary>
    /// <param name="tunnelRepository">Tunnel repository</param>
    /// <param name="dbContext">DB context</param>
    public TunnelService(IRepository<Tunnel> tunnelRepository) : base(tunnelRepository)
    {
        _tunnelRepository = tunnelRepository;
    }

    #endregion Ctor

    #region Methods

    /// <summary>
    /// Returns a list of names of not existing tunnels
    /// </summary>
    /// <param name="tunnelNames">The nemes of the tunnels to check</param>
    /// <returns>List of names not existing tunnels</returns>
    public virtual string[] GetNotExistingNames(string[] tunnelNames)
    {
        if (tunnelNames == null)
            throw new ArgumentNullException(nameof(tunnelNames));

        var query = _tunnelRepository.Table;
        var queryFilter = tunnelNames.Distinct().ToArray();
        var filter = query.Select(c => c.Name).Where(c => queryFilter.Contains(c)).ToList();

        return queryFilter.Except(filter).ToArray();
    }

    #endregion Methods
}