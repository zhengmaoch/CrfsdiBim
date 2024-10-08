﻿using CrfsdiBim.Core;
using CrfsdiBim.Core.Configuration;
using CrfsdiBim.Core.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Data.Entity.Validation;
using System.Linq;

namespace CrfsdiBim.Data;

/// <summary>
/// Entity Framework repository
/// </summary>
public partial class EfRepository<T> : IRepository<T> where T : BaseEntity
{
    #region Fields

    private readonly IDbContextFactory _contextFactory;
    private IDbSet<T> _entities;

    #endregion Fields

    #region Ctor

    /// <summary>
    /// Ctor
    /// </summary>
    /// <param name="context">Object context</param>
    public EfRepository(IDbContextFactory contextFactory)
    {
        this._contextFactory = contextFactory;
    }

    #endregion Ctor

    #region Utilities

    /// <summary>
    /// Get full error
    /// </summary>
    /// <param name="exc">Exception</param>
    /// <returns>Error</returns>
    protected string GetFullErrorText(DbEntityValidationException exc)
    {
        var msg = string.Empty;
        foreach (var validationErrors in exc.EntityValidationErrors)
            foreach (var error in validationErrors.ValidationErrors)
                msg += $"Property: {error.PropertyName} Error: {error.ErrorMessage}" + Environment.NewLine;
        return msg;
    }

    /// <summary>
    /// Rollback of entity changes and return full error message
    /// </summary>
    /// <param name="dbEx">Exception</param>
    /// <returns>Error</returns>
    protected string GetFullErrorTextAndRollbackEntityChanges(DbEntityValidationException dbEx)
    {
        var fullErrorText = GetFullErrorText(dbEx);

        foreach (var entry in dbEx.EntityValidationErrors.Select(error => error.Entry))
        {
            if (entry == null)
                continue;

            //rollback of entity changes
            entry.State = EntityState.Unchanged;
        }

        _contextFactory.CreateDbContext(CrfsdiBimConfig.ConnectionString).SaveChanges();
        return fullErrorText;
    }

    #endregion Utilities

    #region Methods

    /// <summary>
    /// Get entity by identifier
    /// </summary>
    /// <param name="id">Identifier</param>
    /// <returns>Entity</returns>
    public virtual T GetById(object id)
    {
        //see some suggested performance optimization (not tested)
        //http://stackoverflow.com/questions/11686225/dbset-find-method-ridiculously-slow-compared-to-singleordefault-on-id/11688189#comment34876113_11688189
        return Entities.Find(id);
    }

    /// <summary>
    /// Insert entity
    /// </summary>
    /// <param name="entity">Entity</param>
    public virtual void Insert(T entity)
    {
        try
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            Entities.Add(entity);

            _contextFactory.CreateDbContext(CrfsdiBimConfig.ConnectionString).SaveChanges();
        }
        catch (DbEntityValidationException dbEx)
        {
            //ensure that the detailed error text is saved in the Log
            throw new Exception(GetFullErrorTextAndRollbackEntityChanges(dbEx), dbEx);
        }
    }

    /// <summary>
    /// Insert entities
    /// </summary>
    /// <param name="entities">Entities</param>
    public virtual void Insert(IEnumerable<T> entities)
    {
        try
        {
            if (entities == null)
                throw new ArgumentNullException(nameof(entities));

            entities.ForEach(e => Entities.Add(e));

            _contextFactory.CreateDbContext(CrfsdiBimConfig.ConnectionString).SaveChanges();
        }
        catch (DbEntityValidationException dbEx)
        {
            //ensure that the detailed error text is saved in the Log
            throw new Exception(GetFullErrorTextAndRollbackEntityChanges(dbEx), dbEx);
        }
    }

    /// <summary>
    /// Update entity
    /// </summary>
    /// <param name="entity">Entity</param>
    public virtual void Update(T entity)
    {
        try
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            //Entities.Remove(Entities.Where(e => e.Id == entity.Id).FirstOrDefault());
            //Entities.Add(entity);
            Entities.AddOrUpdate(entity);
            _contextFactory.CreateDbContext(CrfsdiBimConfig.ConnectionString).SaveChanges();
        }
        catch (DbEntityValidationException dbEx)
        {
            //ensure that the detailed error text is saved in the Log
            throw new Exception(GetFullErrorTextAndRollbackEntityChanges(dbEx), dbEx);
        }
    }

    /// <summary>
    /// Update entities
    /// </summary>
    /// <param name="entities">Entities</param>
    public virtual void Update(IEnumerable<T> entities)
    {
        try
        {
            if (entities == null)
                throw new ArgumentNullException(nameof(entities));

            entities.ForEach(e => Entities.AddOrUpdate(e));

            _contextFactory.CreateDbContext(CrfsdiBimConfig.ConnectionString).SaveChanges();
        }
        catch (DbEntityValidationException dbEx)
        {
            //ensure that the detailed error text is saved in the Log
            throw new Exception(GetFullErrorTextAndRollbackEntityChanges(dbEx), dbEx);
        }
    }

    /// <summary>
    /// Delete entity
    /// </summary>
    /// <param name="entity">Entity</param>
    public virtual void Delete(T entity)
    {
        try
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            Entities.Remove(entity);

            _contextFactory.CreateDbContext(CrfsdiBimConfig.ConnectionString).SaveChanges();
        }
        catch (DbEntityValidationException dbEx)
        {
            //ensure that the detailed error text is saved in the Log
            throw new Exception(GetFullErrorTextAndRollbackEntityChanges(dbEx), dbEx);
        }
    }

    /// <summary>
    /// Delete entities
    /// </summary>
    /// <param name="entities">Entities</param>
    public virtual void Delete(IEnumerable<T> entities)
    {
        try
        {
            if (entities == null)
                throw new ArgumentNullException(nameof(entities));

            entities.ForEach(e => Entities.Remove(e));

            _contextFactory.CreateDbContext(CrfsdiBimConfig.ConnectionString).SaveChanges();
        }
        catch (DbEntityValidationException dbEx)
        {
            //ensure that the detailed error text is saved in the Log
            throw new Exception(GetFullErrorTextAndRollbackEntityChanges(dbEx), dbEx);
        }
    }

    /// <summary>
    /// Delete all entities
    /// </summary>
    public virtual void Delete()
    {
        try
        {
            foreach (var entity in Entities.Reverse())
                Entities.Remove(entity);

            _contextFactory.CreateDbContext(CrfsdiBimConfig.ConnectionString).SaveChanges();
        }
        catch (DbEntityValidationException dbEx)
        {
            //ensure that the detailed error text is saved in the Log
            throw new Exception(GetFullErrorTextAndRollbackEntityChanges(dbEx), dbEx);
        }
    }

    #endregion Methods

    #region Properties

    /// <summary>
    /// Gets a table
    /// </summary>
    public virtual IQueryable<T> Table
    {
        get
        {
            return Entities;
        }
    }

    /// <summary>
    /// Gets a table with "no tracking" enabled (EF feature) Use it only when you load record(s) only for read-only operations
    /// </summary>
    public virtual IQueryable<T> TableNoTracking
    {
        get
        {
            return Entities.AsNoTracking();
        }
    }

    /// <summary>
    /// Entities
    /// </summary>
    protected virtual IDbSet<T> Entities
    {
        get
        {
            //if (_entities == null)
            _entities = _contextFactory.CreateDbContext(CrfsdiBimConfig.ConnectionString).Set<T>();
            return _entities;
        }
    }

    #endregion Properties
}