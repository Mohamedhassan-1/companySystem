using AutoMapper;
using Pratical.DAL;
using Pratical.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication7.DAL.Entities;

namespace Pratical.BL.Mapper
{
    public class DomainProfile:Profile
    {
        public DomainProfile()
        {
            CreateMap<Department, DepartmentVM>();
            CreateMap<DepartmentVM, Department>();

            CreateMap<Employe,EmployeeVM>();
            CreateMap<EmployeeVM, Employe>();

            CreateMap<CounteryVM, Country>();
            CreateMap<Country, CounteryVM>();
        }
    }
}
