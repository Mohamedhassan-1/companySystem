using AutoMapper;
using Pratical.BL.Helper;
using Pratical.BL.interfaces;
using Pratical.DAL;
using Pratical.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pratical.BL.Reposirty
{
    public class EmployeeRep : IEmployeeRep
    {
        private DBContainer dBContainer;
        private readonly IMapper mapper;

        public EmployeeRep(DBContainer dBContainer, IMapper mapper)
        {
            this.dBContainer = dBContainer;
            this.mapper = mapper;
        }

        public void Add(EmployeeVM dpt)
        {
            //Mapping Using Auto Mapper
            //Department department = new Department();
            //department.id = dpt.id;
            //department.DepartmentName = dpt.DepartmentName;
            //department.DepartmentCode = dpt.DepartmentCode;
            var data = mapper.Map<Employe>(dpt);
            data.photoName=uploadFile.SaveFile(dpt.photourl,"Photos");
            data.cvName = uploadFile.SaveFile(dpt.cvurl, "Docs");
            data.departmentId = 2;
            data.DistrictId = 1;
            dBContainer.Employee.Add(data);
            dBContainer.SaveChanges();
        }

        public void Delete(int id)
        {
            var deleteObject = dBContainer.Employee.Find(id);
            dBContainer.Employee.Remove(deleteObject);
            dBContainer.SaveChanges();
        }

        public void Edit(EmployeeVM dpt)
        {
            //var oldData = dBContainer.Department.Find(dpt.id);
            //oldData.DepartmentName = dpt.DepartmentName;
            //oldData.DepartmentCode = dpt.DepartmentCode;
            var data = mapper.Map<Employe>(dpt);
            dBContainer.Entry(data).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            dBContainer.SaveChanges();
        }

        public IQueryable<EmployeeVM> Get()
        {
            
            return dBContainer.Employee.Where(a=>a.isActive!=false||a.isActive!=true).Select(a =>new EmployeeVM { Address=a.Address,
            isActive=a.isActive,
            departmentId=a.departmentId,
            Email=a.Email,
            HireDate=a.HireDate,
            id=a.id,
            Name=a.Name,
            Notes=a.Notes,
            Salary=a.Salary,
            departmentName=a.department.DepartmentName,
           photoName=a.photoName,
           cvName=a.cvName
            });
        }

        public EmployeeVM GetbyId(int id)
        {
            var data = dBContainer.Employee.Where(a => id == a.id).Select(a => new EmployeeVM {Address = a.Address
            , departmentId = a.departmentId,
                isActive = a.isActive,
                Email = a.Email,
                HireDate = a.HireDate, 
                id=a.id,
                Name=a.Name,
                Notes=a.Notes,
                Salary=a.Salary,
                photoName = a.photoName,
                cvName = a.cvName
                }).FirstOrDefault();
            return data;
        }
    }
}
