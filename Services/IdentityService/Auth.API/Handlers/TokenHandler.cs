using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Auth.API.Handlers;
public static class TokenHandler
{
    public static dynamic CreateAccessToken(IConfiguration configuration)
    {
        SymmetricSecurityKey symmetricSecurityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(configuration["JWT:Security"]));
        TokenValidationParameters tokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = symmetricSecurityKey,
            ValidateIssuer = true,
            ValidIssuer = configuration["JWT:Issuer"],
            ValidateAudience = true,
            ValidAudience = configuration["JWT:Audience"],
            ValidateLifetime = true,
            ClockSkew = TimeSpan.Zero,
            RequireExpirationTime = true
        };
        DateTime now = DateTime.UtcNow;
        JwtSecurityToken jwt = new JwtSecurityToken(
                 issuer: configuration["JWT:Issuer"],
                 audience: configuration["JWT:Audience"],
                 claims: new List<Claim> {
                      new Claim(ClaimTypes.Name, "gncy")
                 },
                 notBefore: now,
                 expires: now.Add(TimeSpan.FromMinutes(2)),
                 signingCredentials: new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256)
             );
        return new
        {
            AccessToken = new JwtSecurityTokenHandler().WriteToken(jwt),
            Expires = TimeSpan.FromMinutes(2).TotalSeconds
        };
    }
}

