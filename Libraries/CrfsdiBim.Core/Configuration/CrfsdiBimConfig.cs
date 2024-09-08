using System.IO;
using System.Reflection;

namespace CrfsdiBim.Core.Configuration
{
    /// <summary>
    /// Represents startup CrfsdiBim configuration parameters
    /// </summary>
    public partial class CrfsdiBimConfig
    {
        /// <summary>
        /// Gets or sets current executing assembly path.
        /// </summary>
        public static string AssemblyPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

        /// <summary>
        /// Gets or sets current database connection string.
        /// </summary>
        public static string ConnectionString = $@"data source={AssemblyPath}\AppData\CrfsdiBimSQLite.db;Version=3;";

        /// <summary>
        /// 数据库表名前缀
        /// </summary>
        public const string TablePrefix = "";

        /// <summary>
        /// 项目文件扩展名
        /// </summary>
        public static readonly string ProjectSettingFileExtensionsName = "crfsdibimproj";
    }
}