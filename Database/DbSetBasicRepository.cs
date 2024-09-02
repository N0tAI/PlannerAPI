using System;
using System.Linq.Expressions;
using Castle.Components.DictionaryAdapter;
using Microsoft.EntityFrameworkCore;

namespace TaskPlanner.API.Database;

public abstract class DbSetBasicRepository<TModel>(DbContext context, DbSet<TModel> modelSet)
    where TModel : class
{
    private DbContext _context = context;
    private DbSet<TModel> _modelSet = modelSet;

    protected IQueryable<T> ApplyFilter<T>(IQueryable<T> query, Expression<Func<T, bool>> filter)
        => query.Where(filter);

    public virtual IEnumerable<TModel> GetAll(bool lazyLoad = true)
    {
        IQueryable<TModel> query = _modelSet;
        if(!lazyLoad)
            return query.ToList();
        return query.AsEnumerable();
    }
    public IEnumerable<TModel> GetAll(bool lazyLoad = true, params Expression<Func<TModel, bool>>[] filters)
        => GetAll(filters.AsEnumerable(), lazyLoad);
    public virtual IEnumerable<TModel> GetAll(IEnumerable<Expression<Func<TModel, bool>>> filters, bool lazyLoad = true)
    {
        IQueryable<TModel> query = _modelSet;

        foreach(var filter in filters)
            query = ApplyFilter(query, filter);
        
        if(!lazyLoad)
            return query.ToList();

        return query.AsEnumerable();
    }
    
    public TModel GetOne(params Expression<Func<TModel, bool>>[] filters)
        => GetOne(filters);
    public virtual TModel GetOne(IEnumerable<Expression<Func<TModel, bool>>> filters)
        => TryGetOne(filters) ?? throw new ArgumentException("No model matching filters found");
    public TModel? TryGetOne(params Expression<Func<TModel, bool>>[] filters)
        => TryGetOne(filters);
    public virtual TModel? TryGetOne(IEnumerable<Expression<Func<TModel, bool>>> filters)
    {
        if(filters.Count() == 0)
            throw new ArgumentException("Must provide a filter when retrieving a model");
        
        IQueryable<TModel> query = _modelSet;

        foreach(var filter in filters)
            query = ApplyFilter(query, filter);
        
        return query.FirstOrDefault();
    }

    public bool TryGetOne(out TModel? model, params Expression<Func<TModel, bool>>[] filters)
        => TryGetOne(out model, filters);
    public bool TryGetOne(out TModel? model, IEnumerable<Expression<Func<TModel, bool>>> filters)
    {
        model = TryGetOne(filters);
        if(model is null)
            return false;
        return true;
    }

    public virtual int Create(TModel model)
    {
        _modelSet.Add(model);
        return _context.SaveChanges();
    }
    public virtual int Create(params TModel[] models)
    {
        _modelSet.AddRange(models);
        return _context.SaveChanges();
    }
    public virtual int Create(IEnumerable<TModel> models)
    {
        _modelSet.AddRange(models);
        return _context.SaveChanges();
    }

    public virtual int Update(TModel model)
    {
        _modelSet.Update(model);
        return _context.SaveChanges();
    }
    public virtual int Update(params TModel[] models)
    {
        _modelSet.UpdateRange(models);
        return _context.SaveChanges();
    }
    public virtual int Update(IEnumerable<TModel> models)
    {
        _modelSet.UpdateRange(models);
        return _context.SaveChanges();
    }

    public virtual int Delete(TModel model)
    {
        _context.Remove(model);
        return _context.SaveChanges();
    }
    public virtual int Delete(params TModel[] models)
    {
        _modelSet.RemoveRange(models);
        return _context.SaveChanges();
    }
    public virtual int Delete(IEnumerable<TModel> models)
    {
        _modelSet.RemoveRange(models);
        return _context.SaveChanges();
    }
}
