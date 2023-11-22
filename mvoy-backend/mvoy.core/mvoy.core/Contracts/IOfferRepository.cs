using mvoy.core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mvoy.core.Contracts
{
    public interface IOfferRepository
    {
        public IEnumerable<Offer> getAllOffers();
        public Task<Offer> getOfferById(Guid id);
        /// <summary>
        /// Register a new record of Trip data.
        /// </summary>
        /// <param name="Trip">Trip's request</param>
        public Task<Offer> CreateOffer(Offer offer);

        /// <summary>
        /// Update a specific record of Trip data.
        /// </summary>
        /// <param name="Trip">Trip's request</param>
        /// 
        public Task<Offer> UpdateOffer(Offer offer);

        /// <summary>
        ///  Remove a specific record of Trip data.
        /// </summary>
        /// <param name="Trip">Trip's request</param>
        public Task<bool> RemoveOffer(Guid OfferId);

    }
}
