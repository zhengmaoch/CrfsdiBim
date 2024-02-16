namespace CrfsdiBim.Core.Domain.Common
{
    /// <summary>
    /// Represents a active entity
    /// </summary>
    public partial interface IActiveEntity
    {
        /// <summary>
        /// Gets or sets a value indicating whether the entity has been actived
        /// </summary>
        bool Active { get; set; }
    }
}