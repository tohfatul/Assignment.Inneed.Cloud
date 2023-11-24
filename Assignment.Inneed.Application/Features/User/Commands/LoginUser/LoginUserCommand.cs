using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.Inneed.Application.Features.User.Commands.LoginUser;

public class LoginUserCommand :IRequest<LoginResponseDto>
{
    public string Email { get; set; } 
    public string Password { get; set; }

}
