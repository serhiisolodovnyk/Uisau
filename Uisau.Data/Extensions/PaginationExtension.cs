namespace Uisau.Data.Extensions;

/// <summary>
/// Add pagination to query.
/// </summary>
public static class PaginationExtension
{
    /// <summary>
    /// Max page size for database query.
    /// </summary>
    public const int MaxPageSize = 1000;

    /// <summary>
    /// Get page.
    /// </summary>
    /// <param name="query">Query to data source.</param>
    /// <param name="page">Number page. Default: 0. </param>
    /// <param name="pageSize">Page size. If 0 - the maximum value will be set to 1000. </param>
    /// <typeparam name="T">Type entity.</typeparam>
    /// <returns>IQueryable with configured query for take only the one page.</returns>
    /// <exception cref="ArgumentOutOfRangeException">Incorrect size of page or page number.</exception>
    public static IQueryable<T> GetPage<T>(this IQueryable<T> query, int page = 0, int pageSize = 0)
    {
        switch (pageSize)
        {
            case >= 0 and <= MaxPageSize:
            {
                // if pageSize == 0 than we try take page with max length
                if (pageSize == 0)
                {
                    pageSize = MaxPageSize;
                }

                query = page switch
                {
                    > 0 => query.Skip(pageSize * page).Take(pageSize),
                    0 => query.Take(pageSize),
                    _ => throw new ArgumentOutOfRangeException(nameof(page), $"Number page cannot be less than 0, but it is : {page}"),
                };
                break;
            }

            case < 0:
                throw new ArgumentOutOfRangeException(
                    nameof(pageSize),
                    $"Size of page cannot be less than 0, but it is : {pageSize}");

            case > MaxPageSize:
                throw new ArgumentOutOfRangeException(
                    nameof(pageSize),
                    $"Size of page cannot be more than {MaxPageSize}, but it is : {pageSize}");
        }

        return query;
    }
}
