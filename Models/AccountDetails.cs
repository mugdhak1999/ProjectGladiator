using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ProjectGladiator.Models
{
    public partial class AccountDetails
    {
        public int AccountNumber { get; set; }
        public string Username { get; set; }
        public int? LoanId { get; set; }
        public decimal? AmountAvailable { get; set; }

        public virtual ApplicationDetails Loan { get; set; }
        public virtual PersonalDetails UsernameNavigation { get; set; }
    }
}
