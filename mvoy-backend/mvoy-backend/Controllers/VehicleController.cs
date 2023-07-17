using Microsoft.AspNetCore.Mvc;
using mvoy.core.Enums;
using mvoy.core.Interface;
using mvoy.core.Models;
using mvoy.data.DTOs;
using System.Xml.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace mvoy_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        private readonly IVehicleService _vehicleService;

        public VehicleController(IVehicleService srv)
        {
            _vehicleService = srv;
        }
        // GET: api/<VehicleController>
        [HttpGet]
        public IEnumerable<Vehicle> Get()
        {
            return _vehicleService.GetAllVehicles();
        }

        // GET api/<VehicleController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            Vehicle vehicle = await _vehicleService.GetVehicle(id);
            if (vehicle != null)
            {
                return Ok(vehicle);
            }
            else
            {
                return NotFound();
            }
        }


        // POST api/<VehicleController>
        [HttpPost]

        public async Task<IActionResult> PostAsync([FromBody] vehicleDto vehicle)
        {
            if (vehicle==null)
            {
                return BadRequest();
            }
            Vehicle newVehicle = new Vehicle();
            newVehicle.modelo = vehicle.modelo;
            newVehicle.placa = vehicle.placa;
            newVehicle.chasis = vehicle.chasis;
            newVehicle.license= vehicle.license;
            newVehicle.color = vehicle.color;
            newVehicle.marca = vehicle.marca;
            newVehicle.ownerId = vehicle.ownerId;
            newVehicle.seguro = vehicle.seguro;
            newVehicle.tieneSeguro = vehicle.tieneSeguro;
            newVehicle.year = vehicle.year;
            Vehicle created = await _vehicleService.SaveVehicle(newVehicle);
            if (created.Id!=null)
            {

                return Ok(created);
            }
            else
            {
                return StatusCode(500, "Error creating new vehicle");

            }
        }

        // PUT api/<VehicleController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<VehicleController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            if(await _vehicleService.DeleteVehicle(id))
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }
    }
}
