using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MnsLocation5.Models
{
    public class User : IdentityUser
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Adress { get; set; }
        public int UserRentalCartRefId { get; set; }
        [ForeignKey("UserRentalCartRefId")]
        public RentalCart RentalCart { get; set; } = new RentalCart();
        public ICollection<HistoricUser> HistoricModification { get; set; }

    }
}
