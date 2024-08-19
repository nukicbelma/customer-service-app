using AutoMapper;
using CustomerServiceApp.WebAPI.Database;
using CustomerServiceApp.WebAPI.DTOs.Customer;
using CustomerServiceApp.WebAPI.Repositories.Interfaces;

public class CustomerService : ICustomerService
{
    private readonly ICustomerRepository _customerRepository;
    private readonly IMapper _mapper;

    public CustomerService(ICustomerRepository customerRepository, IMapper mapper)
    {
        _customerRepository = customerRepository;
        _mapper = mapper;
    }

    public async Task<CustomerDTO> GetCustomerByIdAsync(int id)
    {
        var customer = await _customerRepository.GetByIdAsync(id);
        return _mapper.Map<CustomerDTO>(customer);
    }

    public async Task<IEnumerable<CustomerDTO>> GetAllCustomersAsync()
    {
        var customers = await _customerRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<CustomerDTO>>(customers);
    }

    public async Task AddCustomerAsync(CustomerCreateDTO customerCreateDto)
    {
        var customer = _mapper.Map<Customer>(customerCreateDto);
        await _customerRepository.AddAsync(customer);
    }

    public async Task UpdateCustomerAsync(CustomerUpdateDTO customerUpdateDto)
    {
        var customer = _mapper.Map<Customer>(customerUpdateDto);
        await _customerRepository.UpdateAsync(customer);
    }

    public async Task DeleteCustomerAsync(int id)
    {
        await _customerRepository.DeleteAsync(id);
    }
}
