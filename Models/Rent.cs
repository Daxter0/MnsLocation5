using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MnsLocation5.Models
{
    public class Rent
    {
        public int ID { get; set; }
        public List<Material> ChoosenMaterials { get; set; }
        public string UserRefId { get; set; }
        [ForeignKey("UserRefId")]
        public User User { get; set; }
        public DateTime RentDate { get; set; }
        public string Reason { get; set; }
        public DateTime RentalStart { get; set; }
        public DateTime RentalEnd { get; set; }
        public int RentalCartRefId { get; set; }
        [ForeignKey("RentalCartRefId")]
        public RentalCart RentalCart { get; set; }      

    }
}
