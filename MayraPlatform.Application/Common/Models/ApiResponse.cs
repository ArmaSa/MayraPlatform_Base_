using MayraPlatform.Application.Constants;

namespace MayraPlatform.Application.Common.Models
{
    public class ApiResponse
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; } = string.Empty;
        public List<string> Errors { get; set; } = new();
        public int StatusCode { get; set; }

        public static ApiResponse Success(string message = Constant.SuccessMsg, int statusCode = 200)
        {
            return new ApiResponse
            {
                IsSuccess = true,
                Message = message,
                StatusCode = statusCode
            };
        }

        public static ApiResponse Fail(List<string> errors, string message = Constant.FailedMsg, int statusCode = 500)
        {
            return new ApiResponse
            {
                IsSuccess = false,
                Message = message,
                Errors = errors,
                StatusCode = statusCode
            };
        }

        public static ApiResponse Fail(string error, string message = Constant.UnexpectedError, int statusCode = 500)
        {
            return Fail(new List<string> { error }, message, statusCode);
        }
    }

    public class ApiResponse<T> : ApiResponse
    {
        public T? Result { get; set; }

        public static ApiResponse<T> Success(T data, string message = Constant.SuccessMsg, int statusCode = 200)
        {
            return new ApiResponse<T>
            {
                IsSuccess = true,
                Result = data,
                Message = message,
                StatusCode = statusCode
            };
        }

        public new static ApiResponse<T> Fail(List<string> errors, string message = Constant.FailedMsg, int statusCode = 400)
        {
            return new ApiResponse<T>
            {
                IsSuccess = false,
                Errors = errors,
                Message = message,
                StatusCode = statusCode
            };
        }

        public new static ApiResponse<T> Fail(string error, string message = Constant.UnexpectedError, int statusCode = 500)
        {
            return Fail(new List<string> { error }, message, statusCode);
        }
    }
}
