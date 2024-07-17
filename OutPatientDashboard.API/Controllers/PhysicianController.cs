using AutoMapper;
using Azure.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OutPatientDashboard.API.Data;
using OutPatientDashboard.API.DTO.Physician;
using OutPatientDashboard.API.Models;
using System;

namespace OutPatientDashboard.API.Controllers
{
    [Route("api/physician")]
    [ApiController]
    public class PhysicianController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        private readonly IMapper _mapper;

        public PhysicianController(ApplicationDBContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var physicians = await _context.Physician.ToListAsync();

                if (physicians == null)
                {
                    return NotFound();
                }

                List<PhysicianIdNameDto> physicianIdNameList = _mapper.Map<List<Physician>, List<PhysicianIdNameDto>>(physicians);

                return Ok(physicianIdNameList);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpGet("throughput/{id}")]
        public async Task<IActionResult> Throughput([FromRoute] int id)
        {
            try
            {
                var physician = await _context.Physician.FindAsync(id);

                if (physician == null)
                {
                    return NotFound();
                }

                //TODO : fix the logic p
                var throughput = _context.Patient.Count(
                    p => p.Physician != null
                    && p.PhysicianId == id
                    && p.DischargeDate.HasValue
                    && p.DischargeDate.Value.Month == (DateTime.Now.Month - 1));

                return Ok(throughput);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
