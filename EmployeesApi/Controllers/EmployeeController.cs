using EmployeesApi.Domain;
using EmployeesApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeesApi.Controllers
{
    public class EmployeeController : ControllerBase
    {
        private readonly EmployeesDataContext Context;

        public EmployeeController(EmployeesDataContext context)
        {
            Context = context;
        }

        [HttpGet("employees")]
        public async Task<ActionResult> GetAllEmployees()
        {
            var employees =  await Context.Employees
                .Where(e => e.Active)
                .Select(e => new EmployeeListItem
                {
                    Id = e.Id,
                    FirstName = e.FirstName,
                    LastName = e.LastName,
                    Department = e.Department
                })
                .ToListAsync();

            var response = new GetEmployeesResponse
            {
                Data = employees
            };
            return Ok(response);
        }
    }
}
