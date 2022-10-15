using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using WebApplication7.DAL.Entities;

namespace Pratical.DAL
{
    [Table("Employee")]
    public class Employe
    {
        [Key]
        public int id { get; set; }
        [StringLength(50)]
        public String Name { get; set; }
        [StringLength(50)]
        public String Address { get; set; }
        public DateTime HireDate { get; set; }
        public float Salary { get; set; }
        public bool isActive { get; set; }
        public String Notes { get; set; }
        public String Email { get; set; }
        public string photoName { get; set; }
        public string cvName { get; set; }
        public int departmentId { get; set; }
        [ForeignKey("departmentId")]
        public Department department { get; set; }
       
        public int DistrictId { get; set; }
        [ForeignKey("DistrictId")]
        public District District { get; set; }

    }
}
