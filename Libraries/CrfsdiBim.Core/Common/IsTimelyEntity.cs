using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrfsdiBim.Core.Common
{
    public partial interface IsTimelyEntity
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
