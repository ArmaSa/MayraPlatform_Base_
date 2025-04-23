using AutoMapper;
using MayraPlatform.Application.Features.UserFeatures.CreateUser;
using MayraPlatform.Application.Features.UserFeatures.UpdateUser;
using MayraPlatform.Domain.Entities;

namespace MayraPlatform.Application.Features.UserFeatures.Validator;

public sealed class UserMapper : Profile
{
    public UserMapper()
    {
        CreateMap<CreateUserRequest, ApplicationUser>()
            .ForMember(c=>c.FullName , opt=>opt.MapFrom(f=>$"{f.FirstName}{f.LastName}"));
        CreateMap<ApplicationUser, CreateUserResponse>();

        CreateMap<UpdateUserRequest, ApplicationUser>()
            .ForMember(c => c.Id, opt => opt.Ignore());
        CreateMap<ApplicationUser, UpdateUserResponse>();
    }
}