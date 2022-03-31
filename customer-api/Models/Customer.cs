using Swashbuckle.AspNetCore.Annotations;

namespace Company.CustomerApi.Models;

public class Customer
{
    [SwaggerSchema("The customer Id.", ReadOnly = true)]
    public Guid? Id { get; set; }
    public string Name { get; set; }
}
