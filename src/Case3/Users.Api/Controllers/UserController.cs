using Users.Api.Endpoints;
using Microsoft.AspNetCore.Mvc;
using Users.Api.Mappings.Users;
using Users.Api.Contracts.Users.Responses;
using Users.Application.Users.Services.Interfaces;

namespace Users.Api.Controllers;

[ApiController]
public class UserController(IUserService userService) : ControllerBase
{
    [HttpGet(ApiEndpoint.Users.Get)]
    [ProducesResponseType(typeof(UserResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetById([FromRoute] int id, CancellationToken cancellationToken)
    {
        var result = await userService.GetByIdAsync(id, cancellationToken);
        if (result.IsFailure)
        {
            return NotFound(result.Error.Message);
        }

        return Ok(result.Value.MapToResponse());
    }
}