using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MnsLocation5.Models
{
    public class Rent
    {
        public int ID { get; set; }
        public string UserRefId { get; set; }
        [ForeignKey("UserRefId")]
        public User User { get; set; }
        public int RentRentalCartRefId { get; set; }
        [ForeignKey("RentRentalCartRefId")]
        public RentalCart RentalCart { get; set; }
        public DateTime RentDate { get; set; }
        public string Reason { get; set; }
        public DateTime RentalStart { get; set; }
        public DateTime RentalEnd { get; set; }
            

    }
}
