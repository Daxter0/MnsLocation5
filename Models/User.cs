using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace MnsLocation5.Models
{
    public class User : IdentityUser
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Adress { get; set; }

        public List<Material> Cart { get; set; }
        public ICollection<HistoricUser> HistoricModification { get; set; }

    }
}
