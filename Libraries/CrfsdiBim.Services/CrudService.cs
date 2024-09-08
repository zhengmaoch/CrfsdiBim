using CrfsdiBim.Core;
using CrfsdiBim.Core.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace CrfsdiBim.Services;

/// <summary>
/// 通用实体Curd操作实现
/// </summary>
/// <typeparam name="TEntity">实体类型</typeparam>
/// <typeparam name="TKey">实体ID类型</typeparam>
public class CrudService<TEntity, TKey> : ICrudService<TEntity, TKey> where TEntity : BaseEntity where TKey : class
{
    protected IRepository<TEntity> _repository;

    protected CrudService(IRepository<TEntity> repository)
    {
        _repository = repository;
    }

    /// <summary>
    /// 新增实体
    /// </summary>
    /// <param name="input">实体对象</param>
    public void Insert(TEntity input)
    {
        if (input == null)
            throw new ArgumentNullException(nameof(input));

        _repository.Insert(input);
    }

    /// <summary>
    /// 新增实体对象集合
    /// </summary>
    /// <param name="entities">实体对象集合</param>
    public void Insert(IList<TEntity> entities)
    {
        if (entities == null)
            throw new ArgumentNullException(nameof(entities));

        _repository.Insert(entities);
    }

    /// <summary>
    /// 根据ID查询实体对象
    /// </summary>
    /// <param name="id">实体ID</param>
    /// <returns>实体对象</returns>
    public TEntity GetById(TKey id)
    {
        if (id == null)
            throw new ArgumentNullException(nameof(id));

        return _repository.GetById(id);
    }

    /// <summary>
    /// 更新实体
    /// </summary>
    /// <param name="input">实体对象</param>
    public void Update(TEntity input)
    {
        if (input == null)
            throw new ArgumentNullException(nameof(input));

        _repository.Update(input);
    }

    /// <summary>
    /// 更新指定的实体对象
    /// </summary>
    /// <param name="entities">实体对象集合</param>
    public void Update(IList<TEntity> entities)
    {
        if (entities == null)
            throw new ArgumentNullException(nameof(entities));

        _repository.Update(entities);
    }

    /// <summary>
    /// 根据项目ID查询实体对象集合
    /// </summary>
    /// <param name="projectId">项目ID</param>
    /// <returns>实体对象集合</returns>
    public IList<TEntity> GetByProjectId(TKey projectId)
    {
        if (projectId == null)
            throw new ArgumentNullException(nameof(projectId));

        var query = from t in _repository.Table
                    where t.ProjectId == projectId.ToString()
                    select t;
        var entities = query.ToList();
        return entities;
    }

    /// <summary>
    /// 根据ID集查询实体对象集合
    /// </summary>
    /// <param name="ids">实体ID集</param>
    /// <returns>实体对象集合</returns>
    public IList<TEntity> GetByIds(TKey[] ids)
    {
        if (ids == null || ids.Length == 0)
            return new List<TEntity>();

        string[] stringIds = new string[ids.Length];
        for (int i = 0; i < stringIds.Length; i++)
        {
            stringIds[i] = ids[i].ToString();
        }

        var query = from t in _repository.Table
                    where stringIds.Contains(t.Id)
                    select t;
        var entities = query.ToList();
        //sort by passed identifiers
        var sortedEntities = new List<TEntity>();
        foreach (var id in ids)
        {
            var entity = entities.Find(x => x.Id == id.ToString());
            if (entity != null)
                sortedEntities.Add(entity);
        }
        return sortedEntities;
    }

    /// <summary>
    /// 删除指定ID的实体对象
    /// </summary>
    /// <param name="id">实体ID</param>
    public void Delete(TKey id)
    {
        if (id == null)
            throw new ArgumentNullException(nameof(id));

        _repository.Delete(_repository.GetById(id));
    }

    /// <summary>
    /// 删除指定的实体对象
    /// </summary>
    /// <param name="entity">实体对象</param>
    public void Delete(TEntity entity)
    {
        if (entity == null)
            throw new ArgumentNullException(nameof(entity));

        _repository.Delete(entity);
    }

    /// <summary>
    /// 删除指定ID集的实体对象
    /// </summary>
    /// <param name="ids">实体ID集</param>
    public void DeleteByIds(TKey[] ids)
    {
        if (ids == null || ids.Length == 0)
            throw new ArgumentNullException(nameof(ids));

        Delete(GetByIds(ids));
    }

    /// <summary>
    /// 删除指定的实体对象
    /// </summary>
    /// <param name="entities">实体对象集合</param>
    public void Delete(IList<TEntity> entities)
    {
        if (entities == null)
            throw new ArgumentNullException(nameof(entities));

        _repository.Delete(entities);
    }

    /// <summary>
    /// 删除全部的实体对象
    /// </summary>
    public void Delete()
    {
        _repository.Delete();
    }
}