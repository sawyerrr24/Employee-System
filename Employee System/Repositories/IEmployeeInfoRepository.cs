using Employee_System.Models.Entities;

namespace Employee_System.Repositories
{
    public interface IEmployeeInfoRepository
    {
         public Task<IEnumerable<EmployeeInfo>> GetAll();

        public Task<EmployeeInfo> GetAsync(long Id);

        public Task<EmployeeInfo> AddAsync(EmployeeInfo employeeInfo);

        public Task<EmployeeInfo> DeleteAsync(long Id);

        public Task<EmployeeInfo> UpdateAsync(long Id, EmployeeInfo employeeInfo);

    }
}
