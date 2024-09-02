namespace TaskPlanner.API.Querying;

public interface ITypeMapper<TOutput, TInput>
{
    TOutput Map(TInput input);
}
