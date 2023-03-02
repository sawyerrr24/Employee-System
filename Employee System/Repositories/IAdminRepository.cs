using Employee_System.Models.Entities;

namespace Employee_System.Repositories
{
    public interface IAdminRepository
    {
      Task<Admin> AuthenticateAsync(string username, string password);   
    }
}
