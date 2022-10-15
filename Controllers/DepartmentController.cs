using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pratical.BL.Reposirty;
using Pratical.DAL;
using Pratical.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
 
   
namespace Pratical.Controllers
{
    [Authorize]
    public class DepartmentController : Controller
    {
        //private DBContainer dBContainer = new DBContainer();
        private DepartmentRep departmentRep;
        public DepartmentController(DepartmentRep departmentRep)
        {
            this.departmentRep = departmentRep;
        }
        public IActionResult Department()
        {
            //var data = departmentRep.Get().Skip(1).Take(2);
            var data = departmentRep.Get();
             return View(data);
        }
        public IActionResult Create()
        {
           
            return View();
        }
        [HttpPost]
        public IActionResult Create(DepartmentVM dpt)
        {
            if (!ModelState.IsValid) 
                return View(dpt);
            departmentRep.Add(dpt);
            return RedirectToAction("Department", "Department");
        }
        public IActionResult Edit(int id)
        {
            var data = departmentRep.GetbyId(id);
            return View(data);
        }
        [HttpPost]
        public IActionResult Edit(DepartmentVM dpt)
        {
            departmentRep.Edit(dpt);
            return RedirectToAction("Department", "Department");
        }
        public IActionResult Delete(int id)
        {
            departmentRep.Delete(id);
            return RedirectToAction("Department", "Department");
        }
    }
}
