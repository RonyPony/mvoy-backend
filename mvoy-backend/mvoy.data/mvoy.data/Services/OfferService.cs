using mvoy.core.Contracts;
using mvoy.core.Interface;
using mvoy.core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mvoy.data.Services
{
    public class OfferService : IOfferService
    {
        private readonly IOfferRepository _repo;

        public OfferService(IOfferRepository rep)
        {
            _repo = rep;
        }
        public Task<bool> RemoveOffer(Guid TripId)
        {
            return _repo.RemoveOffer(TripId);
        }

        public IEnumerable<Offer> getAllOffers()
        {
            return _repo.getAllOffers();
        }

        public List<Offer> getOfferById(Guid id)
        {
            return _repo.getOfferById(id);
        }

        public Task<Offer> CreateOffer(Offer data)
        {
            return _repo.CreateOffer(data);  
        }

        public Task<Offer> UpdateOffer(Offer data)
        {
            return _repo.UpdateOffer(data);
        }
    }
}
