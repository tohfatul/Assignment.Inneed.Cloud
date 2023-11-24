using Assignment.Inneed.Application.Features.User.Commands.CreateUser;
using Assignment.Inneed.Application.Features.User.Commands.LoginUser;
using Assignment.Inneed.Application.Features.User.Queries.GetAllUsers;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Assignment.Inneed.API.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }
        
        [HttpGet]
        [Authorize(Roles ="Administrator")]
        public async Task<List<UserDto>> Get()
        {
            var users = await _mediator.Send(new GetUsersQuery());
            return users;
        }
       
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Post(CreateUserCommand user)
        {
            var response = await _mediator.Send(user);
            return CreatedAtAction(nameof(Get), new { id = response });
        }

        [HttpPost("login")]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Login(LoginUserCommand user)
        {
            var response = await _mediator.Send(user);
            return Ok(response);
        }


    }
}
