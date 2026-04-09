using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPIAssignment1.Models;
using WebAPIAssignment1.Repositories;

namespace WebAPIAssignment1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlightController : ControllerBase
    {
        private readonly IFlightRepository _repo;

        public FlightController(IFlightRepository repo)
        {
            _repo = repo;
        }

        // GetAll()
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_repo.GetAllFlights());
        }

        // Get(id)
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var flight = _repo.GetFlight(id);
                if (flight == null) return NotFound();
                return Ok(flight);
            }
            catch (Exception ex)
            {

                return StatusCode(500, ex.Message);
            }
        }

        // Add()
        [HttpPost]
        public IActionResult Add(Flight flight)
        {
            try
            {
                _repo.AddFlight(flight);
                return Ok("Flight Added");
            }
            catch (Exception ex)
            {

                return StatusCode(500, ex.Message);
            }
        }

        // Update()
        [HttpPut]
        public IActionResult Update(Flight flight)
        {
            try
            {
                _repo.EditFlight(flight);
                return Ok("Flight Updated");
            }
            catch (Exception ex)
            {

                return StatusCode(500, ex.Message);
            }
        }

        // Delete(id)
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _repo.DeleteFlight(id);
                return Ok("Flight Deleted");
            }
            catch (Exception ex)
            {

                return StatusCode(500, ex.Message);
            }
        }
    }
}
