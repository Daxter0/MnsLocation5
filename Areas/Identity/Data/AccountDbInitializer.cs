using Microsoft.EntityFrameworkCore;
using MnsLocation5.Areas.Identity.Models;
using MnsLocation5.Data;

namespace MnsLocation5.Areas.Identity.Data
{
    public class AccountDbInitializer
    {
        public static void Initialize(MnsLocation5Context context)
        {
            if (context.Database.EnsureCreated())
            {
                BorrowerTable[] borrowers = new BorrowerTable[]
                {
                new BorrowerTable{FirstName="a", Adress="c", LastName="d", PhoneNumber="8"}

                };

                foreach (BorrowerTable user in borrowers)
                {
                    context.Borrowers.Add(user);
                }

                Administrator[] admins = new Administrator[]
                {
                    new Administrator{FirstName="a", Adress="c", LastName="d", PhoneNumber="8"}
                };
                foreach (Administrator admin in admins)
                {
                    context.Admins.Add(admin);
                }
            }

            context.SaveChanges();
        }
    }
}
