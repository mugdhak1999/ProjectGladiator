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
    public class ApplicationDetailsController : ControllerBase
    {
        Home_LoanContext context;
        public ApplicationDetailsController(Home_LoanContext _context)
        {
            context = _context;
        }
        public IActionResult GetApplicationDetails()
        {
            return Ok(context.ApplicationDetails);
        }

        [HttpPost]

        public IActionResult addApplication(ApplicationDetails application)
        {
            Random rand = new Random();
            application.LoanId = rand.Next(20000, 30000);
            context.ApplicationDetails.Add(application);
            context.SaveChanges();
            return Ok(context.ApplicationDetails);
        }
    }
}
