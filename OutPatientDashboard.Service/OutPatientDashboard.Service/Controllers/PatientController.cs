using Microsoft.AspNetCore.Mvc;
using OutPatientDashboard.Service.Managers;
using OutPatientDashboard.Service.Util;

namespace OutPatientDashboard.Service.Controllers
{
    [Route("api/patient")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IPatientManager _patientManager;
        private readonly ICustomLogger _logger;

        public PatientController(IPatientManager patientManager, ICustomLogger logger)
        {
            _patientManager = patientManager;
            _logger = logger;
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
                _logger.Error(ex);
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
                _logger.Error(ex);
                throw;
            }
        }
    }
}
