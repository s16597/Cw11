using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cw11.Models;
using Microsoft.AspNetCore.Mvc;
using Cw11.Services;

namespace Cw11.Controllers
{
    [Route("api/health")]
    [ApiController]
    public class HealthController : ControllerBase
    {
        private readonly IHealthDbService _service;
        public HealthController(IHealthDbService service)
        {
            _service = service;
        }
        [HttpGet]
        public IActionResult GetDoctors()
        {
            return Ok(_service.GetDoctors());
        }

        [HttpGet("{id}")]
        public IActionResult GetDoctor(string id)
        {
            var _doctors = _service.GetDoctor(id);
            if (_doctors.Any())
                return Ok(_service.GetDoctor(id));
            else
                return NotFound();
        }

        [Route("AddDoctor")]
        [HttpPost]
        public IActionResult AddDoctor(Doctor doctor)
        {
            var doc = _service.AddDoctor(doctor);
            if (doc == null)
            {
                return BadRequest("Wprowadź poprawne i kompletne dane lekarza");
            }
            else
            {
                return Ok(doc);
            }
        }
        [HttpPut("{id}")]
        public IActionResult EditDoctor([FromQuery] int id, [FromBody] Doctor req)
        {
            var doc = _service.UpdateDoctor(id, req);
            if (doc == null)
            {
                return NotFound("Niepoprawny numer lekarza!");
            }
            else
            {
                return Ok(doc);
            }

        }

        [HttpDelete("{id}")] 
        public IActionResult DeleteDoctor(string id)
        {
            var doctor = _service.GetDoctors().Where(d => d.IdDoctor.ToString() == id).FirstOrDefault();
            if (doctor != null)
            {
                _service.DeleteDoctor(doctor);
                return Ok("Usunięto doktora o id: " + id);
            }
            else
            {
                return NotFound("Nie znaleziono doktora o id: " + id);
            }
        }
    }
}
