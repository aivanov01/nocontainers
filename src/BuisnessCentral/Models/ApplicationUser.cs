namespace BuisnessCentral.Models
{
    public class ApplicationUser
    {
        public Guid Guid { get; set; }
        public string CardNumber { get; set; } = string.Empty;
        public string SecurityNumber { get; set; } = string.Empty;
        public string Expiration { get; set; } = string.Empty; 
        public string CardHolderName { get; set; } = string.Empty;
        public int CardType { get; set; }   
        public string Street { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string State { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty; 
        public string Country { get; set; } = string.Empty;
        public string ZipCode { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
    }
}
