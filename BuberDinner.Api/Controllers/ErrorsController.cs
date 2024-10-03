using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace BuberDinner.Api.Controllers
{
    public class ErrorsController : Controller
    {
        [Route("/error")]
        public IActionResult Index()
        {
            var exception = HttpContext.Features.Get<IExceptionHandlerFeature>().Error;

            Console.WriteLine(exception);

            return Problem(title:exception.Message);
        }
    }
}
