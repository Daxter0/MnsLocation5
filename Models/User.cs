using Microsoft.AspNetCore.Identity;

namespace MnsLocation5.Models
{
    public class User : IdentityUser
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Adress { get; set; }

    }
}
