namespace CustomerServiceApp.WebAPI.DTOs.Customer
{
    public class CustomerCreateDTO
    {
        public int CustomerId { get; set; } 
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string? PhoneNumber { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public bool Valid { get; set; } = true;
    }
}
