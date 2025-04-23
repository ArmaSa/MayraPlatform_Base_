using MayraPlatform.Application.Features.UserFeatures.CreateUser;
using MayraPlatform.Application.Features.UserFeatures.DeleteUser;
using MayraPlatform.Application.Features.UserFeatures.GetAllUser;
using MayraPlatform.Application.Features.UserFeatures.UpdateUser;
using MayraPlatform.Application.Features.UserFeatures.Validator;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MayraPlatform.Application.Common.Models;
using MayraPlatform.Application.Constants;

namespace MayraPlatform.WebAPI.Controllers;

[ApiController]
[Route("user")]
public class UserController : ControllerBase
{
    private readonly IMediator _mediator;

    public UserController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("GetUsers")]
    public async Task<ApiResponse<List<GetAllUserResponse>>> GetAll(CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(new GetAllUserRequest(), cancellationToken);
        return ApiResponse<List<GetAllUserResponse>>.Success(response, Constant.SuccessMsg);
    }
    
    [HttpPost("Create")]
    public async Task<ActionResult<CreateUserResponse>> Create(CreateUserRequest request, CancellationToken cancellationToken)
    {
        // برای زمانی که بخواهیم به صورت دستی ولیدیشن انجام بدیم.
        //var validator = new CreateUserValidator();
        //var result = validator.Validate(request);
        //if (!result.IsValid)
        //{
        //    var errorMessages = string.Join("; ", result.Errors.Select(e => $"{e.PropertyName}: {e.ErrorMessage}"));
        //    throw new ValidationException(errorMessages);
        //}

        var response = await _mediator.Send(request, cancellationToken);
        return Ok(ApiResponse<CreateUserResponse>.Success(response, Constant.UserCreatedSuccessfully));
    }

    [HttpPost("Update")]
    public async Task<ActionResult<UpdateUserResponse>> Update(UpdateUserRequest request,
    CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);
        return Ok(ApiResponse<UpdateUserResponse>.Success(response, Constant.UserCreatedSuccessfully));
    }

    [HttpDelete("DeleteUser")]
    public async Task<IActionResult> DeleteUser([FromQuery]DeleteUserRequest request, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);
        return Ok(ApiResponse.Success(Constant.UserDeleteSuccessfully));
    }
}