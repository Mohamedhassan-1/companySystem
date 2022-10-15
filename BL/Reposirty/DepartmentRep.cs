using Pratical.BL.interfaces;
using Pratical.DAL;
using Pratical.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
namespace Pratical.BL.Reposirty
{
    public class DepartmentRep : IDepartmentRep
    {
        private DBContainer dBContainer;
        private readonly IMapper mapper;

        public DepartmentRep(DBContainer dBContainer, IMapper mapper)
        {
            this.dBContainer = dBContainer;
            this.mapper = mapper;
        }

        public void Add(DepartmentVM dpt)
        {
            //Mapping Using Auto Mapper
            //Department department = new Department();
            //department.id = dpt.id;
            //department.DepartmentName = dpt.DepartmentName;
            //department.DepartmentCode = dpt.DepartmentCode;
            var data = mapper.Map<Department>(dpt);

            dBContainer.Department.Add(data);
            dBContainer.SaveChanges();
        }

        public void Delete(int id)
        {
            var deleteObject = dBContainer.Department.Find(id);
            dBContainer.Department.Remove(deleteObject);
            dBContainer.SaveChanges();
        }

        public void Edit(DepartmentVM dpt)
        {
            //var oldData = dBContainer.Department.Find(dpt.id);
            //oldData.DepartmentName = dpt.DepartmentName;
            //oldData.DepartmentCode = dpt.DepartmentCode;
            var data = mapper.Map<Department>(dpt);
            dBContainer.Entry(data).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            dBContainer.SaveChanges();
        }

        public IQueryable<DepartmentVM> Get()
        {
           return dBContainer.Department.Select(a => new DepartmentVM{id=a.id,
           DepartmentCode=a.DepartmentCode,
           DepartmentName=a.DepartmentName});
        }

        public DepartmentVM GetbyId(int id)
        {
            var data = dBContainer.Department.Where(a => id == a.id).Select(a => new DepartmentVM{id=a.id,DepartmentName
            =a.DepartmentName,
            DepartmentCode=a.DepartmentCode}).FirstOrDefault();
            return data;
        }
    }
}
