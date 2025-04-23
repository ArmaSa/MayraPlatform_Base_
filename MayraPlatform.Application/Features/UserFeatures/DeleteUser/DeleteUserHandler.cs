using MayraPlatform.Application.Common.Exceptions;
using MayraPlatform.Application.Repositories;
using MayraPlatform.Domain.Entities;
using MediatR;

namespace MayraPlatform.Application.Features.UserFeatures.DeleteUser
{
    public class DeleteUserHandler:IRequestHandler<DeleteUserRequest, DeleteUserResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserRepository _userRepository;

        public DeleteUserHandler(IUnitOfWork unitOfWork, IUserRepository userRepository)
        {
            _unitOfWork = unitOfWork;
            _userRepository = userRepository;
        }

        public async Task<DeleteUserResponse> Handle(DeleteUserRequest request, CancellationToken cancellationToken)
        {
            ApplicationUser userEntiry = await _userRepository.GetByEmail(request.Email, cancellationToken);

            if(userEntiry == null)
            {
                throw new NotFoundException("user not found!");
            }

            _userRepository.Delete(userEntiry);
            await _unitOfWork.SaveAsync(cancellationToken);
            return new DeleteUserResponse() { Message = $"User with email: {request.Email} not found!" };
        }
    }
}
