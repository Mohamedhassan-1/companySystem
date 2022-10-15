using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Pratical.Models
{
    public class DepartmentVM
    {
        public int id { get; set; }
        [Required(ErrorMessage = "Enter Name ")]
        [MinLength(3, ErrorMessage = "Minium Length is 3")]
        [MaxLength(5, ErrorMessage = "Maxium Length is 5")]
        public String DepartmentName { get; set; }
        [Required(ErrorMessage = "Enter DepartmentCode")]
        public String DepartmentCode { get; set; }
    }
}
