using Uisau.Data.Repositories.Base;
using Uisau.Models;

namespace Uisau.Data.Units;

/// <summary>
/// Unit for management operations.
/// </summary>
public interface IUnitOfWork
{
    /// <summary>
    /// Save changes of entities.
    /// </summary>
    /// <returns>The result code of the operation.</returns>
    Task<int> SaveAsync();

    IGenericRepository<T> GenericRepository<T>() 
        where T : BaseEntity;
}
