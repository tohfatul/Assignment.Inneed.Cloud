using Assignment.Inneed.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.Inneed.Application.Contracts.Jwt
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(User user);
    }
}
