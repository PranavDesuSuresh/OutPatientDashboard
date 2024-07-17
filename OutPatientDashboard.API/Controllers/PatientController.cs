using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OutPatientDashboard.API.Data;

namespace OutPatientDashboard.API.Controllers
{
    [Route("api/patient")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        public PatientController(ApplicationDBContext context)
        {
            _context = context;
        }

        [HttpGet("incarecount")]
        public async Task<IActionResult> GetInCareCount()
        {
            try
            {
                int inCarePatientCount = await _context.Patient
                    .CountAsync(a => 
                    a.AdmissionDate.HasValue 
                    && a.AdmissionDate.Value.Date == DateTime.Today
                    && !a.DischargeDate.HasValue);

                return Ok(inCarePatientCount);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpGet("dischargedbydate")]
        public async Task<IActionResult> DischargedByDate(DateTime? date)
        {
            try
            {
                date ??= DateTime.Today;

                int dischargeCount = await _context.Patient
                    .CountAsync(a =>
                    a.DischargeDate.HasValue
                    && a.AdmissionDate.Value.Date == date.Value.Date);

                return Ok(dischargeCount);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
