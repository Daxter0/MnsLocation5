namespace MnsLocation5.Models
{
    public abstract class User
    {
        public int ID { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Adress { get; set; }
        public int PhoneNumber { get; set; }
        public string Mail { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
