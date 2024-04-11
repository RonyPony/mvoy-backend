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
        [HttpGet("{id}")]
        public async Task<Offer> GetAsync(Guid id)
        {
            return await _OfferService.getOfferById(id);
        }

        // POST api/<TripController>
        [HttpPost]
        public Task<Offer> Post([FromBody] OfferDto value)
        {
            Offer obj = new Offer();
            obj.ClientId = value.ClientId;
            obj.motorcycleUserId = value.motorcycleUserId;
            obj.tripId = value.tripId;
            obj.price = value.price;
            obj.fecha = DateTime.Now;
            return _OfferService.CreateOffer(obj);
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
