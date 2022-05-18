namespace MnsLocation5.Models
{
    public class Borrower : User
    {
        public string Status  { get; set; }
        public RentalCart RentalCart { get; set; }

    }
}
