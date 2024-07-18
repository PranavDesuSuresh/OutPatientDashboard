using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OutPatientDashboard.Service.Managers;
using OutPatientDashboard.Service.Util;

namespace OutPatientDashboard.Service.Controllers
{
    [Route("api/physician")]
    [ApiController]
    public class PhysicianController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IPhysicianManager _physicianManager;
        private readonly ICustomLogger _logger;

        public PhysicianController(IMapper mapper, IPhysicianManager physicianManager, ICustomLogger logger)
        {
            _mapper = mapper;
            _physicianManager = physicianManager;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var physicians = await _physicianManager.GetPhysicianList();

                if (physicians == null)
                {
                    return NotFound();
                }

                return Ok(physicians);
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                throw;
            }
        }

        [HttpGet("throughput/{id}")]
        public async Task<IActionResult> Throughput([FromRoute] int id)
        {
            try
            {
                var throughput = await _physicianManager.GetPhysicianThroughPut(id);

                return Ok(throughput);
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                throw;
            }
        }
    }
}
