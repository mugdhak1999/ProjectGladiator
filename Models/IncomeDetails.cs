using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ProjectGladiator.Models
{
    public partial class IncomeDetails
    {
        public string Username { get; set; }
        public string PropertyLocation { get; set; }
        public string PropertyName { get; set; }
        public int? EstimatedAmount { get; set; }
        public string TypeOfEmployment { get; set; }
        public int? RetirementAge { get; set; }
        public string OrganizationType { get; set; }
        public string EmployerName { get; set; }

        public virtual PersonalDetails UsernameNavigation { get; set; }
    }
}
