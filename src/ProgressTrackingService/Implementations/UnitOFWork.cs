using ProgressTrackingService.Implementations.Repositories;
using ProgressTrackingService.Interfaces;
using ProgressTrackingService.Interfaces.Repositories;
using ProgressTrackingService.Persistence;

namespace ProgressTrackingService.Implementations;

public class UnitOFWork(ApplicationDbContext context) : IUnitOfWork
{
    private readonly Dictionary<Type, object> _repositories = [];

    public IGenericRepository<T> Repository<T>() where T : class
    {
        var type = typeof(T);

        if (_repositories.TryGetValue(type, out var repository))
            return (IGenericRepository<T>)repository;

        var newRepository = new GenericRepository<T>(context);

        _repositories.Add(type, newRepository);

        return newRepository;
    }

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default) =>
        await context.SaveChangesAsync(cancellationToken);
}
