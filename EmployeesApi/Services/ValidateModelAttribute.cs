using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeesApi.Services
{
    public class ValidateModelAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            
            if(!context.ModelState.IsValid)
            {
                // do some logging. 
                // project this into another response type.
                
                context.Result = new BadRequestObjectResult(context.ModelState);
            }
        }
    }
}
