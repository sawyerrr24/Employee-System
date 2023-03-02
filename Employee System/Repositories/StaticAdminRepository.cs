using Employee_System.Models.Entities;
using Microsoft.IdentityModel.Tokens;

namespace Employee_System.Repositories
{
    public class StaticAdminRepository : IAdminRepository
    {
        private List<Admin> Admins = new List<Admin>()
        {
            new Admin()
            {
               
              Id=Guid.NewGuid(),UserName="readwrite@user.com", Password="Readwrite@user",
             

            },

             new Admin()
            {
               
              Id=Guid.NewGuid(),UserName="readwrite@user.com", Password="Readwrite@user",
              

            }, 



        }; 

         
        public async Task<Admin> AuthenticateAsync(string username, string password)
        {
            var admin = Admins.Find(x => x.UserName.Equals(username, StringComparison.InvariantCultureIgnoreCase) &&
             x.Password==password);


           
            
            return admin;
            

          
        }
    }
}
