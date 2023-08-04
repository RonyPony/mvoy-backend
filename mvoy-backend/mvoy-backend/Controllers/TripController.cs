using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using mvoy.core.Interface;
using mvoy.core.Models;
using mvoy.data.DTOs;
using mvoy.data.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace mvoy_backend.Controllers
{
    [Authorize]
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

        // POST api/<TripController>
        [HttpPost]
        public Task<Trip> Post([FromBody] tripDto trip)
        {
            Trip tripi = new Trip();
            tripi.price = trip.price;
            tripi.distance = trip.distance;
            tripi.duration = trip.duration;
            tripi.leavingTime = trip.leavingTime;
            tripi.arrivingTime = trip.arrivingTime;
            tripi.OriginName = trip.OriginName;
            tripi.DestinyName = trip.DestinyName;
            tripi.driverId = trip.driverId;
            tripi.isDeleted = false;
            return _TripService.SaveTrip(tripi);
        }

        // PUT api/<TripController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
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
