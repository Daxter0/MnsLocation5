using MnsLocation5.Models;
using System.Collections.Generic;

namespace MnsLocation5.ViewsModel
{
    public class UserRentalCartViewModel
    {
        public User User { get; set; }
        public RentalCart RentalCart { get; set; }

        public List<Material> ChoosenMaterials { get; set; }

        public UserRentalCartViewModel()
        {
            User = new User();
            RentalCart = new RentalCart();
            ChoosenMaterials = new List<Material>();
        }

        public UserRentalCartViewModel(User user, RentalCart rentalCart)
        {
            User=user;
            RentalCart = rentalCart;
            ChoosenMaterials=new List<Material>();
        }
    }
}
