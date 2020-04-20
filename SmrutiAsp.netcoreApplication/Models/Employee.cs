using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SmrutiAsp.netcoreApplication.Models
{
    public class Employee
    {
        [Key]
        public int Employee_Id { get; set; }

        [Column(TypeName ="nvarchar(100)")]
        [Required]
        public string Employee_Name { get; set; }

        [Column(TypeName = "datetime")]
        [Required]  
        public DateTime? DOB{ get; set; }

        [Column(TypeName = "int")]
        public int? Qualification { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string Experience{ get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? Joining_Date { get; set; }

        [Column(TypeName = "int")]
        public int? Salary { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string Designation{ get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string Hobbies { get; set; }

        [Column(TypeName = "bit")]
        public bool? IsDeleted { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? IsDeleteDate { get; set; }

        [Column(TypeName = "bit")]
        public bool? IsModified { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? MdodifiedDate { get; set; }

    }
}
