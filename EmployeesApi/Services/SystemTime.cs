using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeesApi.Services
{
    public class SystemTime : ISystemTime
    {
        DateTime Created;
        public SystemTime()
        {
            Created = DateTime.Now;
        }
        public DateTime GetCreatedAt()
        {
            return Created;
        }

        public DateTime GetCurrent()
        {
            return DateTime.Now;
        }
       
    }
}
