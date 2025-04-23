using MediatR;

namespace MayraPlatform.Application.Features.UserFeatures.CreateUser;

public sealed record CreateUserRequest(
    string Email, 
    string FirstName,
    string LastName,
    string PhoneNumber,
    DateTime BirthDate

    ) : IRequest<CreateUserResponse>;