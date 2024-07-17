using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OutPatientDashboard.Service.Managers;

namespace OutPatientDashboard.Service.Controllers
{
    [Route("api/patient")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IPatientManager _patientManager;

        public PatientController(IPatientManager patientManager)
        {
            _patientManager = patientManager;
        }

        [HttpGet("incarecount")]
        public async Task<IActionResult> GetInCareCount()
        {
            try
            {
                int inCarePatientCount = await _patientManager.GetInCarePatientCount();

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
                int dischargeCount = await _patientManager.PatientsDischargedByDate(date);

                return Ok(dischargeCount);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
