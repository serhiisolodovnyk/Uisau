using Uisau.Models;

namespace Uisau.Data.Repositories.Base;

/// <summary>
/// Repository for editable entities.
/// </summary>
/// <typeparam name="T">Type entity.</typeparam>
public interface IGenericRepository<T>
    where T : BaseEntity
{
    /// <summary>
    /// Add new entity to EF.
    /// </summary>
    /// <param name="entity">New entity.</param>
    void Create(T entity);

    /// <summary>
    /// Delete entity.
    /// </summary>
    /// <param name="entity">Deleted entity.</param>
    void Delete(T entity);
    
    /// <summary>
    /// Get list entities.
    /// </summary>
    /// <param name="page">Number page. Default: 0. </param>
    /// <param name="pageSize">Page size. If 0 - the maximum value will be set to 1000.</param>
    /// <returns>List entities.</returns>
    Task<List<T>> GetListAsync(int page = 0, int pageSize = 0);

    /// <summary>
    /// Get entity by Id.
    /// </summary>
    /// <param name="id">Id of entity.</param>
    /// <returns>Entity.</returns>
    Task<T?> GetAsync(Guid id);

    /// <summary>
    /// Check is the entity exist.
    /// </summary>
    /// <param name="id">Id of the entity.</param>
    /// <returns>True if the entity is exist, otherwise - false.</returns>
    public Task<bool> ExistAsync(Guid id);
}
