using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeesApi.Controllers
{
    public class ErrorController : ControllerBase
    {

        [HttpGet("/error")]
        public IActionResult Error()
        {
            return Problem();  // RFC 7807
        }
    }
}
