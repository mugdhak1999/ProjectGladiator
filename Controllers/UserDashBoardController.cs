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
    public class UserDashBoardController : ControllerBase
    {
        Home_LoanContext context;
        public UserDashBoardController(Home_LoanContext _context)
        {
            context = _context;
        }
        [HttpGet("{username}")]
        public IActionResult GetByUsername(string username)
        {
            return Ok(context.AccountDetails.Where(x => x.Username == username).FirstOrDefault());
        }
    }
}
