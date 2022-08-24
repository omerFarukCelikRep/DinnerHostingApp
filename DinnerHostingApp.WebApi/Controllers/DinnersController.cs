using Microsoft.AspNetCore.Mvc;

namespace DinnerHostingApp.WebApi.Controllers;

[Route("[controller]")]
public class DinnersController : ApiController
{
    public IActionResult ListDinners()
    {
        return Ok(Array.Empty<string>());
    }
}