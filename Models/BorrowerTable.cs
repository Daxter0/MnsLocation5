namespace MnsLocation5.Models
{
    public class BorrowerTable : User
    {
        public string Status  { get; set; }
        public RentalCart RentalCart { get; set; }

    }
}
