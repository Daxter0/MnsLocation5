using System.Collections.Generic;
namespace MnsLocation5.Models
{
    public class RentalCart
    {
        public int ID { get; set; }
        public List<Material> ChoosenMaterials { get; set; }
    }
}
