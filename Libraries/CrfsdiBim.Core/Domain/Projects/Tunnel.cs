using CrfsdiBim.Core.Common;
using CrfsdiBim.Core.Configuration;
using CrfsdiBim.Core.Domain.Common;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CrfsdiBim.Core.Domain.Projects
{
    /// <summary>
    /// 正洞隧道
    /// </summary>
    //[Table($"{CrfsdiBimConfig.TablePrefix}Tunnel")] // SQLite 不支持
    [Serializable]
    public class Tunnel : TimelyEntity, IActiveEntity, ISoftDeletedEntity, IOrderedEntity
    {
        /// <summary>
        /// 隧道名称
        /// </summary>
        [MaxLength(200)]
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// 线路ID
        /// </summary>
        [MaxLength(200)]
        public string RouteId { get; set; }

        /// <summary>
        /// 线数，单线或双线
        /// </summary>
        [MaxLength(200)]
        public string LineNumber { get; set; }

        /// <summary>
        /// 隧道类型
        /// </summary>
        public TunnelType TunnelType { get; set; }

        /// <summary>
        /// 进口隧线分界里程冠号
        /// </summary>
        [MaxLength(200)]
        public string EntranceBoundaryMileagePrefix { get; set; }

        /// <summary>
        /// 进口隧线分界里程
        /// </summary>
        public double EntranceBoundaryMileage { get; set; }

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
        /// 中心里程冠号
        /// </summary>
        [MaxLength(200)]
        public string CenterMileagePrefix { get; set; }

        /// <summary>
        /// 中心里程
        /// </summary>
        public double CenterMileage { get; set; }

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
        /// 出口隧线分界里程冠号
        /// </summary>
        [MaxLength(200)]
        public string ExitBoundaryMileagePrefix { get; set; }

        /// <summary>
        /// 出口隧线分界里程
        /// </summary>
        public double ExitBoundaryMileage { get; set; }

        /// <summary>
        /// 隧道长度
        /// </summary>
        public double Length { get; set; }

        /// <summary>
        /// 电力电缆槽位置
        /// </summary>
        public int CableSlotOfPower { get; set; }

        /// <summary>
        /// 通信电缆槽位置
        /// </summary>
        public int CableSlotOfCommunication { get; set; }

        /// <summary>
        /// 信号电缆槽位置
        /// </summary>
        public int CableSlotOfSignal { get; set; }

        /// <summary>
        /// 隧道附属要求
        /// </summary>
        [MaxLength(2000)]
        public string AffiliatedRequirements { get; set; }

        /// <summary>
        /// 瓦斯隧道
        /// </summary>
        public bool IsGas { get; set; }

        /// <summary>
        /// 主线
        /// </summary>
        public bool IsMain { get; set; }

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

        [ForeignKey("RouteId")]
        public virtual Route Route { get; set; }
    }
}