using AutoMapper;
using Employee_System.DTO;
using Employee_System.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography;

namespace Employee_System.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]

    public class EmployeeController : Controller
    {
        private readonly IEmployeeInfoRepository employeeInfoRepository;
        private IMapper mapper;


        public EmployeeController(IEmployeeInfoRepository employeeInfoRepository, IMapper mapper
            )
        {
            this.employeeInfoRepository = employeeInfoRepository;
            this.mapper = mapper;
        }


        [HttpGet]
        
        public async Task <IActionResult> GetAllEmployeesAsync()
        {
            
            var employees = await employeeInfoRepository.GetAll();
            var employeesdto = mapper.Map<List<DTO.EmployeeInfo>>(employees);


            return Ok(employeesdto);
        }


        [HttpGet]
        [Route("{id:long}")]
        [ActionName("GetEmployeeAsync")]
        public async Task<IActionResult> GetEmployeeAsync(long id)
        {
            var employees = await employeeInfoRepository.GetAsync(id);

            if (employees == null)
            {
                return NotFound();
            }

            var employeesDTO = mapper.Map<DTO.EmployeeInfo>(employees);

            return Ok(employeesDTO);

        }

        [HttpPost]
   
        public async Task<IActionResult> AddEmployeeAsync(AddEmployeeReq addEmployeeReq)
        {
            var employees = new Models.Entities.EmployeeInfo()
            {
                FullName = addEmployeeReq.FullName,

                Email = addEmployeeReq.Email,

                Position = addEmployeeReq.Position,

                DateOfBirth = addEmployeeReq.DateOfBirth,

                PhoneNumber = addEmployeeReq.PhoneNumber,

                Projects = addEmployeeReq.Projects,

            };

            employees = await employeeInfoRepository.AddAsync(employees);


            var employeeDTO = new DTO.EmployeeInfo
            {
                Id = employees.Id,
                FullName = employees.FullName,
                Email = employees.Email,
                Position = employees.Position,
                DateOfBirth = employees.DateOfBirth,
                PhoneNumber = employees.PhoneNumber,
                Projects = employees.Projects,

            };

            return CreatedAtAction(nameof(GetEmployeeAsync), new { id = employeeDTO.Id }, employeeDTO);






        }

        [HttpPut]
        [Route("{id:long}")]
        
         
        public async Task<IActionResult> UpdateEmployeeAsync([FromRoute] long id, [FromBody] DTO.UpdateEmployeeReq updateEmployeeReq) 
        {
            var employees = new Models.Entities.EmployeeInfo()
            {
                FullName = updateEmployeeReq.FullName,
                Email = updateEmployeeReq.Email,
                Position = updateEmployeeReq.Position,
                DateOfBirth = updateEmployeeReq.DateOfBirth,
                Projects = updateEmployeeReq.Projects,
                PhoneNumber = updateEmployeeReq.PhoneNumber,
            };

          var employeeDomain=  await employeeInfoRepository.UpdateAsync(id, employees);

            if (employeeDomain == null)
            {
                return NotFound();
            }


            var employeesDTO = new DTO.EmployeeInfo
            {
               Id= employees.Id,
                FullName = employees.FullName,
                Email = employees.Email,
                Position = employees.Position,
                DateOfBirth = employees.DateOfBirth,
                Projects = employees.Projects,
                PhoneNumber = employees.PhoneNumber,
            };

            return Ok(employeesDTO);
        }






        [HttpDelete]
        [Route("{id:long}")]
        
        public async Task<IActionResult> DeleteEmployee(long id)
        {
            //Get from db

            var employees = await employeeInfoRepository.DeleteAsync(id);

            //if null not found
            if (employees == null)
            {
                return NotFound();
            }

            //convert response back to dto
            var employeesDTO = new DTO.EmployeeInfo
            {
                Id = employees.Id,
                FullName = employees.FullName,
                Email = employees.Email,
                Position = employees.Position,
                DateOfBirth = employees.DateOfBirth,
                PhoneNumber = employees.PhoneNumber,
                Projects = employees.Projects,

            };

            //return ok
            return Ok(employees);

        }



    }
}
