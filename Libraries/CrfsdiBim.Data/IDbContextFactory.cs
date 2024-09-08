namespace CrfsdiBim.Data;

/// <summary>
/// DbContext 工厂方法
/// </summary>
public interface IDbContextFactory
{
    /// <summary>
    /// 根据链接字符串创建DbContext实例对象
    /// </summary>
    /// <param name="connectionString">链接字符串</param>
    /// <returns>DbContext实例对象</returns>
    CrfsdiBimObjectContext CreateDbContext(string connectionString);
}