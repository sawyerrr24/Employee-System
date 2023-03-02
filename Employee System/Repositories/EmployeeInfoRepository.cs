using Employee_System.Data;
using Employee_System.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Employee_System.Repositories
{
    public class EmployeeInfoRepository:IEmployeeInfoRepository
    {
        private readonly EmployeeSystemDbContext employeeSystemDbContext;

        public EmployeeInfoRepository(EmployeeSystemDbContext employeeSystemDbContext)
        {
            this.employeeSystemDbContext = employeeSystemDbContext;
        }
       
        public async Task<EmployeeInfo> AddAsync(EmployeeInfo employeeInfo)
        {
            await employeeSystemDbContext.AddAsync(employeeInfo);
            await employeeSystemDbContext.SaveChangesAsync();
            return employeeInfo;
        }

        public async Task<EmployeeInfo> DeleteAsync(long id)
        {
            var employeeinfo= await employeeSystemDbContext.Employees.FirstOrDefaultAsync(a => a.Id== id);
            if (employeeinfo == null)
            {
                return null;
            }

            employeeSystemDbContext.Employees.Remove(employeeinfo);
            await employeeSystemDbContext.SaveChangesAsync();
            return employeeinfo;


        }

        public async Task<IEnumerable<EmployeeInfo>> GetAll()
        {
            return await employeeSystemDbContext.Employees.ToListAsync();

        }

        public async Task<EmployeeInfo> GetAsync(long id)
        {

            return await employeeSystemDbContext.Employees.FirstOrDefaultAsync(a => a.Id == id);


        }

        public async Task<EmployeeInfo> UpdateAsync(long id, EmployeeInfo employeeInfo)
        {
            var existingemployee = await  employeeSystemDbContext.Employees.FindAsync(id);

            if(existingemployee !=null)
            {
                
                existingemployee.FullName = employeeInfo.FullName;
                existingemployee.Email = employeeInfo.Email;
                existingemployee.Position = employeeInfo.Position;
                existingemployee.DateOfBirth = employeeInfo.DateOfBirth;
                existingemployee.Projects = employeeInfo.Projects;
                existingemployee.PhoneNumber = employeeInfo.PhoneNumber;

                await employeeSystemDbContext.SaveChangesAsync();

                return existingemployee;
                
            }

            return null;



        }

       
    }
}
