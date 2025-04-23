using MayraPlatform.Domain.Common;
using MayraPlatform.Domain.Common;

namespace MayraPlatform.Application.Repositories;

public interface IBaseRepository<T> where T : class, IBaseEntity
{
    void Create(T entity);
    void Update(T entity);
    void Delete(T entity);
    Task<T> GetById(long id, CancellationToken cancellationToken);
    Task<List<T>> GetAll(CancellationToken cancellationToken);
}