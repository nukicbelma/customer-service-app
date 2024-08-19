namespace CustomerServiceApp.WebAPI.DTOs.Customer
{
    public class CustomerDTO
    {
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string? PhoneNumber { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool Valid { get; set; }
    }
}
