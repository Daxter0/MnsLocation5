using MnsLocation5.Models;
using System.Collections.Generic;
using MnsLocation5.Data;

namespace MnsLocation5.ViewsModel
{
    public class UserRentalCartViewModel
    {
        public User User { get; set; } = new User();

        public List<User> Users { get; set; } = new List<User>();
        public List<RentalCart> RentalCarts { get; set; } = new List<RentalCart>();
        public RentalCart RentalCart { get; set; } = new RentalCart();
        public MaterialRentalCart MaterialRentalCart { get; set; } = new MaterialRentalCart();
        public List<Material> ChoosenMaterials { get; set; } = new List<Material>();

        
    }
}
