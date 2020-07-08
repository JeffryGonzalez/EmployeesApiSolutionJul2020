using AutoMapper;
using EmployeesApi.Domain;
using EmployeesApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeesApi.MapperProfiles
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            // Employee -> EmployeeListItem
            CreateMap<Employee, EmployeeListItem>();
            CreateMap<Employee, GetEmployeeDetailsResponse>()
                   .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => $"{src.LastName}, {src.FirstName}"));
            CreateMap<PostEmployeeRequest, Employee>()
                .ForMember(dest => dest.Active, opt => opt.MapFrom((_) => true))
                .ForMember(dest => dest.Salary, opt => opt.MapFrom((_) => 80000));
            
        }
    }
}
