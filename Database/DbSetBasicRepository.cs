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

    public virtual IEnumerable<TModel> GetAll()
        => _modelSet.AsEnumerable();
    public IEnumerable<TModel> GetAll(params Expression<Func<TModel, bool>>[] filters)
        => GetAll(filters.AsEnumerable());
    public virtual IEnumerable<TModel> GetAll(IEnumerable<Expression<Func<TModel, bool>>> filters)
    {
        IQueryable<TModel> query = _modelSet;

        foreach(var filter in filters)
            query = ApplyFilter(query, filter);
        
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
    public virtual bool TryCreate(TModel model)
    {
        var numAdded = Create(model);
        return numAdded > 0;
    }

    public virtual int Update(TModel model)
    {
        _modelSet.Update(model);
        return _context.SaveChanges();
    }
    public virtual bool TryUpdate(TModel model)
    {
        var numUpdated = Update(model);
        return numUpdated > 0;
    }

    public virtual int Delete(TModel model)
    {
        _context.Remove(model);
        return _context.SaveChanges();
    }
    public virtual bool TryDelete(TModel model)
    {
        var numRemoved = Delete(model);
        return numRemoved > 0;
    }
}
