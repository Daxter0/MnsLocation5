using System.ComponentModel.DataAnnotations;

namespace MnsLocation5.Models
{
    public class MaterialRentalCart
    {
        public int MaterialID { get; set; }
        [Required]
        public int RentalCartID { get; set; }

        public Material Material { get; set; }
        public RentalCart RentalCart { get; set; }
    }
}
