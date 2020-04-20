using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SmrutiAsp.netcoreApplication.ViewModel
{
    public class EmployeeViewModel
    {
        public int Employee_Id { get; set; }
        [Required]
        public string Employee_Name { get; set; }        
        [Required]
        public DateTime? DOB { get; set; }
        public string Qualification { get; set; }
        public int Qualification_Id { get; set; }
        public string Experience { get; set; }
        public DateTime? Joining_Date { get; set; }
        public int? Salary { get; set; }
        public string Designation { get; set; }
        public string hobbiesList{ get; set; }
        public List<HobbiesTable> Hobbies { get; set; }
        public bool IsModified { get; set; }
        public DateTime MdodifiedDate { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime IsDeleteDate { get; set; }

    }

    public class HobbiesTable
    {
        public int HobbyId { get; set; }
        public string HobbyName { get; set; }
        public bool IsSelected { get; set; }
    }
}
