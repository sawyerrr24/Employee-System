using Employee_System.Models.Entities;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Employee_System.Repositories
{
    public interface ITokenHandler
    {
        Task <string>CreateTokenAsync(Admin admin);
         
    }
}
