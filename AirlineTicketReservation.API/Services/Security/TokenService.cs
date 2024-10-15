using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AirlineTicketReservation.API.Services.Security {
    public class TokenService : ITokenService {

        private readonly IConfiguration _config;

        public TokenService(IConfiguration config) {
            _config = config;
        }

        public string GetAccessToken(string name, List<string> roles) {

            var tokenHandler = new JwtSecurityTokenHandler();

            var key = Encoding.ASCII.GetBytes(_config.GetValue<string>("JwtSettings:secret"));

            var credentials = new SigningCredentials(
                new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature);

            var tokenDescriptor = new SecurityTokenDescriptor {
                SigningCredentials = credentials,
                Expires = DateTime.UtcNow.AddHours(8),
                Subject = GetUserClaims(name, roles)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            var tokenString = tokenHandler.WriteToken(token);



            return tokenString;
        }

        private ClaimsIdentity GetUserClaims(string name, List<string> roles) {
            var claimsIdentity = new ClaimsIdentity();
            claimsIdentity.AddClaim(new Claim(ClaimTypes.Name, name));


            foreach (var role in roles) {
                claimsIdentity.AddClaim(new Claim(ClaimTypes.Role, role));
            }

            return claimsIdentity;
        }

        public DateTime GetExpirationTimeFromToken(string token) {
            var tokenHandler = new JwtSecurityTokenHandler();

            var jwtToken = tokenHandler.ReadToken(token);

            return jwtToken.ValidTo;

        }
    }
}
