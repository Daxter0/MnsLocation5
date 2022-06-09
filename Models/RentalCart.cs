using System.Collections.Generic;

namespace MnsLocation5.Models
{
    public class RentalCart
    {
        public int ID { get; set; }
        public ICollection<User> Users { get; set; }
        public ICollection<Rent> Rents { get; set; }
        public ICollection<Material> ChoosenMaterials { get; set; } = new List<Material>();

    }
}
