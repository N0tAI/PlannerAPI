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

    public virtual IEnumerable<TModel> GetAll(params Expression<Func<TModel, bool>>[] filters)
    {
        var filterSize = filters.Count();
        if(filterSize == 0)
            return _modelSet.AsEnumerable();
        
        // Aggregate returns the initial value if the list has size 1
        var filter = filters.Aggregate((e1, e2) => {
            var combinedBody = Expression.AndAlso(e1.Body, e2.Body);
            return Expression.Lambda<Func<TModel, bool>>(combinedBody, e1.Parameters);
        });
        
        return _modelSet.Where(filter).AsEnumerable();
    }
    
    public virtual TModel GetOne(params Expression<Func<TModel, bool>>[] filters)
        => TryGetOne(filters) ?? throw new ArgumentException("No model matching filters found");
    public virtual TModel? TryGetOne(params Expression<Func<TModel, bool>>[] filters)
    {
        var filterSize = filters.Count();
        if(filterSize == 0)
            return _modelSet.FirstOrDefault();
        
        // Aggregate returns the initial value if the list has size 1
        var filter = filters.Aggregate((e1, e2) => {
            var combinedBody = Expression.AndAlso(e1.Body, e2.Body);
            return Expression.Lambda<Func<TModel, bool>>(combinedBody, e1.Parameters);
        });
        
        return _modelSet.FirstOrDefault(filter);
    }
    public bool TryGetOne(out TModel? model, params Expression<Func<TModel, bool>>[] filters)
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
