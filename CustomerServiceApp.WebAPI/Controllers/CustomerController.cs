using Microsoft.AspNetCore.Mvc;
using CustomerServiceApp.WebAPI.DTOs.Customer;

[ApiController]
[Route("api/[controller]")]
public class CustomerController : ControllerBase
{
    private readonly ICustomerService _customerService;

    public CustomerController(ICustomerService customerService)
    {
        _customerService = customerService;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetCustomerById(int customerId)
    {
        var customerDto = await _customerService.GetCustomerByIdAsync(customerId);
        if (customerDto == null)
        {
            return NotFound();
        }
        return Ok(customerDto);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllCustomers()
    {
        var customerDtos = await _customerService.GetAllCustomersAsync();
        return Ok(customerDtos);
    }

    [HttpPost]
    public async Task<IActionResult> AddCustomer([FromBody] CustomerCreateDTO customerCreateDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        await _customerService.AddCustomerAsync(customerCreateDto);
        return CreatedAtAction(nameof(GetCustomerById), new { id = customerCreateDto.CustomerId }, customerCreateDto);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateCustomer(int customerId, [FromBody] CustomerUpdateDTO customerUpdateDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        if (customerId != customerUpdateDto.CustomerId)
        {
            return BadRequest("Customer ID mismatch");
        }

        await _customerService.UpdateCustomerAsync(customerUpdateDto);
        return NoContent();
    }

    [HttpPut("{id}/delete")]
    public async Task<IActionResult> DeleteCustomer(int customerId)
    {
        await _customerService.DeleteCustomerAsync(customerId);
        return NoContent();
    }

}
