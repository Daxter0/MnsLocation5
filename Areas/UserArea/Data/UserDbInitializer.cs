using MnsLocation5.Models;
using System.Collections.Generic;

namespace MnsLocation5.Areas.UserArea.Data
{
    public class UserDbInitializer
    {
        public static void Initialize(UserContext context)
        {
            if (context.Database.EnsureCreated())
            {
                RentalCart[] rentalCarts = new RentalCart[]
                {
                new RentalCart{}

                };

                foreach (RentalCart rentalCart in rentalCarts)
                {
                    context.RentalCarts.Add(rentalCart);
                }
                
            }

            context.SaveChanges();
        }
    }
}
