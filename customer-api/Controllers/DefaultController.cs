using Company.CustomerApi.DataAccess;
using Company.CustomerApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Company.CustomerApi.Controllers;

[ApiController]
[Route("/")]
public class DefaultController : ControllerBase
{
    [HttpGet]
    [ApiExplorerSettings(IgnoreApi = true)]
    public IActionResult Get()
    {
        var html = "<div style=\"font-family: Verdana, Arial, Helvetica, sans-serif;\">" +
                "Welcome to the Customer API!<br><br>" +
                "Swagger UI: <a href=\"/swagger/index.html\">/swagger/index.html</a><br>" +
                "</div>";

        return Content(html, "text/html");
    }
}
