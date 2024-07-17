using AutoMapper;
using OutPatientDashboard.Service.DTO.Physician;
using OutPatientDashboard.Service.Models;

namespace OutPatientDashboard.Service
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {

            CreateMap<Physician, PhysicianIdNameDto>()
                .ForMember(d => d.Id, map => map.MapFrom(src => src.Id))
                .ForMember(d => d.Name, map => map.MapFrom(src => $"{src.FirstName} {src.LastName}"));
        }
    }
}
