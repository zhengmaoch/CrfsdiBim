using CrfsdiBim.Core;
using System.Collections.Generic;

namespace CrfsdiBim.Services;

/// <summary>
/// 通用实体Curd操作接口
/// </summary>
/// <typeparam name="TEntity">实体类型</typeparam>
/// <typeparam name="TKey">实体ID类型</typeparam>
public interface ICrudService<TEntity, in TKey> where TEntity : BaseEntity where TKey : class
{
    /// <summary>
    /// 新增实体
    /// </summary>
    /// <param name="input">实体对象</param>
    void Insert(TEntity input);

    /// <summary>
    /// 新增实体对象集合
    /// </summary>
    /// <param name="entities">实体对象集合</param>
    void Insert(IList<TEntity> entities);

    /// <summary>
    /// 根据ID查询实体对象
    /// </summary>
    /// <param name="id">实体ID</param>
    /// <returns>实体对象</returns>
    TEntity GetById(TKey id);

    /// <summary>
    /// 根据项目ID查询实体对象集合
    /// </summary>
    /// <param name="projectId">项目ID</param>
    /// <returns>实体对象集合</returns>
    IList<TEntity> GetByProjectId(TKey projectId);

    /// <summary>
    /// 根据ID集查询实体对象集合
    /// </summary>
    /// <param name="ids">实体ID集</param>
    /// <returns>实体对象集合</returns>
    IList<TEntity> GetByIds(TKey[] ids);

    /// <summary>
    /// 更新实体
    /// </summary>
    /// <param name="input">实体对象</param>
    void Update(TEntity input);

    /// <summary>
    /// 更新指定的实体对象
    /// </summary>
    /// <param name="entities">实体对象集合</param>
    void Update(IList<TEntity> entities);

    /// <summary>
    /// 删除指定ID的实体对象
    /// </summary>
    /// <param name="id">实体ID</param>
    void Delete(TKey id);

    /// <summary>
    /// 删除指定的实体对象
    /// </summary>
    /// <param name="entity">实体对象</param>
    void Delete(TEntity entity);

    /// <summary>
    /// 删除指定ID集的实体对象
    /// </summary>
    /// <param name="ids">实体ID集</param>
    void DeleteByIds(TKey[] ids);

    /// <summary>
    /// 删除指定的实体对象
    /// </summary>
    /// <param name="entities">实体对象集合</param>
    void Delete(IList<TEntity> entities);

    /// <summary>
    /// 删除全部的实体对象
    /// </summary>
    void Delete();
}