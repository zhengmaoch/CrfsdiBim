using CrfsdiBim.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrfsdiBim.Data.Mapping
{
    /// <summary>
    /// Mapping class
    /// </summary>
    public partial class RouteMap : CrfsdiBimEntityTypeConfiguration<Route>
    {
        /// <summary>
        /// Ctor
        /// </summary>
        public RouteMap()
        {
            this.ToTable("Route");
            this.HasKey(c => c.Id);
            this.Property(c => c.Name).IsRequired().HasMaxLength(400);
            this.Property(c => c.Description).HasMaxLength(2000);
        }
    }
}
