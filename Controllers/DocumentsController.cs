using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjectGladiator.Models;
using System.IO;
using System.Net.Http.Headers;

namespace ProjectGladiator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentsController : ControllerBase
    {
        [HttpPost("{s}")]
        public string post(string s)
        {
            var file = Request.Form.Files.Count > 0 ? Request.Form.Files[0] : null;
            string foldername = s;
            string webRootPath = Directory.GetCurrentDirectory();
            string mypath = "C:\\Users\\kulkarni\\OneDrive\\Desktop\\Project Gladiator\\UserDocs";
            string newPath = Path.Combine(mypath, foldername);
            if (!Directory.Exists(newPath))
            {
                Directory.CreateDirectory(newPath);
            }
            if (file != null && file.Length > 0)
            {
                string filename = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                string fullPath = Path.Combine(newPath, filename);
                using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
            }
            return "success";
        }

    }
}
