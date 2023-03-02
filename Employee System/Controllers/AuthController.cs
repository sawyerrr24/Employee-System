using Employee_System.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Employee_System.Controllers
{
    [ApiController]
    [Route("controller")]

    public class AuthController : Controller
    {
        private readonly IAdminRepository adminRepository;
        private readonly ITokenHandler tokenHandler;

        public AuthController(IAdminRepository adminRepository, ITokenHandler tokenHandler)
        {
            this.adminRepository = adminRepository;
            this.tokenHandler = tokenHandler;
        }



        [HttpPost]
        [Route("login")]

        public async Task<IActionResult> LoginAsync(DTO.LoginRequest loginRequest)
        {
            
           //check if user is authenticated
           //check username and password

          
          var admin = await adminRepository.AuthenticateAsync(loginRequest.UserName, loginRequest.Password);

            

            if (admin!=null)
            {
                var token = await tokenHandler.CreateTokenAsync(admin);
                return Ok(token);
               
            }
            return BadRequest("Username or Password is incorect");


        }
    }
}
