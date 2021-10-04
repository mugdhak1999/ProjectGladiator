using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ProjectGladiator.Models
{
    public partial class PersonalDetails
    {
        public PersonalDetails()
        {
            AccountDetails = new HashSet<AccountDetails>();
            LoanDetails = new HashSet<LoanDetails>();
        }

        public string Username { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string EmailId { get; set; }
        public string Password { get; set; }
        public long? PhoneNumber { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string Nationality { get; set; }
        public long? AadharNumber { get; set; }
        public string PanNumber { get; set; }

        public virtual IncomeDetails IncomeDetails { get; set; }
        public virtual ICollection<AccountDetails> AccountDetails { get; set; }
        public virtual ICollection<LoanDetails> LoanDetails { get; set; }
    }
}
