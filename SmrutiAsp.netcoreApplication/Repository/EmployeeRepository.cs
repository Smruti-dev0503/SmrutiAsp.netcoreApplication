using SmrutiAsp.netcoreApplication.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace SmrutiAsp.netcoreApplication.Models
{
    public class EmployeeRepository :IEmployeeRepository
    {
        private readonly EmployeeContext context;
        public EmployeeRepository(EmployeeContext context)
        {
            this.context = context;
        }

        public List<Qualification> GetQualifications()
        {
            var Qualificationlist = context.Qualification.Where(x => x.IsDeleted != true).ToList();
            return Qualificationlist;
        }

        public Employee Add(Employee employee)
        {
            context.Employee.Add(employee);
            context.SaveChanges();
            return employee;
        }

        public Employee Delete(int id)
        {
            Employee employee = context.Employee.FirstOrDefault(x => x.Employee_Id == id);
            if(employee != null)
            {               
                employee.IsDeleted = true;
                employee.IsDeleteDate = DateTime.Now;
                var DeleteEmployee = context.Employee.Attach(employee);
                DeleteEmployee.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                context.SaveChanges();
            }
            return employee;
        }

        public Employee GetEmployee(int id)
        {
            return context.Employee.Find(id);
        }

        public IEnumerable<EmployeeViewModel> GetEmployees()
        {
            //var Employelist = context.Employee.Where(x => x.IsDeleted != true).ToList();
            var Employelist = (from employee in context.Employee
                                join qualification in context.Qualification on employee.Qualification equals qualification.Qualification_Id
                                where employee.IsDeleted != true
                                select new EmployeeViewModel
                                {
                                    Employee_Name = employee.Employee_Name,
                                    DOB = employee.DOB,
                                    Qualification = qualification.Qualification_Name,
                                    Experience = employee.Experience,
                                    Joining_Date = employee.Joining_Date,
                                    Salary = employee.Salary,
                                    Designation = employee.Designation,
                                    hobbiesList = employee.Hobbies ,
                                    IsDeleteDate = DateTime.Now,
                                    MdodifiedDate =DateTime.Now
                                }).ToList();                              

            return Employelist;
        }

        public Employee Update(Employee employeeChanges)
        {
            var UpateEmployee = context.Employee.Attach(employeeChanges);
            UpateEmployee.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return employeeChanges;
        }
    }
}
