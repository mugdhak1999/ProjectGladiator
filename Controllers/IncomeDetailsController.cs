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
    public class IncomeDetailsController : ControllerBase
    {
        Home_LoanContext context;
        public IncomeDetailsController(Home_LoanContext _context)
        {
            context = _context;
        }
        public IActionResult GetAll()
        {
            return Ok(context.IncomeDetails);
        }
        [HttpPost]
        public IActionResult incomedetails(IncomeDetails incomedetails)
        {
            context.IncomeDetails.Add(incomedetails);
            context.SaveChanges();
            return Ok(context.IncomeDetails);
        }
    }
}
