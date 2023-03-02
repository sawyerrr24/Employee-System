using AutoMapper;

namespace Employee_System.Profiles
{
    public class EmployeesProfile : Profile
    {
        public EmployeesProfile()
        {
            CreateMap<Models.Entities.EmployeeInfo, DTO.EmployeeInfo>()

                .ReverseMap();
        }
    }
}
