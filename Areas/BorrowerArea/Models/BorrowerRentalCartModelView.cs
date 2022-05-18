using MnsLocation5.Models;
using System.Collections.Generic;

namespace MnsLocation5.Areas.UserArea.Models
{
    public class BorrowerRentalCartModelView
    {
        public List<RentalCart> RentalCarts { get; set; }

        public BorrowerRentalCartModelView(List<RentalCart> rentalCarts)
        {
            RentalCarts = rentalCarts;
        }
    }
}
