using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace Pratical.DAL
{
    [Table("Department")]
    public class Department
    {
        [Key]
        public int id { get; set; }
        [StringLength(50)]
        public String DepartmentName { get; set; }
        [StringLength(50)]
        public String DepartmentCode { get; set; }
        public ICollection<Employe> employes { get; set; }
    }
}
