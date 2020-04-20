using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SmrutiAsp.netcoreApplication.Models
{
    public class User
    {
        [Key]
        public int User_Id { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        [Required]
        public string User_Name { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        [Required]
        public string EmailId { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        [Required]
        public string Password { get; set; }

        [Column(TypeName = "bit")]
        public bool IsDeleted { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime IsDeleteDate { get; set; }
    }
}
