﻿using CrfsdiBim.Core.Common;
using CrfsdiBim.Core.Domain.Common;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CrfsdiBim.Core.Domain.Projects
{
    [Table("Tunnel")]
    public class Tunnel : BaseEntity, IActiveEntity, ISoftDeletedEntity, ITimelyEntity, IOrderedEntity
    {
        [MaxLength(200)]
        [Required]
        public string Name { get; set; }

        [MaxLength(2000)]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets a route identifier
        /// </summary>
        public string RouteId { get; set; }

        /// <summary>
        /// Gets or sets the price
        /// </summary>
        public double Price { get; set; }

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
        public DateTime CreatedTime { get; set; } = DateTime.Now;

        /// <summary>
        /// Gets or sets the date and time of instance update
        /// </summary>
        public DateTime UpdatedTime { get; set; } = DateTime.Now;

        /// <summary>
        /// Gets or sets the route
        /// </summary>
        [ForeignKey("Route")]
        public virtual Route Route { get; set; }
    }
}