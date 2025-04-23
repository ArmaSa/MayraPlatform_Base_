using AutoMapper;
using MayraPlatform.Domain.Entities;

namespace MayraPlatform.Application.Features.UserFeatures.GetAllUser;

public sealed class GetAllUserMapper : Profile
{
    public GetAllUserMapper()
    {
        CreateMap<ApplicationUser, GetAllUserResponse>()
            .ForMember(c=>c.Active , opt=>opt.MapFrom(c=>c.IsActive));
    }
}