using Microsoft.EntityFrameworkCore;
using OutPatientDashboard.Service.Data;

namespace OutPatientDashboard.Service.Managers
{
    public interface IPatientManager
    {
        public Task<int> GetInCarePatientCount();

        public Task<int> PatientsDischargedByDate(DateTime? date);
    }

    public class PatientManager : IPatientManager
    {
        private readonly ApplicationDBContext _context;

        public PatientManager(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<int> GetInCarePatientCount()
        {
            int inCarePatientCount = 0;
            try
            {
                inCarePatientCount = await _context.Patient
                    .CountAsync(a =>
                    a.AdmissionDate.HasValue
                    && a.AdmissionDate.Value.Date == DateTime.Today
                    && !a.DischargeDate.HasValue);
            }
            catch (Exception ex)
            {
                throw;
            }
            return inCarePatientCount;
        }

        public async Task<int> PatientsDischargedByDate(DateTime? date)
        {
            int patientsDischargeCount = 0;
            try
            {
                date ??= DateTime.Today;

                patientsDischargeCount = await _context.Patient
                    .CountAsync(a =>
                    a.DischargeDate.HasValue
                    && a.AdmissionDate.HasValue
                    && a.AdmissionDate.Value.Date == date.Value.Date);
            }
            catch (Exception ex)
            {
                throw;
            }
            return patientsDischargeCount;
        }
    }
}
