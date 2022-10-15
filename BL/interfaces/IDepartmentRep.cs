using Pratical.DAL;
using Pratical.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pratical.BL.interfaces
{
   public interface IDepartmentRep
    {
        IQueryable<DepartmentVM> Get();
        DepartmentVM GetbyId(int id);
        void Add(DepartmentVM dpt);
        void Edit(DepartmentVM dpt);
        void Delete(int id);
    }
}
