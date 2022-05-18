using MnsLocation5.Models;
using System.Collections.Generic;

namespace MnsLocation5.Areas.UserArea.Models
{
    public class UserModelView
    {
        public List<RentalCart> RentalCarts { get; set; }

        public UserModelView(List<RentalCart> rentalCarts)
        {
            RentalCarts = rentalCarts;
        }
    }
}
