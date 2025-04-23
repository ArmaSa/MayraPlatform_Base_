namespace MayraPlatform.Application.Features.UserFeatures.UpdateUser;

public sealed record UpdateUserResponse
{
    public string Email { get; set; }
    public string FirstName { get; set; }
    public string lastName { get; set; }
    public DateTime BirthDate { get; set; }
}