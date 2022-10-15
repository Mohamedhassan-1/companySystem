using Microsoft.AspNetCore.Mvc;
using Pratical.BL.interfaces;
using Pratical.BL.Reposirty;
using Pratical.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Pratical.Controllers
{
    public class EmployeeController : Controller
    {
        private IEmployeeRep employeeRep;
        public EmployeeController(IEmployeeRep employeeRep)
        {
            this.employeeRep = employeeRep;
        }
        public IActionResult Employee()
        {
            /*
             * Added inject view in this view
             */
            //var data = employeeRep.Get();
            return View();
        }
        public IActionResult Create()
        {

            return View();
        }  
       
        [HttpPost]
        public IActionResult Create(EmployeeVM dpt)
        {

            
            employeeRep.Add(dpt);
            return RedirectToAction("Employee", "Employee");
        }
        public IActionResult Details(int id)
        {

            return View(employeeRep.GetbyId(id));
        }
        public IActionResult Edit(int id)
        {
            var data = employeeRep.GetbyId(id);
            return View(data);
        }
        [HttpPost]
        public IActionResult Edit(EmployeeVM dpt)
        {
            employeeRep.Edit(dpt);
            return RedirectToAction("Employee", "Employee");
        }
        public IActionResult Delete(int id)
        {
            employeeRep.Delete(id);
            return RedirectToAction("Employee", "Employee");
        }
    }
}
