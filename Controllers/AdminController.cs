using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Pratical.DAL;
using Pratical.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pratical.Controllers
{
    public class AdminController : Controller
    {
        private readonly RoleManager<IdentityRole> userManager;

        public AdminController(RoleManager<IdentityRole> userManager)
        {
            this.userManager = userManager;
        }
        public IActionResult Index()
        {
            return View(userManager.Roles);
        }
        public IActionResult CreateRole()
        {
            return View();
        }
        [HttpPost]
        public async Task <IActionResult> CreateRole(CreateRoleVM model)
        {
            if(ModelState.IsValid)
            {
                var data = new IdentityRole()
                {
                    Name = model.RoleName
                };
              var result= await userManager.CreateAsync(data);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }
            return View(model);
        }

        public async Task<IActionResult> EditRole(string id)
        {
            var data = await userManager.FindByIdAsync(id);
            var edited = new EditRoleVM()
            {
                Id = data.Id,
                RoleName = data.Name
            };
            return View(edited);
        }
        [HttpPost]
        public async Task<IActionResult> EditRole(EditRoleVM editRoleVM)
        {
            var data = await userManager.FindByIdAsync(editRoleVM.Id);
            data.Name =editRoleVM.RoleName;
            await userManager.UpdateAsync(data);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteRole(string Id)
         {
            var role = await userManager.FindByIdAsync(Id);
            await userManager.DeleteAsync(role);

            return RedirectToAction("Index");
        }


    }
}
