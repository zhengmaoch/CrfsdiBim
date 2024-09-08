using CommunityToolkit.Mvvm.ComponentModel;
using CrfsdiBim.Core.Common;
using CrfsdiBim.Core.Domain.Projects;
using CrfsdiBim.Core.Infrastructure;

namespace CrfsdiBim.Wpf.Framework.Mvvm.Models
{
    /// <summary>
    /// Base class for models
    /// </summary>
    public partial class BaseModel : ObservableObject
    {
    }

    /// <summary>
    /// Base class for models
    /// </summary>
    public partial class BaseEntityModel : BaseModel
    {
        public BaseEntityModel()
        {
            Id = SequentialGuidGenerator.Create().ToString();
        }

        /// <summary>
        /// Gets or sets the model identifier
        /// </summary>
        public virtual string Id { get; set; }

        /// <summary>
        /// Gets or sets the project identifier
        /// </summary>
        public string ProjectId { get; set; } = Singleton<Project>.Instance?.Id;
    }
}