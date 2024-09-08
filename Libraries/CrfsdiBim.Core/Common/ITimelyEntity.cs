using System;

namespace CrfsdiBim.Core.Common;

/// <summary>
/// 基于时间的同步模型，用于云同步的属性
/// </summary>
public partial interface ITimelyEntity
{
    /// <summary>
    /// Gets or sets the date and time of instance creation
    /// </summary>
    DateTime CreatedOn { get; set; }

    /// <summary>
    /// Gets or sets the date and time of instance update
    /// </summary>
    DateTime UpdatedOn { get; set; }
}