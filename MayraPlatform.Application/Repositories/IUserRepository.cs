using MayraPlatform.Domain.Entities;

namespace MayraPlatform.Application.Repositories;

public interface IUserRepository : IBaseRepository<ApplicationUser>
{
    Task<ApplicationUser> GetByEmail(string email, CancellationToken cancellationToken);
}