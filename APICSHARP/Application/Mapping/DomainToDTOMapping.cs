using APICSHARP.Domain.DTOs;
using APICSHARP.Domain.Model.EmployeeAggregate;
using AutoMapper;

namespace APICSHARP.Application.Mapping
{
    public class DomainToDTOMapping : Profile
    {
        public DomainToDTOMapping()
        {
            CreateMap<Employee, EmployeeDTO>()
                .ForMember(dest => dest.NameEmployee, m => m.MapFrom(orig => orig.name));
        }
    }
}
