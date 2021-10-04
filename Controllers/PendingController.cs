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
    public class PendingController : ControllerBase
    {
        Home_LoanContext context;
        public PendingController(Home_LoanContext _context)
        {
            context = _context;
        }

        //[Route("display")]
        [HttpGet("display")]
        public IActionResult GetLoanDetails()
        {
            var data = from l in context.LoanDetails
                       join a in context.ApplicationDetails
                        on l.ApplicationId equals a.ApplicationId
                       where a.Status == "Pending"
                       select new
                       {
                           l.ApplicationId,
                           l.Username,
                           l.MaxLoanAmountGrantable,
                           l.InterestRate,
                           l.Tenure,
                           l.LoanAmount
                       };
            return Ok(data);
        }


    }
}
