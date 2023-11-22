using mvoy.core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mvoy.core.Interface
{
    public interface IOfferService
    {
        public IEnumerable<Offer> getAllOffers();
        public Task<Offer> getOfferById(Guid id);
        public Task<Offer> CreateOffer(Offer offer);
        public Task<Offer> UpdateOffer(Offer offer);
        public Task<bool> RemoveOffer(Guid OfferId);
    }
}
