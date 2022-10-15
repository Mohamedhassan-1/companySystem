using Pratical.DAL;
using Pratical.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pratical.BL.interfaces
{
    public interface IEmployeeRep
    {
        IQueryable<EmployeeVM> Get();
        EmployeeVM GetbyId(int id);
        void Add(EmployeeVM dpt);
        void Edit(EmployeeVM dpt);
        void Delete(int id);
    }
}
