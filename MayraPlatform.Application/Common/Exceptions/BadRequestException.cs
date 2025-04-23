namespace MayraPlatform.Application.Common.Exceptions;
public class BadRequestException : Exception
{
    public string[] Errors { get; }

    public BadRequestException(string message) : base(message)
    {
        Errors = new[] { message };
    }

    public BadRequestException(string[] errors) : base(string.Join(" | ", errors))
    {
        Errors = errors;
    }
}
