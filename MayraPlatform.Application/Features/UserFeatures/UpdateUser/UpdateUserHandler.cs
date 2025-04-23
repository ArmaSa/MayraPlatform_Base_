using AutoMapper;
using MayraPlatform.Application.Common.Exceptions;
using MayraPlatform.Application.Repositories;
using MayraPlatform.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;

namespace MayraPlatform.Application.Features.UserFeatures.UpdateUser
{
    public class UpdateUserHandler:IRequestHandler<UpdateUserRequest , UpdateUserResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UpdateUserHandler(IUnitOfWork unitOfWork, IUserRepository userRepository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<UpdateUserResponse> Handle(UpdateUserRequest request , CancellationToken cancellationToken)
        {
            ApplicationUser user = await _userRepository.GetByEmail(request.Email, cancellationToken);
            if (user == null)
            {
                throw new NotFoundException("user not found!");
            }

            _mapper.Map(request, user);
            _userRepository.Update(user);
            await _unitOfWork.SaveAsync(cancellationToken);

            return new UpdateUserResponse() { Email = user.Email , FirstName = user.FirstName,lastName = user.lastName , BirthDate = user.BirthDate };

        }
    }
}
