using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeesApi.Models
{
    public class GetEmployeesResponse
    {
        public List<EmployeeListItem> Data { get; set; }
    }

    public class EmployeeListItem
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Department { get; set; }
    }
}
