using MayraPlatform.Application.Repositories;
using MayraPlatform.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using MayraPlatform.Persistence.Context;

namespace MayraPlatform.Persistence.Repositories;

public class UserRepository : BaseRepository<ApplicationUser>, IUserRepository
{
    public UserRepository(ApplicationDbContext context) : base(context)
    {
    }
    
    public Task<ApplicationUser> GetByEmail(string email, CancellationToken cancellationToken)
    {
        return Context.Users.FirstOrDefaultAsync(x => x.Email == email, cancellationToken);
    }
}