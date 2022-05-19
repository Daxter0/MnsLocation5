using MnsLocation5.Models;

namespace MnsLocation5.Areas.Admin.Data
{
    public class ManagerDbInitializer
    {
        public static void Initialize(ManagerContext context)
        {
            if (context.Database.EnsureCreated())
            {
                BorrowerTable[] borrowers = new BorrowerTable[]
                {
                new BorrowerTable{FirstName="a", Password="b", Adress="c", LastName="d", Login="e", Mail="f", PhoneNumber=8}

                };

                foreach (BorrowerTable user in borrowers)
                {
                    context.Borrowers.Add(user);
                }

                Administrator[] admins = new Administrator[]
                {
                    new Administrator{FirstName="a", Password="b", Adress="c", LastName="d", Login="e", Mail="f", PhoneNumber=8}
                };
                foreach (Administrator admin in admins)
                {
                    context.Admins.Add(admin);
                }

                Material[] materials = new Material[]
                {
                new Material{Name = "Test", Condition ="Propre", Statut="Disponible" }

                };

                foreach (Material material in materials)
                {
                    context.Materials.Add(material);
                }
                MaterialType[] types = new MaterialType[]
                {
                    new MaterialType{Name="Camera"}
                };

                foreach (MaterialType type in types)
                {
                    context.Types.Add(type);
                }
            }

            context.SaveChanges();
        }
    }
}
