using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MnsLocation5.Models
{
    public class RentalCart 
    {
        public int ID { get; set; }
        public List<Material> ChoosenMaterials { get; set; }
        public string UserRefId { get; set; }
        [ForeignKey("UserRefId")]
        public User User { get; set; }

       
    }

}
