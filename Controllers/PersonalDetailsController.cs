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
    public class PersonalDetailsController : ControllerBase
    {
        Home_LoanContext context;
        public PersonalDetailsController(Home_LoanContext _context)
        {
            context = _context;
        }
        [HttpGet]
        [Route("getdetails")]
        public IActionResult GetAll()
        {
            return Ok(context.PersonalDetails);
        }
        [HttpPost]
        public IActionResult perdetails(PersonalDetails personaldetails)
        {
           
                context.PersonalDetails.Add(personaldetails);
                context.SaveChanges();
                return Ok(context.PersonalDetails);
           
        }

        [HttpPost("Login")]

        public IActionResult Login(PersonalDetails details)
        {
            var data = context.PersonalDetails.Where(x => x.Username == details.Username && x.Password == details.Password).FirstOrDefault();
            if (data != null)
            {
                return Ok(new { status = "Welcom" });
            }
            else
            {
                return BadRequest();
            }
        }

            


    }
}
