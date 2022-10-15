using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication7.DAL.Entities;

namespace Pratical.Models
{
    public class CounteryVM
    {
       
        public int Id { get; set; }

        
        public string CountryName { get; set; }


        public virtual ICollection<City> City { get; set; }

    }
}
