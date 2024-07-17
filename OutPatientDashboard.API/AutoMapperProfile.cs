using AutoMapper;
using OutPatientDashboard.API.DTO.Physician;
using OutPatientDashboard.API.Models;

namespace OutPatientDashboard.API
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() {

            CreateMap<Physician, PhysicianIdNameDto>()
                .ForMember(d => d.Id, map => map.MapFrom(src => src.Id))
                .ForMember(d => d.Name, map => map.MapFrom(src => $"{src.FirstName} {src.LastName}"));
        }
    }
}
