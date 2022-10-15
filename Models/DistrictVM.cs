using Pratical.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication7.DAL.Entities;

namespace Pratical.Models
{
    public class DistrictVM
    {
        public int Id { get; set; }
        public string DistrictName { get; set; }
        public int CityId { get; set; }
        public City City { get; set; }
        public virtual ICollection<Employe> Employee { get; set; }
    }
}
