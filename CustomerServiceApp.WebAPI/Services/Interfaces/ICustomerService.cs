using System.Collections.Generic;
using System.Threading.Tasks;
using CustomerServiceApp.WebAPI.DTOs;
using CustomerServiceApp.WebAPI.DTOs.Customer;

public interface ICustomerService
{
    Task<CustomerDTO> GetCustomerByIdAsync(int customerId);
    Task<IEnumerable<CustomerDTO>> GetAllCustomersAsync();
    Task AddCustomerAsync(CustomerCreateDTO customerCreateDto); 
    Task UpdateCustomerAsync(CustomerUpdateDTO customerUpdateDto);
    Task DeleteCustomerAsync(int customerId);
}
