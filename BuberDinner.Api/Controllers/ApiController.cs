using BuberDinner.Api.Http;
using ErrorOr;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace BuberDinner.Api.Controllers
{
    public class ApiController : Controller
    {
        protected IActionResult Problem(List<Error> errors)
        {
            if (errors.Count is 0) return Problem();

            if (errors.All(error => error.Type == ErrorType.Validation))
                return HandleValidationError(errors);
 
            HttpContext.Items[HttpContextItemKeys.Errors] = errors;

            var firstError = errors[0];

            return HandleProblem(firstError);
        }

        private IActionResult HandleProblem(Error firstError)
        {
            var statusCode = firstError.Type switch
            {
                ErrorType.Conflict => StatusCodes.Status409Conflict,
                ErrorType.Validation => StatusCodes.Status400BadRequest,
                ErrorType.NotFound => StatusCodes.Status404NotFound,
                _ => StatusCodes.Status500InternalServerError
            };

            return Problem(statusCode: statusCode, title: firstError.Description);
        }

        private IActionResult HandleValidationError(List<Error> errors)
        {
            var modelStateDictionary = new ModelStateDictionary();
            foreach (var error in errors)
            {
                modelStateDictionary.AddModelError(error.Code, error.Description);
            }
            return ValidationProblem();
        }
    }
}
