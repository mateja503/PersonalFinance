using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Shared.Configuration.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Configuration.Setup.Security
{
    public class JwtOptionsSetup(IConfiguration configuration) : IConfigureOptions<JWTOptions>
    {
        private readonly IConfiguration _configuration = configuration;

        public void Configure(JWTOptions options) 
        {
            _configuration.GetSection("Jwt").Bind(options);
            var jwtSecretFromEnv = Environment.GetEnvironmentVariable("JWT_SECRET_KEY");
            if (!string.IsNullOrWhiteSpace(jwtSecretFromEnv))
            {
                options.SecretKey = jwtSecretFromEnv;
            }
        }


    }
}
