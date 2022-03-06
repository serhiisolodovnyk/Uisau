using Uisau.Data.Repositories.Base;
using Uisau.Models;

namespace Uisau.Data.Units;

/// <summary>
/// Unit for management operations.
/// </summary>
public class UnitOfWork : IDisposable, IUnitOfWork
{
    private readonly DataContext _dataContext;

    private readonly Dictionary<Type, object> _genericRepositories = new Dictionary<Type, object>();

    /// <summary>
    /// Initializes a new instance of the <see cref="UnitOfWork"/> class.
    /// </summary>
    /// <param name="dataContext">DataContext.</param>
    public UnitOfWork(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    /// <summary>
    /// Save changes of entities.
    /// </summary>
    /// <returns>The result code of the operation.</returns>
    public Task<int> SaveAsync()
        => _dataContext.SaveChangesAsync();

    /// <inheritdoc />
    public IGenericRepository<T> GenericRepository<T>()
        where T : BaseEntity
    {
        if (_genericRepositories.TryGetValue(typeof(T), out var obj) && obj is GenericRepository<T> repository)
        {
            return repository;
        }

        repository = new GenericRepository<T>(_dataContext);
        _genericRepositories.Add(typeof(T), repository);
        
        return repository;
    }

    /// <summary>
    /// Dispose of the instance.
    /// </summary>
    public void Dispose()
    {
        // Dispose DataContext
        _dataContext.Dispose();

        // Call GC.SuppressFinalize to take this object off the finalization
        //  queue and prevent finalization code for this object from
        //  executing a second time.
        GC.SuppressFinalize(this);
    }
}
