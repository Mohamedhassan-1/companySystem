using Pratical.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pratical.BL.interfaces
{
    public interface ICountryRep
    {
        IQueryable<CounteryVM> Get();
        CounteryVM GetbyId(int id);
       
    }
}
