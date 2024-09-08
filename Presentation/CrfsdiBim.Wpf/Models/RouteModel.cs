using CrfsdiBim.Core.Domain.Projects;
using CrfsdiBim.Wpf.Framework.Mvvm.Models;
using System.Collections.Generic;

namespace CrfsdiBim.Core.Domain
{
    /// <summary>
    /// 线路模型
    /// 一个项目管理一个线路，一个线路有多个隧道。
    /// </summary>
    public class RouteModel : TimelyBaseModel
    {
        private ICollection<TunnelModel> _tunnels;

        /// <summary>
        /// 线路名称
        /// </summary>

        public string Name { get; set; }

        /// <summary>
        /// 线路类型
        /// </summary>

        public RouteType RouteType { get; set; }

        /// <summary>
        /// 进口里程冠号
        /// </summary>

        public string EntranceMileagePrefix { get; set; }

        /// <summary>
        /// 进口里程
        /// </summary>
        public double EntranceMileage { get; set; }

        /// <summary>
        /// 进口方向地名
        /// </summary>

        public string EntranceDirectionArea { get; set; }

        /// <summary>
        /// 出口里程冠号
        /// </summary>

        public string ExitMileagePrefix { get; set; }

        /// <summary>
        /// 出口里程
        /// </summary>
        public double ExitMileage { get; set; }

        /// <summary>
        /// 出口方向地名
        /// </summary>

        public string ExitDirectionArea { get; set; }

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
        /// Gets or sets the state/provinces
        /// </summary>
        public virtual ICollection<TunnelModel> Tunnels
        {
            get { return _tunnels ?? (_tunnels = new List<TunnelModel>()); }
            protected set { _tunnels = value; }
        }
    }
}