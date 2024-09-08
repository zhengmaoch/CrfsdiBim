using System.ComponentModel;

namespace CrfsdiBim.Core.Domain.Projects
{
    /// <summary>
    /// 线路类型
    /// </summary>
    public enum RouteType
    {
        /// <summary>
        /// 铁路
        /// </summary>
        [Description("铁路")]
        Railways = 0,

        /// <summary>
        /// 公路
        /// </summary>
        [Description("公路")]
        Highways = 1,

        /// <summary>
        /// 城市道路
        /// </summary>
        [Description("城市道路")]
        Cityways = 2,

        /// <summary>
        /// 地铁
        /// </summary>
        //[Description("地铁")]
        //Subways = 3,
    }
}