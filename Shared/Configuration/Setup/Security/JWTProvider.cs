using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using PersonalFinance.Domain.Identity;
using Shared.Configuration.Options;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Configuration.Setup.Security
{
    public class JWTProvider(IOptions<JWTOptions> options)
    {
        private readonly JWTOptions _options = options.Value;

        public string GenerateJWT(AccountUser accountUser) 
        {

            List<Claim> claims = [
                    new(JwtRegisteredClaimNames.Email, accountUser.email),
                    new(JwtRegisteredClaimNames.Sub, accountUser.Id.ToString()),
                    new(JwtRegisteredClaimNames.Iat,DateTime.UtcNow.ToString())
                ];

            var signingCridentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_options.SecretKey)),
                SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken 
            (
                _options.Issuer,
                _options.Audience,
                claims,
                null,
                DateTime.UtcNow.AddHours(2),
                signingCridentials


            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        
        }
    }
}
