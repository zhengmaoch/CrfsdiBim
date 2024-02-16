using CrfsdiBim.Core.Common;
using CrfsdiBim.Wpf.Framework.Mvvm.Models;
using CrfsdiBim.Core.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrfsdiBim.Core.Domain
{
    public class RouteModel : BaseModel
    {
        private ICollection<TunnelModel> _tunnels;

        /// <summary>
        /// Gets or sets the name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the display order
        /// </summary>
        public int DisplayOrder { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the active
        /// </summary>
        public bool Active { get; set; } = true;

        /// <summary>
        /// Gets or sets a value indicating whether the entity has been deleted
        /// </summary>
        public bool Deleted { get; set; } = false;

        /// <summary>
        /// Gets or sets the date and time of instance creation
        /// </summary>
        public DateTime CreatedTime { get; set; } 

        /// <summary>
        /// Gets or sets the date and time of instance update
        /// </summary>
        public DateTime UpdatedTime { get; set; } = DateTime.Now;

        /// <summary>
        /// Gets or sets the state/provinces
        /// </summary>
        public virtual ICollection<TunnelModel> Tunnels
        {
            get { return _tunnels ?? (_tunnels = new List<TunnelModel>()); }
            protected set { _tunnels = value; }
        }
    }
}
