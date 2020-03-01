using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace DeliveryPlanning.Areas.Identity.Data
{
    // Add profile data for application users by adding properties to the DeliveryPlanningUser class
    public class DeliveryPlanningUser : IdentityUser
    {

        public string AccountType { get; set; }

        [PersonalData]
        public string Name { get; set; }
        [PersonalData]
        public DateTime DOB { get; set; }
    }
}
