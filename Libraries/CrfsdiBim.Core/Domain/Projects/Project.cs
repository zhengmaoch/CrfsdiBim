using System;

namespace CrfsdiBim.Core.Domain.Projects;

/// <summary>
/// 工程项目
/// 用单例模式来使用，主要用于对项目文件夹目录的管理
/// 一个项目默认管理一个线路，所有的数据都用项目ID作为关联标识
/// </summary>
[Serializable]
public class Project : BaseEntity
{
    /// <summary>
    /// 项目路径
    /// </summary>
    public string Path { get; set; }

    /// <summary>
    /// 项目名称
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// 项目日志文件路径
    /// </summary>
    public readonly string LogFilePath = @"00_项目数据\02_Logs";

    /// <summary>
    /// 项目数据库文件路径
    /// </summary>
    public readonly string DatabaseFilePath = @"00_项目数据\01_数据库";

    /// <summary>
    /// 项目数据库文件名称
    /// </summary>
    public readonly string DatabaseFileName = "TOCSSQLite.db";

    /// <summary>
    /// 设计说明
    /// </summary>
    public readonly string DescriptionFilePath = @"01_项目数据存储\02_本专业数据\01_设计说明素材";

    /// <summary>
    /// 数据库链接字符串
    /// </summary>
    [NonSerialized]
    public string ConnectionString;

    /// <summary>
    /// 项目类型
    /// </summary>
    public RouteType Type { get; set; }

    /// <summary>
    /// 当前线路ID
    /// </summary>
    public string CurrentRouteId { get; set; }

    /// <summary>
    /// 当前线路
    /// </summary>
    //[NonSerialized]
    public Route CurrentRoute { get; set; }

    /// <summary>
    /// 当前隧道ID
    /// </summary>
    public string CurrentTunnelId { get; set; }

    ///// <summary>
    ///// 当前隧道
    ///// </summary>
    //[NonSerialized]
    public Tunnel CurrentTunnel;

    #region 非结构化数据标志符与版本符

    #region 地形

    /// <summary>
    /// 地形数据读取标志符
    /// </summary>
    public bool DXDataFlag = true;

    /// <summary>
    /// 地形数据读入版本号
    /// </summary>
    public string DXDataVersion = "";

    /// <summary>
    /// 地形数据处理标志符
    /// </summary>
    public bool DXDealFlag = false;

    /// <summary>
    /// 地形数据处理版本号
    /// </summary>
    public string DXDataDealVersion = "";

    /// <summary>
    /// 地形数据载入参照标志符
    /// </summary>
    public bool DXDataLoadFlag = false;

    #endregion 地形

    #endregion 非结构化数据标志符与版本符
}