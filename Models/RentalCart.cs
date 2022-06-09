using System.Collections.Generic;

namespace MnsLocation5.Models
{
    public class RentalCart
    {
        public int RentalCartID { get; set; }
        public ICollection<User> Users { get; set; }
        public ICollection<Rent> Rents { get; set; }
        public List<Material> ChoosenMaterials { get; set; } = new List<Material>();
    }
}
