namespace ProgressTrackingService.Interfaces.Repositories;

public interface IGenericRepository<T> where T : class
{
    IQueryable<T> GetQueryable();
    Task AddAsync(T entity, CancellationToken cancellationToken = default);
}
