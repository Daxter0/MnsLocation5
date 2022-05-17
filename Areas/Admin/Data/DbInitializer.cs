using MnsLocation5.Models;

namespace MnsLocation5.Areas.Admin.Data
{
    public class DbInitializer
    {
        public static void Initialize(AdminManagerContext context)
        {
            if (context.Database.EnsureCreated())
            {
                User[] users = new User[]
                {
                new User{FirstName="a", Password="b", Adress="c", LastName="d", Login="e", Mail="f", PhoneNumber=8}

                };

                foreach (User user in users)
                {
                    context.Users.Add(user);
                }
                Material[] materials = new Material[]
                {
                new Material{Name = "Test", Type = "Camera", Condition ="Propre", Statut="Disponible" }

                };

                foreach (Material material in materials)
                {
                    context.Materials.Add(material);
                }
            }

            context.SaveChanges();
        }
    }
}
