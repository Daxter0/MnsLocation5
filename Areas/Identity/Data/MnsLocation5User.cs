using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace MnsLocation5.Areas.Identity.Data
{
    // Add profile data for application users by adding properties to the MnsLocation5User class
    public class MnsLocation5User : IdentityUser
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Adress { get; set; }
    }
}
