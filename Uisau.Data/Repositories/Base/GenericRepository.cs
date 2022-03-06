using Microsoft.EntityFrameworkCore;
using Uisau.Data.Extensions;
using Uisau.Models;

namespace Uisau.Data.Repositories.Base;

/// <summary>
/// Repository for editable entities.
/// </summary>
/// <typeparam name="T">Entity type.</typeparam>
public class GenericRepository<T> : IGenericRepository<T>
    where T : BaseEntity
{
    protected readonly DbContext DbContext;
    
    /// <summary>
    /// Initializes a new instance of the <see cref="GenericRepository{T}"/> class.
    /// </summary>
    /// <param name="dbContext">DbContext.</param>
    internal GenericRepository(DbContext dbContext)
    {
        DbContext = dbContext;
    }

    /// <summary>
    /// Create new entity.
    /// </summary>
    /// <param name="entity">New entity.</param>
    public virtual void Create(T entity)
    {
        DbContext.Add(entity);
    }

    /// <summary>
    /// Delete entity.
    /// </summary>
    /// <param name="entity">Deleted entity.</param>
    public virtual void Delete(T entity)
    {
        DbContext.Remove(entity);
    }
    
    /// <inheritdoc />
    public Task<List<T>> GetListAsync(int page = 0, int pageSize = 0)
        => DbContext
            .Set<T>()
            .AsNoTracking()
            .GetPage(page, pageSize)
            .ToListAsync();

    /// <inheritdoc />
    public Task<T?> GetAsync(Guid id)
        => DbContext.Set<T>().FirstOrDefaultAsync(entity => entity.Id == id);

    /// <inheritdoc />
    public Task<bool> ExistAsync(Guid id)
        => DbContext.Set<T>().AnyAsync(entity => entity.Id == id);
}
