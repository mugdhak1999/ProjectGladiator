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
    public class LoanTrackerController : ControllerBase
    {
        Home_LoanContext context;
        public LoanTrackerController(Home_LoanContext _context)
        {
            context = _context;
        }

        [HttpPost("Track")]
        public IActionResult Loantrack(string name)
        {
            var details = (context.PersonalDetails.Select(x => x.LoanDetails.Where
            (res => res.Username == name).Select(y => 
            new { y.ApplicationId, y.UsernameNavigation.PhoneNumber })));

            if (details != null)
            {
                return Ok(new { status = "success" });
            }
            else
                return BadRequest();
        }
        [HttpGet("{applicationid}")]
        public IActionResult GetByApplicationId(int applicationid)
        {
            return Ok(context.ApplicationDetails.Where(x => x.ApplicationId == applicationid).FirstOrDefault());
        }

        
    }
}
