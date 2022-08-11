using JWTSimpleServer;
using JWTSimpleServer.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace DesafioTecnicoDocker
{
    public class AuthenticationProvider : IAuthenticationProvider
    {
        public Task ValidateClientAuthentication(JwtSimpleServerContext context)
        {
            if (context.UserName == "prueba" && context.Password == "prueba")
            {
                var claims = new List<Claim>();
                claims.Add(new Claim(ClaimTypes.Name, "prueba"));

                context.Success(claims);
            }
            else 
            {
                context.Reject("Autenticación invalida de usuario");
            }

            return Task.CompletedTask;
        }
    }
}
