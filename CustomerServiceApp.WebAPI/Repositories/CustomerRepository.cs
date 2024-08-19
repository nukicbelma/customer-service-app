using Microsoft.EntityFrameworkCore;
using CustomerServiceApp.WebAPI.Database;
using CustomerServiceApp.WebAPI.Repositories.Interfaces;

public class CustomerRepository : ICustomerRepository
{
    private readonly CustomerServiceAppDBContext _context;

    public CustomerRepository(CustomerServiceAppDBContext context)
    {
        _context = context;
    }

    public async Task<Customer> GetByIdAsync(int customerId)
    {
        return await _context.Customers  
            .Where(c => c.CustomerId == customerId && c.Valid == true)
            .FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<Customer>> GetAllAsync()
    {
        return await _context.Customers 
            .Where(c => c.Valid == true)
            .ToListAsync();
    }

    public async Task AddAsync(Customer customer)
    {
        _context.Customers.Add(customer); 
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Customer customer)
    {
        _context.Customers.Update(customer);  
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int customerId)
    {
        //soft delete implemented
        var customer = await _context.Customers.FindAsync(customerId);  
        if (customer != null)
        {
            customer.Valid = false;
            _context.Customers.Update(customer); 
            await _context.SaveChangesAsync();
        }
    }
}
