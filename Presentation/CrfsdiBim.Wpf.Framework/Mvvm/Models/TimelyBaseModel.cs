using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrfsdiBim.Wpf.Framework.Mvvm.Models
{
    /// <summary>
    /// 基于时间的同步模型，用于云同步的属性
    /// </summary>
    public class TimelyBaseModel : BaseEntityModel
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
