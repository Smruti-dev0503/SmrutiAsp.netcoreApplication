using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SmrutiAsp.netcoreApplication.Models
{
    public class Qualification
    {
        [Key]
        public int Qualification_Id { get; set; }

        [Column(TypeName = "nvarchar(100)" )]
        [Required]
        public string Qualification_Name { get; set; }

        [Column(TypeName = "bit")]
        public bool IsDeleted { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime IsDeleteDate { get; set; }


    }
}
