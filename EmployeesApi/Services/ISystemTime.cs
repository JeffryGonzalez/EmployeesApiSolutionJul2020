using System;

namespace EmployeesApi.Services
{
    public interface ISystemTime
    {
        DateTime GetCurrent();
        DateTime GetCreatedAt();
    }
}