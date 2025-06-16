namespace FinShark.API.Data;

public static class QueryableExtensions
{
    public static IQueryable<T> When<T>(this IQueryable<T> query, bool condition,
        Func<IQueryable<T>, IQueryable<T>> action)
    {
        return condition ? action(query) : query;
    }

    public static IQueryable<T> When<T>(this IQueryable<T> query, Func<bool> condition,
        Func<IQueryable<T>, IQueryable<T>> action)
    {
        return condition() ? action(query) : query;
    }
}