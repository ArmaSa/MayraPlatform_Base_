using MediatR;

namespace MayraPlatform.Application.Features.UserFeatures.UpdateUser;

public sealed record UpdateUserRequest
    (string Email,
    string FirstName,
    string LastName,
    DateTime BirthDate
    ) : IRequest<UpdateUserResponse>;