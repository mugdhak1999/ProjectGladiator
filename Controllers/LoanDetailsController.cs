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
    public class LoanDetailsController : ControllerBase
    {
        Home_LoanContext context;
        public LoanDetailsController(Home_LoanContext _context)
        {
            context = _context;
        }
        
        [HttpPost]
        public IActionResult loandetails(LoanDetails loandetails)
        {
            Random rand = new Random();
            loandetails.ApplicationId = rand.Next(1000, 2000);
            context.LoanDetails.Add(loandetails);
            context.SaveChanges();
            return Ok(context.LoanDetails);
        }

        [HttpGet("{username}")]

        public IActionResult getApplicationID(string username)
        {
            var data = context.LoanDetails.Where(x => x.Username == username).FirstOrDefault();
            if (data != null)
            {
                return Ok(data.ApplicationId);
            }
            else
            {
                return BadRequest("ID not found");
            }   
        }

        //[HttpGet("get/{id}")]
        //public IActionResult getApplicationID(int id)
        //{
        //    var data = context.LoanDetails.Where(x => x.ApplicationId == id).FirstOrDefault();
        //    if (data != null)
        //    {
        //        return Ok(data);
        //    }
        //    else
        //    {
        //        return BadRequest("ID not Found");
        //    }
        //}

        [HttpGet("get1/{id}")]
        public IActionResult getApplicationID(int id)
        {
            //var data = context.LoanDetails.Where(x => x.ApplicationId == id).FirstOrDefault();
            var data = from l in context.LoanDetails join p in context.PersonalDetails 
                       on l.Username equals p.Username where l.ApplicationId == id select new 
                       { l.ApplicationId, l.Username, l.MaxLoanAmountGrantable, l.InterestRate, l.Tenure, l.LoanAmount, 
                           p.FirstName,p.LastName,p.Gender,p.EmailId,p.DateOfBirth,p.Nationality,p.PhoneNumber,
                           p.AadharNumber, p.PanNumber };
            if (data != null)
            {
                return Ok(data.FirstOrDefault());
            }
            else
            {
                return BadRequest("ID not Found");
            }
        }

        [HttpGet("income/{id}")]
        public IActionResult getincomedetails(int id)
        {
            //var data = context.LoanDetails.Where(x => x.ApplicationId == id).FirstOrDefault();
            var data = from i in context.IncomeDetails
                       join l in context.LoanDetails
                        on i.Username equals l.Username
                       where l.ApplicationId == id
                       select new
                       {
                           i.PropertyName,
                           i.PropertyLocation,
                           i.EstimatedAmount,
                           i.OrganizationType,
                           i.RetirementAge,
                           i.TypeOfEmployment
                       };
            if (data != null)
            {
                return Ok(data.FirstOrDefault());
            }
            else
            {
                return BadRequest("ID not Found");
            }
        }


        [HttpPut("put/{id}")]
        public IActionResult approveData(LoanDetails loan)
        {
            AccountDetails account = new AccountDetails();
            int appid = loan.ApplicationId;
            var data = context.ApplicationDetails.Where(x => x.ApplicationId == appid).FirstOrDefault();
            if (data != null)
            {
                data.Status = "Approved";
                data.ApprovalDate = DateTime.Now;
                loan.LoanStartDate = DateTime.Now.AddDays(10);
                context.LoanDetails.Update(loan);
                context.ApplicationDetails.Update(data);
                Random rand = new Random();

                account.AccountNumber = rand.Next(40000, 50000);
                account.Username = loan.Username;
                account.LoanId = data.LoanId;
                account.AmountAvailable = loan.LoanAmount;
                data.AccountDetails.Add(account);
                context.SaveChanges();
                return Ok(data);
            }
            else
            {
                return BadRequest("ID not Found");
            }
        }

        [HttpPut("putreject/{id}")]
        public IActionResult rejectData(LoanDetails loan)
        {
            int appid = loan.ApplicationId;
            var data = context.ApplicationDetails.Where(x => x.ApplicationId == appid).FirstOrDefault();
            if (data != null)
            {
                data.Status = "Rejected";
                context.ApplicationDetails.Update(data);
                context.SaveChanges();
                return Ok(data);
            }
            else
            {
                return BadRequest("ID not Found");
            }
        }

        [HttpGet("rejected")]

        public IActionResult getrejected()
        {
            var data = from l in context.LoanDetails
                       join a in context.ApplicationDetails
                        on l.ApplicationId equals a.ApplicationId
                       where a.Status == "Rejected"
                       select new
                       {
                           l.ApplicationId,
                           l.MaxLoanAmountGrantable,
                           l.LoanAmount,
                           a.Status
                       };
            if (data != null)
            {
                return Ok(data);
            }
            else
            {
                return BadRequest();
            }

        }

        [HttpGet("approved")]

        public IActionResult getapproved()
        {
            var data = from l in context.LoanDetails
                       join a in context.ApplicationDetails
                        on l.ApplicationId equals a.ApplicationId
                       where a.Status == "Approved"
                       select new
                       {
                           l.ApplicationId,
                           l.MaxLoanAmountGrantable,
                           l.LoanAmount,
                           a.Status
                       };
            if (data != null)
            {
                return Ok(data);
            }
            else
            {
                return BadRequest();
            }

        }

    }
}
