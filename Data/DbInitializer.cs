using MnsLocation5.Data;
using MnsLocation5.Models;
using System.Collections.Generic;


namespace MnsLocation5.Areas.Borrower
    .Data
{
    public class DbInitializer
    {
        public static void Initialize(AppDbContext context)
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
                Material[] materials = new Material[]
                {
                    new Material{}
                };

                foreach(Material material in materials)
                {
                    context.Materials.Add(material);
                };
                MaterialType[] materialTypes = new MaterialType[]
                {
                    new MaterialType{}
                };
                foreach (MaterialType materialType in materialTypes)
                {
                    context.MaterialType.Add(materialType);
                }

            }

            context.SaveChanges();
        }
    }
}
