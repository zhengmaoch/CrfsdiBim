using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrfsdiBim.Core.Common
{
    public partial interface IOrderedEntity
    {
        /// <summary>
        /// Gets or sets the display order
        /// </summary>
        int DisplayOrder { get; set; }
    }
}
