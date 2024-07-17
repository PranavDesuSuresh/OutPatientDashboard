using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OutPatientDashboard.Service.Data;
using OutPatientDashboard.Service.DTO.Physician;
using OutPatientDashboard.Service.Models;

namespace OutPatientDashboard.Service.Managers
{
    public interface IPhysicianManager
    {
        public Task<List<PhysicianIdNameDto>> GetPhysicianList();

        public Task<int> GetPhysicianThroughPut(int physicianId);

    }

    public class PhysicianManager : IPhysicianManager
    {
        private readonly ApplicationDBContext _context;
        private readonly IMapper _mapper;

        public PhysicianManager(ApplicationDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<PhysicianIdNameDto>> GetPhysicianList()
        {
            List<PhysicianIdNameDto> physiciansList = null;

            try
            {
                var physicians = await _context.Physician.ToListAsync();

                if (physicians != null)
                {
                    physiciansList = _mapper.Map<List<Physician>, List<PhysicianIdNameDto>>(physicians);
                }

            }
            catch (Exception)
            {
                throw;
            }
            return physiciansList;
        }

        public async Task<int> GetPhysicianThroughPut(int physicianId)
        {
            int throughPut = 0;

            try
            {
                throughPut = await _context.Patient.CountAsync(
                    p => p.Physician != null
                    && p.PhysicianId == physicianId
                    && p.DischargeDate.HasValue
                    && p.DischargeDate.Value.Month == (DateTime.Now.Month - 1));
            }
            catch (Exception)
            {
                throw;
            }

            return throughPut;
        }
    }
}
