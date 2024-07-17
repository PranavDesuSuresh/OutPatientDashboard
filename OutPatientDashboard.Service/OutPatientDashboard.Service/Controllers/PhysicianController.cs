using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OutPatientDashboard.Service.Managers;

namespace OutPatientDashboard.Service.Controllers
{
    [Route("api/physician")]
    [ApiController]
    public class PhysicianController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IPhysicianManager _physicianManager;

        public PhysicianController(IMapper mapper, IPhysicianManager physicianManager)
        {
            _mapper = mapper;
            _physicianManager = physicianManager;
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
            catch (Exception)
            {
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
            catch (Exception)
            {
                throw;
            }
        }
    }
}
