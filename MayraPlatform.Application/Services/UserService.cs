using MayraPlatform.Application.Repositories;
using MayraPlatform.Domain.Entities;

namespace MayraPlatform.Application.Services
{
    public interface IUserService
    {
        Task<List<ApplicationUser>> GetAllUsers(CancellationToken cancellationToken);
    }

    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public Task<List<ApplicationUser>> GetAllUsers(CancellationToken cancellationToken)
        {
            return _userRepository.GetAll(cancellationToken);
        }
    }
}
