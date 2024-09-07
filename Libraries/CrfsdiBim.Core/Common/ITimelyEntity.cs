using System;

namespace CrfsdiBim.Core.Common
{
    public partial interface ITimelyEntity
    {
        /// <summary>
        /// Gets or sets the date and time of instance creation
        /// </summary>
        DateTime CreatedTime { get; set; }

        /// <summary>
        /// Gets or sets the date and time of instance update
        /// </summary>
        DateTime UpdatedTime { get; set; }
    }
}