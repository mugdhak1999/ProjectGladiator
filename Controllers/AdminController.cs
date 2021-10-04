using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjectGladiator.Models;

namespace ProjectGladiator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        Home_LoanContext context;
        public AdminController(Home_LoanContext _context)
        {
            context = _context;
        }
        [HttpPost("adminlogin")]
        public IActionResult AdminLogin(AdminDetails details)
        {
            var data = context.AdminDetails.Where(x => x.Username == details.Username && x.Password == details.Password).FirstOrDefault();
            if (data != null)
            {
                return Ok(new { status = "Welcome" });
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
