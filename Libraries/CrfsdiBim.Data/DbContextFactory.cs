using CrfsdiBim.Core.Infrastructure;

namespace CrfsdiBim.Data;

/// <summary>
/// DbContext 工厂方法
/// </summary>
public class DbContextFactory : IDbContextFactory
{
    /// <summary>
    /// 根据链接字符串创建DbContext实例对象
    /// </summary>
    /// <param name="connectionString">链接字符串</param>
    /// <returns>DbContext实例对象</returns>
    public CrfsdiBimObjectContext CreateDbContext(string connectionString)
    {
        if (Singleton<CrfsdiBimObjectContext>.Instance == null || connectionString != Singleton<CrfsdiBimObjectContext>.Instance.ConnectionString)
        {
            Singleton<CrfsdiBimObjectContext>.Instance = new CrfsdiBimObjectContext(connectionString);
        }

        return Singleton<CrfsdiBimObjectContext>.Instance;
    }
}