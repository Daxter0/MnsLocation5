using MnsLocation5.Areas.Identity.Data;
using MnsLocation5.Models;

namespace MnsLocation5.Areas.Identity.Models
{
    public class BorrowerTable : MnsLocation5User
    {
        public string Status { get; set; }
        public RentalCart RentalCart { get; set; }

    }
}
