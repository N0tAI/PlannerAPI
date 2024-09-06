namespace TaskPlanner.API.Database.Entities;

/// <summary>
/// Unified interface for defining Id types
/// </summary>
public interface IKeyedDbEntity : IDbEntity
{
    public long Id { get; }
}
