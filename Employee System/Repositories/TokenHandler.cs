using Employee_System.Models.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Employee_System.Repositories
{
    public class TokenHandler: ITokenHandler
    {
        private readonly IConfiguration configuration;

        public TokenHandler(IConfiguration configuration)
        {
            this.configuration = configuration;
        }




        public Task<string> CreateTokenAsync(Admin admin)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["jwt:Key"]));

            //create claims
            var claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.GivenName, admin.UserName));
            claims.Add(new Claim(ClaimTypes.GivenName, admin.Password));


           // var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["jwt:Key"]));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);


            var token = new JwtSecurityToken(
            configuration["jwt:Issuer"],
            configuration["jwt:Audience"],
            claims,
            expires: DateTime.Now.AddMinutes(15),
            signingCredentials: credentials);
            
         return Task.FromResult(new JwtSecurityTokenHandler().WriteToken(token));
            
        }

       
    } 
}
