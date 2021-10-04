using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ProjectGladiator.Models
{
    public partial class LoanDetails
    {
        public LoanDetails()
        {
            ApplicationDetails = new HashSet<ApplicationDetails>();
        }

        public int ApplicationId { get; set; }
        public string Username { get; set; }
        public decimal? MaxLoanAmountGrantable { get; set; }
        public decimal? InterestRate { get; set; }
        public int? Tenure { get; set; }
        public decimal? LoanAmount { get; set; }
        public DateTime? LoanStartDate { get; set; }

        public virtual PersonalDetails UsernameNavigation { get; set; }
        public virtual ICollection<ApplicationDetails> ApplicationDetails { get; set; }
    }
}
