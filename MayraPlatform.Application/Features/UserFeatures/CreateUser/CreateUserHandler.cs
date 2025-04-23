using AutoMapper;
using MayraPlatform.Application.Repositories;
using MayraPlatform.Domain.Entities;
using MediatR;

namespace MayraPlatform.Application.Features.UserFeatures.CreateUser;

public sealed class CreateUserHandler : IRequestHandler<CreateUserRequest, CreateUserResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public CreateUserHandler(IUnitOfWork unitOfWork, IUserRepository userRepository, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _userRepository = userRepository;
        _mapper = mapper;
    }
    
    public async Task<CreateUserResponse> Handle(CreateUserRequest request, CancellationToken cancellationToken)
    {
        var user = _mapper.Map<ApplicationUser>(request);
        user.TenantId = 1; // customer is default
        _userRepository.Create(user);
        await _unitOfWork.SaveAsync(cancellationToken);

        return _mapper.Map<CreateUserResponse>(user);
    }
}