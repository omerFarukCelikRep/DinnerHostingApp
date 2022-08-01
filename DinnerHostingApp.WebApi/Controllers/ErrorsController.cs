using Microsoft.AspNetCore.Mvc;

namespace DinnerHostingApp.WebApi.Controllers;

public class ErrorsController : ApiController
{
    [Route("/error")]
    public IActionResult Error()
    {
        return Problem(statusCode: StatusCodes.Status500InternalServerError, title: "An unexpected error occured!");
    }
}