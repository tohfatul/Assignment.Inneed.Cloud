using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.Inneed.Application.Features.User.Queries.GetAllUsers;

//public class GetUsersQuery: IRequest<List<UserDto>>
//{

//}
public record GetUsersQuery:IRequest<List<UserDto>>;
