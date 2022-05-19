using MnsLocation5.Models;
using System.Collections.Generic;

namespace MnsLocation5.Areas.Borrower.Models
{
    public class RentalCartModelView
    {
        public List<RentalCart> RentalCarts { get; set; }

        public RentalCartModelView(List<RentalCart> rentalCarts)
        {
            RentalCarts = rentalCarts;
        }
    }
}
