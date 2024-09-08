using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrfsdiBim.Core.Domain.Projects
{
    /// <summary>
    /// 隧道类型
    /// </summary>
    public enum TunnelType
    {
        /// <summary>
        /// 正洞
        /// </summary>
        [Description("正洞")]
        MainTunnel,

        /// <summary>
        /// 斜井
        /// </summary>
        [Description("斜井")]
        InclinedShaft,

        /// <summary>
        /// 横洞
        /// </summary>
        [Description("横洞")]
        TransverseTunnel,

        /// <summary>
        /// 竖井
        /// </summary>
        [Description("竖井")]
        VerticalShaft,

        /// <summary>
        /// 平导
        /// </summary>
        [Description("平导")]
        ParallelHeading,

        /// <summary>
        /// 横通道
        /// </summary>
        [Description("横通道")]
        TransversePassage,
    }
}
