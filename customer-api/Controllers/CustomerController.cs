using Company.CustomerApi.DataAccess;
using Company.CustomerApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Company.CustomerApi.Controllers;

[ApiController]
[Route("customers")]
[Produces("application/json")]
public class CustomerController : ControllerBase
{
    private readonly CustomerContext customerContext;
    public CustomerController(CustomerContext customerContext)
    {
        this.customerContext = customerContext;
    }

    
    [HttpGet]
    public async Task<IList<Customer>> GetAsync()
    {
        return await customerContext.Customers.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<Customer> GetByIdAsync(Guid id)
    {
        return await customerContext.Customers.FindAsync(id);
    }

    [HttpPost]
    public async Task<Customer> CreateAsync(Customer customer)
    {
        customer.Id = Guid.NewGuid();
        customerContext.Customers.Add(customer);
        await customerContext.SaveChangesAsync();
        return customer;
    }

    [HttpPut("{id}")]
    public async Task<Customer> UpdateAsync(Guid id, Customer customer)
    {
        customer.Id = id;

        if (await customerContext.Customers.AnyAsync(c => c.Id == id))
        {
            customerContext.Customers.Update(customer);
            await customerContext.SaveChangesAsync();
            return customer;
        }
        else
        {
            return null;
        }
    }

    [HttpDelete("{id}")]
    public async Task DeleteAsync(Guid id)
    {
        var customer = await customerContext.Customers.FindAsync(id);

        if (customer != null)
        {
            customerContext.Customers.Remove(customer);
            await customerContext.SaveChangesAsync();
        }
    }
}
