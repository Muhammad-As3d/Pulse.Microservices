using Microsoft.EntityFrameworkCore;
using ProgressTrackingService.Interfaces.Repositories;
using ProgressTrackingService.Persistence;

namespace ProgressTrackingService.Implementations.Repositories;

public class GenericRepository<T>(ApplicationDbContext context) : IGenericRepository<T> where T : class
{
    private readonly DbSet<T> _dbSet = context.Set<T>();

    public IQueryable<T> GetQueryable() => _dbSet;

    public async Task AddAsync(T entity, CancellationToken cancellationToken = default) =>
        await _dbSet.AddAsync(entity, cancellationToken);

}
