using MnsLocation5.Models;

namespace MnsLocation5.Areas.Admin.Data
{
    public class ManagerDbInitializer
    {
        public static void Initialize(ManagerContext context)
        {
            if (context.Database.EnsureCreated())
            {
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
