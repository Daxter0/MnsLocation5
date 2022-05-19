using System;

namespace MnsLocation5.Models
{
    public class Rent
    {
        public int ID { get; set; }
        public DateTime RentDate { get; set; }
        public RentalCart RentalCart { get; set; }
        public string Reason { get; set; }
        public DateTime RentalStart { get; set; }
        public DateTime RentalEnd { get; set; }
    }
}
