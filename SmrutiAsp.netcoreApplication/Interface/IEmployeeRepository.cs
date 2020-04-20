using SmrutiAsp.netcoreApplication.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmrutiAsp.netcoreApplication.Models
{
    public interface IEmployeeRepository
    {
        Employee GetEmployee(int Id);
        IEnumerable<EmployeeViewModel> GetEmployees();
        Employee Add(Employee employee);
        Employee Update(Employee employee);
        Employee Delete(int id);

        List<Qualification> GetQualifications();
    }
}
