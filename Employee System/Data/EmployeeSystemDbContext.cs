using Employee_System.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

namespace Employee_System.Data
{
    public class EmployeeSystemDbContext:DbContext
    {
        internal readonly object Admin;

        public EmployeeSystemDbContext(DbContextOptions<EmployeeSystemDbContext>options): base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<EmployeeInfo>().HasData(

             new EmployeeInfo
             {
                 Id = 1,

                 FullName = "Kwame Asante",

                 Email = "kwame123@aol.com",

                 Position = "Salesman",

                 DateOfBirth = "06/02/1976",

                 Projects = 2,

                 PhoneNumber = "0204321234"


             },  




            new EmployeeInfo
            {
                Id = 2,

                FullName = "Andrew Mensah",

                Email = "mensahandrew@gmail.com.",

                Position = "Salesman",

                DateOfBirth = "16/11/1980",

                Projects = 4,

                PhoneNumber = "0504324321",


            }

            );
        }

        public DbSet<EmployeeInfo> Employees { get; set; }
        public DbSet<Admin> Admins { get; set; }




    }

   


}
