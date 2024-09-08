﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrfsdiBim.Core.Common
{
    public class TimelyEntity : BaseEntity, ITimelyEntity
    {
        /// <summary>
        /// Gets or sets the date and time of instance creation
        /// </summary>
        public DateTime CreatedOn { get; set; } = DateTime.Now;

        /// <summary>
        /// Gets or sets the date and time of instance update
        /// </summary>
        public DateTime UpdatedOn { get; set; } = DateTime.Now;
    }
}
