using CoreBackend.Core.Model;
using CoreBackend.Helpers.Api;
using CoreBackend.Helpers.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CoreBackend.Helpers.ActionFilters
{
    public class ValidationFilterAttribute : IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                var errors = context.ModelState.Values.SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage)
                    .ToList();

                var error = Response.Error(null, errors, "Invalid request data", "Bad Request");

                throw new CustomException(error);
            }
        }
        public void OnActionExecuted(ActionExecutedContext context) { }
    }


}
