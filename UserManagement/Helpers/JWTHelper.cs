using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace UserManagement.Helpers
{
  public class JWTHelper
  {
    private readonly IConfiguration _configuration;
    public JWTHelper(IConfiguration configuration)
    {
      _configuration = configuration;
    }
    public string GenerateNewJwtToken(List<Claim> claims)
    {
      var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Secret"]));
      var issuer = _configuration["Jwt:Issuer"];
      var audience = _configuration["Jwt:Audience"];

      var tokenObject = new JwtSecurityToken(
               issuer: issuer,
                      audience: audience,
                             claims: claims,
                                    expires: DateTime.Now.AddMinutes(30),
                                           signingCredentials: new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256)
                                                );

      var token = new JwtSecurityTokenHandler().WriteToken(tokenObject);

      return token;
    }
  }
}
