using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace Pratical.Models
{
    public class EmployeeVM
    {
        
        public int id { get; set; }
       [Required(ErrorMessage ="Enter Full Name")]
        [MinLength(3)]
        [MaxLength(15)]
        public String Name { get; set; }
        
        public String Address { get; set; }
        public DateTime HireDate { get; set; }
        [Range(3000,8000 ,ErrorMessage ="Enter Valid Salary from  3000 to 8000")]
        public float Salary { get; set; }
        public bool isActive { get; set; }
        public String Notes { get; set; }
        public String Email { get; set; }
        public int departmentId { get; set; }
        public string departmentName { get; set; }
        public IFormFile photourl { get; set; }
        public string photoName { get; set; }
        public IFormFile cvurl { get; set; }
        public string cvName { get; set; }
        public int DistrictId { get; set; }


    }
}
