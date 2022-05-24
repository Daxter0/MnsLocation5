﻿using MnsLocation5.Models;
using System.Collections.Generic;


namespace MnsLocation5.Areas.Borrower
    .Data
{
    public class DbInitializer
    {
        public static void Initialize(Context context)
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

                Rent[] rents = new Rent[]
                {
                new Rent{}

                };

                foreach (Rent rent in rents)
                {
                    context.Rents.Add(rent);
                }

            }

            context.SaveChanges();
        }
    }
}