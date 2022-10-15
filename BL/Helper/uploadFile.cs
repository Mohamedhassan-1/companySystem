using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Pratical.BL.Helper
{
    public static class uploadFile
    {
        public static string SaveFile(IFormFile file,string folderName)
        {
            string Name = Guid.NewGuid() + Path.GetFileName(file.FileName);
            string finalPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Files/"+folderName,Name);
            using (var system = new FileStream(finalPath, FileMode.Create))
            {
                file.CopyTo(system);
            }
            return Name;
        }
    }
}
