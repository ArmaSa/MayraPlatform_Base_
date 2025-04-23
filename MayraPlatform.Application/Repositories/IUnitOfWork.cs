namespace MayraPlatform.Application.Repositories;

public interface IUnitOfWork
{
    Task SaveAsync(CancellationToken cancellationToken);
}