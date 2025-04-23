namespace MayraPlatform.Application.Features.UserFeatures.GetAllUser;

public sealed record GetAllUserResponse
{
    public string Email { get; set; }
    public string UserName { get; set; }
    public bool Active { get; set; }
    public DateTime BirthDate { get; set; }

    public string FirstName {  get; set; }

    public string LastName { get; set; }
}