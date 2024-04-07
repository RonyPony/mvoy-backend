using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using mvoy.core.Interface;
using mvoy.core.Models;
using mvoy.data.DTOs;
using mvoy.data.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace mvoy_backend.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TripController : ControllerBase
    {
        private readonly ITripService _TripService;
        public TripController(ITripService srv)
        {
            _TripService = srv;
        }
        
        // GET: api/<TripController>
        [HttpGet]
        public IEnumerable<Trip> Get()
        {
            return _TripService.GetAllTrips();
        }

        // GET api/<TripController>/5
        [HttpGet("{id}")]
        public async Task<Trip> GetAsync(Guid id)
        {
            return await _TripService.getTripById(id);
        }


        // GET api/<TripController>/5
        [HttpGet("byUserId/{userId}")]
        public async Task<Trip> GetbyUserAsync(Guid userId)
        {
            return await _TripService.getTripByUserId(userId);
        }

        // POST api/<TripController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] tripDto trip)
        {
            Trip tripi = new Trip();
            tripi.price = trip.price;
            tripi.distance = trip.distance;
            tripi.duration = trip.duration;
            tripi.leavingTime = trip.leavingTime;
            tripi.arrivingTime = trip.arrivingTime;
            tripi.OriginName = trip.OriginName;
            tripi.statusTrip = mvoy.core.Enums.StatusTrip.Pendding;
            tripi.DestinyName = trip.DestinyName;
            tripi.driverId = trip.driverId;
            tripi.clientId = trip.clientId;
            tripi.isDeleted = false;
            Trip tp =await _TripService.SaveTrip(tripi);
            if (tp!=null)
            {
                return Ok(tp);
            }
            return BadRequest("No se pudo guardar");
        }

        // PUT api/<TripController>/5
        [HttpPut("{id}")]
        public async Task Put(Guid id, [FromBody] tripDto trip)
        {
            Trip tripi = new Trip();
            tripi = await _TripService.getTripById(id);
            tripi.price = trip.price;
            tripi.distance = trip.distance;
            tripi.duration = trip.duration;
            tripi.leavingTime = trip.leavingTime;
            tripi.arrivingTime = trip.arrivingTime;
            tripi.OriginName = trip.OriginName;
            tripi.DestinyName = trip.DestinyName;
            tripi.statusTrip = trip.statusTrip;
            tripi.driverId = trip.driverId;
            tripi.clientId = trip.clientId;
            tripi.isDeleted = false;

            _TripService.updateTrip(tripi);

        }

        // DELETE api/<TripController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            await _TripService.DeleteTrip(id);
            return Ok();
        }
    }
}
