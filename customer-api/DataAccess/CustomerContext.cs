using Microsoft.EntityFrameworkCore;
using Company.CustomerApi.Models;

namespace Company.CustomerApi.DataAccess;

public class CustomerContext : DbContext
{
    public DbSet<Customer> Customers { get; set; }

    public CustomerContext (DbContextOptions<CustomerContext> options)
        : base(options)
    {
    }
}