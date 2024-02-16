using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrfsdiBim.Wpf.Framework.Mvvm.Models
{
    /// <summary>
    /// Represents the base class for models
    /// </summary>
    public abstract partial class BaseModel
    {
        public BaseModel()
        {
            Id = Guid.NewGuid().ToString();
        }

        /// <summary>
        /// Gets or sets the model identifier
        /// </summary>
        public virtual string Id { get; set; }
    }
}
