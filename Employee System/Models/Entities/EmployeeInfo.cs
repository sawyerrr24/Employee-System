using System.ComponentModel.DataAnnotations;

namespace Employee_System.Models.Entities
{
    public class EmployeeInfo
    {
        public long Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Position { get; set; }
        public string DateOfBirth { get; set; }

        public int Projects { get; set; }

        [Phone]
        public string PhoneNumber { get; set; }
    

    }
}
