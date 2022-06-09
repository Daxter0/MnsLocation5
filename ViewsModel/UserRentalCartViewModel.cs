using MnsLocation5.Models;
using System.Collections.Generic;
using MnsLocation5.Data;

namespace MnsLocation5.ViewsModel
{
    public class UserRentalCartViewModel
    {
        public User User { get; set; }
        public RentalCart RentalCart { get; set; }

        public List<Material> ChoosenMaterials { get; set; }

        
    }
}
