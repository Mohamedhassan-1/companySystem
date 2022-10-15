using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication7.DAL.Entities;

namespace Pratical.Models
{
    public class CityVM
    {
        public int Id { get; set; }

        
        public string CityName { get; set; }
        public int CountryId { get; set; }
        public Country Country { get; set; }
        public virtual ICollection<District> District { get; set; }
    }
}
