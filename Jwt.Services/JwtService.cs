using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Jwt.Services
{
    public class JwtService
    {
        private readonly string llaveSecreta;
        public JwtService(IConfiguration configuration)
        {
            llaveSecreta = configuration["LlaveSecreta"];
        }

        public string ObtenerToken(string nombre, string id, string role)
        {
            var _symmetricSecurityKey = new SymmetricSecurityKey(
                   Encoding.UTF8.GetBytes(llaveSecreta)
               );
            var _signingCredentials = new SigningCredentials(
                    _symmetricSecurityKey, SecurityAlgorithms.HmacSha256
                );
            var _Header = new JwtHeader(_signingCredentials);

            var claims = new List<Claim>();
            claims.Add(new Claim("Nombre", nombre));
            claims.Add(new Claim("Id", id));
            //claims.Add(new Claim("Role", role));
            claims.Add(new Claim(ClaimTypes.Role, role));

            var tokenOptions = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(20),
                signingCredentials: _signingCredentials
            );

            var token = new JwtSecurityTokenHandler().WriteToken(tokenOptions);

            return token;
        }
    }
}
