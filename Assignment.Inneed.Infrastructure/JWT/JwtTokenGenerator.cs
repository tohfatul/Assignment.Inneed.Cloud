using Assignment.Inneed.Application.Contracts.Jwt;
using Assignment.Inneed.Domain;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.Inneed.Infrastructure.JWT
{
    public class JwtTokenGenerator : IJwtTokenGenerator
    {
        private readonly JwtOptions _jwtoptions;

        public JwtTokenGenerator(IOptions<JwtOptions> jwtoptions)
        {
            _jwtoptions = jwtoptions.Value;
        }
        public string GenerateToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtoptions.Secret);
            var claims = new List<Claim>
            {
                new Claim (JwtRegisteredClaimNames.Email, user.Email),
                new Claim (JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                new Claim (JwtRegisteredClaimNames.Name, user.FullName),
                new Claim (ClaimTypes.Role, user.Role.RoleName),
            };

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Audience = _jwtoptions.Audience,
                Issuer = _jwtoptions.Issuer,
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            
            return tokenHandler.WriteToken(token);
        }
    }
}
