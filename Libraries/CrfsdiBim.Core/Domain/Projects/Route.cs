using CrfsdiBim.Core.Common;
using CrfsdiBim.Core.Configuration;
using CrfsdiBim.Core.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CrfsdiBim.Core.Domain.Projects;

/// <summary>
/// 线路
/// 一个项目来管理一条线路，一个线路可能有零或多个隧道。
/// </summary>
//[Table($"{CrfsdiBimConfig.TablePrefix}Route")]
[Serializable]
public class Route : TimelyEntity, IActiveEntity, ISoftDeletedEntity, IOrderedEntity
{
    private List<Tunnel> _tunnels;

    /// <summary>
    /// 线路名称
    /// </summary>
    [MaxLength(200)]
    [Required]
    public string Name { get; set; }

    /// <summary>
    /// 线路类型
    /// </summary>
    [Required]
    public RouteType RouteType { get; set; }

    /// <summary>
    /// 进口里程冠号
    /// </summary>
    [MaxLength(200)]
    public string EntranceMileagePrefix { get; set; }

    /// <summary>
    /// 进口里程
    /// </summary>
    public double EntranceMileage { get; set; }

    /// <summary>
    /// 进口方向地名
    /// </summary>
    [MaxLength(200)]
    public string EntranceDirectionArea { get; set; }

    /// <summary>
    /// 出口里程冠号
    /// </summary>
    [MaxLength(200)]
    public string ExitMileagePrefix { get; set; }

    /// <summary>
    /// 出口里程
    /// </summary>
    public double ExitMileage { get; set; }

    /// <summary>
    /// 出口方向地名
    /// </summary>
    [MaxLength(200)]
    public string ExitDirectionArea { get; set; }

    /// <summary>
    /// Gets or sets the description
    /// </summary>
    [MaxLength(2000)]
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
    /// Gets or sets the state/provinces
    /// </summary>
    public virtual List<Tunnel> Tunnels
    {
        get { return _tunnels ?? (_tunnels = new List<Tunnel>()); }
        protected set { _tunnels = value; }
    }
}