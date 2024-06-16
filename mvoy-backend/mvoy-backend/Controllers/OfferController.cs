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
    public class OfferController : ControllerBase
    {
        private readonly IOfferService _OfferService;
        private readonly ITripService _TripService; 
        public OfferController(IOfferService srv)
        {
            _OfferService = srv;
        }
        
        // GET: api/<TripController>
        [HttpGet]
        public IEnumerable<Offer> Get()
        {
            return _OfferService.getAllOffers();
        }

        // GET api/<TripController>/5
        [HttpGet("{tripId}")]
        public IActionResult GetAsync(Guid id)
        {
            return Ok(_OfferService.getOfferById(id));
        }

        // POST api/<TripController>
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] OfferDto value)
        {
            if (value.price <= 0)
            {
                return BadRequest("Price must be specified");
            }
            Trip trip = await _TripService.getTripById(value.tripId);
            if (trip!=null)
            {
                return NotFound("trip doesnt exist");
            }

            Offer obj = new Offer();
            obj.tripId = value.tripId;
            obj.price = value.price;
            obj.offerDate = DateTime.Now;
            return Ok(_OfferService.CreateOffer(obj));
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
            await _OfferService.RemoveOffer(id);
            return Ok();
        }
    }
}
