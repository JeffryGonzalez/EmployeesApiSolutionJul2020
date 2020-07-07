using EmployeesApi.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeesApi.Controllers
{
    public class OrderProcessorController : ControllerBase
    {
        ISystemTime Clock;

        public OrderProcessorController(ISystemTime clock)
        {
            Clock = clock;
        }

        // you post an Order, it gives you confirmation.
        // If the order is placed before noon, the shipping date is today.
        // Otherwise it's tomorrow.
        [HttpPost("orders")]
        public ActionResult<OrderResponse> PlaceOrder([FromBody] OrderRequest order)
        {
            var response = new OrderResponse
            {
                EstimatedShipDate = Clock.GetCurrent().Hour < 12 ? Clock.GetCurrent() : Clock.GetCurrent().AddDays(1)
            };
            return Ok(response);
    }
}

public class OrderRequest
{

}

public class OrderResponse
{
    public DateTime EstimatedShipDate { get; set; }
}
}
